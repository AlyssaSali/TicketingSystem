import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { OfficeUpdateFormComponent } from './office-update-form/office-update-form.component';
import { Office } from 'src/app/models/office.model';
import { OfficeService } from 'src/app/services/office.service';
import { OfficeDataService } from 'src/app/dataservices/office.dataservice';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
  selector: 'app-office',
  templateUrl: './office.component.html',
  styleUrls: ['./office.component.css']
})
export class OfficeComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  dtElement: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<Office> = new Subject();
  
  offices:Office[];

  constructor(
    private officeService: OfficeService,
    private officeDataService: OfficeDataService,
    public dialog:MatDialog,
  ) { }

  ngOnInit() {
    this.officeDataService.offices.subscribe(data =>{
      this.getOffices();
    })
  }
  async getOffices() {
    try{
      this.offices=await this.officeService.getAll().toPromise();
      this.rerender();
    }catch(error){
      alert('Something went wrong!');
      console.error(error);
    }
  }
    async delete(officeid){
      if(confirm('Are you sure you want to delete?')){
        try{
          let result= await this.officeService.delete(officeid).toPromise()
          if(result.isSuccess){
            alert(result.message)
            this.officeDataService.refreshOffices();
          }else{
            alert(result.message)
          }
          }catch(error){
            alert('Something went wrong');
            console.log(error)
          }
        }
      
    }
    update(office){
      const dialogConfig = new MatDialogConfig();
      dialogConfig.data={
        officeContext:office
      };
      dialogConfig.panelClass = 'custom-modalbox';
      this.dialog.open(OfficeUpdateFormComponent,dialogConfig)
    }

    ngAfterViewInit(): void {
      this.dtTrigger.next();
    }
  
    ngOnDestroy(): void {
      // Do not forget to unsubscribe the event
      this.dtTrigger.unsubscribe();
    }
    
    rerender(): void {
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        // Destroy the table first
        dtInstance.destroy();
        // Call the dtTrigger to rerender again
        this.dtTrigger.next();
      });
    }

}

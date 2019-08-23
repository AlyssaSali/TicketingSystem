import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { OfficeUpdateFormComponent } from './office-update-form/office-update-form.component';
import { Office } from 'src/app/models/office.model';
import { OfficeService } from 'src/app/services/office.service';
import { OfficeDataService } from 'src/app/dataservices/office.dataservice';

@Component({
  selector: 'app-office',
  templateUrl: './office.component.html',
  styleUrls: ['./office.component.css']
})
export class OfficeComponent implements OnInit {
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

}

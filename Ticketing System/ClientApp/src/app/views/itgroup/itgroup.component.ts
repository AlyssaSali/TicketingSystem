import { Component, OnInit, ViewChild } from '@angular/core';
import { ItgroupService } from 'src/app/services/itgroup.service';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { ItgroupDataService } from 'src/app/dataservices/itgroup.dataservice';
import { ItgroupUpdateFormComponent } from './itgroup-update-form/itgroup-update-form.component';
import { Itgroup } from 'src/app/models/itgroup.model';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
  selector: 'app-itgroup',
  templateUrl: './itgroup.component.html',
  styleUrls: ['./itgroup.component.css']
})
export class ItgroupComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  dtElement: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<Itgroup> = new Subject();
  
  itgroups:Itgroup[];

  constructor(
    private itgroupService: ItgroupService,
    private itgroupDataService: ItgroupDataService,
    public dialog:MatDialog,
    
  ) { }

  ngOnInit() {
    this.itgroupDataService.itgroups.subscribe(data =>{
      this.getItgroups();
    })
  }
  async getItgroups() {
    try{

      this.itgroups=await this.itgroupService.getGroups().toPromise();
      this.rerender();
    }catch(error){
      alert('Something went wrong!');
      console.error(error);
    }
  }
    async delete(itGroupid){
      if(confirm('Are you sure you want to delete?')){
        try{
          let result= await this.itgroupService.delete(itGroupid).toPromise()
          if(result.isSuccess){
            alert(result.message)
            this.itgroupDataService.refreshItgroups();
          }else{
            alert(result.message)
          }
          }catch(error){
            alert('Something went wrong');
            console.log(error)
          }
        }
      
    }
    update(itgroup){
      const dialogConfig = new MatDialogConfig();
      dialogConfig.data={
        itgroupContext:itgroup
      };
      dialogConfig.width='600px';
      //dialogConfig.height='600px';
      this.dialog.open(ItgroupUpdateFormComponent,dialogConfig)
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
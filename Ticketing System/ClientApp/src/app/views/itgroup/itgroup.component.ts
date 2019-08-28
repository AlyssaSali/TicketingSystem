import { Component, OnInit } from '@angular/core';
import { ItgroupService } from 'src/app/services/itgroup.service';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material';
import { ItgroupDataService } from 'src/app/dataservices/itgroup.dataservice';
import { ItgroupUpdateFormComponent } from './itgroup-update-form/itgroup-update-form.component';
import { Itgroup } from 'src/app/models/itgroup.model';
<<<<<<< HEAD
import { ItgroupAddFormComponent } from './itgroup-add-form/itgroup-add-form.component';
=======
<<<<<<< HEAD
import { ItgroupAddFormComponent } from './itgroup-add-form/itgroup-add-form.component';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
=======
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';
import { ItgroupAddFormComponent } from './itgroup-add-form/itgroup-add-form.component';
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2

@Component({
  selector: 'app-itgroup',
  templateUrl: './itgroup.component.html',
  styleUrls: ['./itgroup.component.css']
})
export class ItgroupComponent implements OnInit {
<<<<<<< HEAD
=======
  @ViewChild(DataTableDirective, {static: false})
  dtElement: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<Itgroup> = new Subject();
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2

  itgroups:Itgroup[];

  constructor(
    private itgroupService: ItgroupService,
    private itgroupDataService: ItgroupDataService,
    private dialogRef: MatDialogRef<ItgroupAddFormComponent>,
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
      dialogConfig.panelClass = 'custom-modalbox';
      this.dialog.open(ItgroupUpdateFormComponent,dialogConfig)
    }
<<<<<<< HEAD
=======

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
<<<<<<< HEAD
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2

    close(){
=======
  close(){
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
      this.dialogRef.close();
    }

}
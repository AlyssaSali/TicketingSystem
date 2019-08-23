import { Component, OnInit } from '@angular/core';
import { ItgroupService } from 'src/app/services/itgroup.service';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material';
import { ItgroupDataService } from 'src/app/dataservices/itgroup.dataservice';
import { ItgroupUpdateFormComponent } from './itgroup-update-form/itgroup-update-form.component';
import { Itgroup } from 'src/app/models/itgroup.model';
import { ItgroupAddFormComponent } from './itgroup-add-form/itgroup-add-form.component';

@Component({
  selector: 'app-itgroup',
  templateUrl: './itgroup.component.html',
  styleUrls: ['./itgroup.component.css']
})
export class ItgroupComponent implements OnInit {

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

      this.itgroups=await this.itgroupService.getAll().toPromise();
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

    
  close(){
      this.dialogRef.close();
    }

}
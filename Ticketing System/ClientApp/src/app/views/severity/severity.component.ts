import { Component, OnInit } from '@angular/core';
import { Severity } from 'src/app/models/severity.model';
import { SeverityService } from 'src/app/services/severity.service';
import { SeverityDataService } from 'src/app/dataservices/severity.dataservice';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material';
import { SeverityUpdateFormComponent } from './severity-update-form/severity-update-form.component';
import { CategoryAddFormComponent } from '../category/category-add-form/category-add-form.component';
import { SeverityAddFormComponent } from './severity-add-form/severity-add-form.component';

@Component({
  selector: 'app-severity',
  templateUrl: './severity.component.html',
  styleUrls: ['./severity.component.css']
})
export class SeverityComponent implements OnInit {
  severities:Severity[];

  constructor(
    private severityService: SeverityService,
    private severityDataService: SeverityDataService,
    private dialogRef: MatDialogRef<SeverityAddFormComponent>,
    public dialog:MatDialog,
    
  ) { }

  ngOnInit() {
    this.severityDataService.severities.subscribe(data =>{
      this.getSeverities();
    })
  }

  async getSeverities() {
    try{
      this.severities=await this.severityService.getAll().toPromise();
    }catch(error){
      alert('Something went wrong!');
      console.error(error);
    }
  }
    async delete(severityid){
      if(confirm('Are you sure you want to delete?')){
        try{
          let result= await this.severityService.delete(severityid).toPromise()
          if(result.isSuccess){
            alert(result.message)
            this.severityDataService.refreshSeverities();
          }else{
            alert(result.message)
          }
          }catch(error){
            alert('Something went wrong');
            console.log(error)
          }
        }
      
    }
    update(severity){
      const dialogConfig = new MatDialogConfig();
      dialogConfig.data={
        severityContext:severity
      };
      dialogConfig.panelClass = 'custom-modalbox';
      this.dialog.open(SeverityUpdateFormComponent,dialogConfig)
    }

    
  close(){
      this.dialogRef.close();
    }

}

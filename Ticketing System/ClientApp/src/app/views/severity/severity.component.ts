import { Component, OnInit } from '@angular/core';
import { Severity } from 'src/app/models/severity.model';
import { MatDialogConfig, MatDialog, MatDialogRef } from '@angular/material';
import { SeverityDataservice } from 'src/app/dataservices/severity.dataservice';
import { SeverityService } from 'src/app/services/severity.service';
import { SeverityEditFormComponent } from './severity-edit-form/severity-edit-form.component';

@Component({
  selector: 'app-severity',
  templateUrl: './severity.component.html',
  styleUrls: ['./severity.component.css']
})
export class SeverityComponent implements OnInit {
  severities: Severity[]; //array of list from the table

  constructor(
    private severityService: SeverityService,
    private severityDataService: SeverityDataservice,
    // public dialogRef: MatDialogRef<SeverityEditFormComponent>,
    public dialog: MatDialog
   ) {}

  ngOnInit() {
    this.severityDataService.severitys.subscribe( data => { this.getSeverity();
  })
  }

  async getSeverity(){
    try {
      this.severities = await this.severityService.getAll().toPromise();
    } catch (error) {
      alert('something went wrong!');
      console.error(error);
    }
  }

  async delete(id){
    if(confirm("Are you sure you want to delete?")){
      try{
        let result = await this.severityService.delete(id).toPromise();
        if(result.isSuccess){
          alert(result.message)
          this.severityDataService.refreshBooks();
        }  else {
          alert(result.message)
        }
      } catch (error) {
        alert("Something went wrong");
        console.log(error)
      }
    }
  }

  update(severity){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      genreContext: severity
    };
    dialogConfig.width = '600px';
    //dialogConfig.height = '600px';
    this.dialog.open(SeverityEditFormComponent, dialogConfig)
  }

  // close(){
  //   this.dialogRef.close();
  // }
}

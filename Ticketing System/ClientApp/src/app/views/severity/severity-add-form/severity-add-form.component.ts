import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ThrowStmt } from '@angular/compiler';
import { MatDialogRef, MatDialog } from '@angular/material';
import { SeverityService } from 'src/app/services/severity.service';
import { SeverityDataservice } from 'src/app/dataservices/severity.dataservice';
import { SeverityEditFormComponent } from '../severity-edit-form/severity-edit-form.component';

@Component({
  selector: 'app-severity-add-form',
  templateUrl: './severity-add-form.component.html',
  styleUrls: ['./severity-add-form.component.css']
})
export class SeverityAddFormComponent implements OnInit {
  severityCreateForm: FormGroup;
  isSubmit = false;

  nameBackEndErrors: string[];

  constructor(
    private severityService: SeverityService,
    private severityDataService: SeverityDataservice,
  //  public dialogRef: MatDialogRef<SeverityEditFormComponent>
  ) { 
    this.severityCreateForm = new FormGroup({
      severityCode: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      severityDesc: new FormControl('', [Validators.required, Validators.maxLength(50)]),
    })
  }

  ngOnInit() {
  }

  get f() { return this.severityCreateForm.controls; }

  async onFormSubmit(){
    let ok = confirm ("Are you sure you want to submit?");

    if (!ok){
      return
    }

    if (!this.severityCreateForm.valid)
     return;

     try {
       this.isSubmit = true;
       this.nameBackEndErrors = null;
       let result = await this.severityService.create(this.severityCreateForm.value).toPromise();
      if (result.isSuccess) {
        alert(result.message);
        this.severityCreateForm.reset();
        this.severityDataService.refreshBooks();
      }
      else {
        alert(result.message);
      }
     } catch (error) {
       console.error(error)
       let errs = error.error

       if(errs.isSuccess === false){
        alert(errs.message);
        return;   
      }
      
      if(errs.error){
        if('name' in errs.errors) {
          this.nameBackEndErrors = errs.errors.name;
        }
        }

        this.isSubmit = false;
     }  finally{
        this.isSubmit = false;
     }
  }

  // close(){
  //     this.dialogRef.close();
  //   }
}

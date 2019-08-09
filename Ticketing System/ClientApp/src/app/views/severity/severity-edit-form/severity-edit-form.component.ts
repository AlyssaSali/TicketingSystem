import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { Severity } from 'src/app/models/severity.model';
import { SeverityDataservice } from 'src/app/dataservices/severity.dataservice';
import { SeverityService } from 'src/app/services/severity.service';

@Component({
  selector: 'app-severity-edit-form',
  templateUrl: './severity-edit-form.component.html',
  styleUrls: ['./severity-edit-form.component.css']
})
export class SeverityEditFormComponent implements OnInit {
  isSubmit = false;
  nameBackEndErrors: string[];
  

  severityContext: any;
  severityEditForm: FormGroup;
  severityToBeEditted: Severity;

  constructor(
    private severityService: SeverityService,
    private severityDataService: SeverityDataservice,
    public dialogRef: MatDialogRef<SeverityEditFormComponent>,
    @Inject(MAT_DIALOG_DATA) data
  ) { 
    this.severityEditForm = new FormGroup({
      id: new FormControl(),
      severityCode: new FormControl('',[Validators.required, Validators.maxLength(50)]),
      severityDesc: new FormControl('',[Validators.required, Validators.maxLength(50)])
    })
    this.severityContext = data;
  }

  get f() { return this.severityEditForm.controls;}

  ngOnInit() {
    this.severityToBeEditted = this.severityContext.genreContext;
    this.change();
  }
  change() {
    this.severityEditForm.controls['severityCode'].setValue(this.severityToBeEditted.severityCode);
    this.severityEditForm.controls['severityDesc'].setValue(this.severityToBeEditted.severityDesc);
  }

  async onFormSubmit(){
    let ok = confirm ("Are you sure you want to submit?");

    if (!ok){
      return;
    }

    if (!this.severityEditForm.valid)
     return;

     try {
       this.isSubmit = true;
       this.nameBackEndErrors = null;
       this.severityEditForm.value.id = this.severityToBeEditted.id;
       let result = await this.severityService.update(this.severityEditForm.value).toPromise();
      if (result.isSuccess) {
        alert(result.message);
        this.close();
        this.severityEditForm.reset();
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
      

        this.isSubmit = false;
     }  finally{
        this.isSubmit = false;
     }
  }

  close(){
    this.dialogRef.close();
  }
}
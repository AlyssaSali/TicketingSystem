import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Severity } from 'src/app/models/severity.model';
import { SeverityService } from 'src/app/services/severity.service';
import { SeverityDataService } from 'src/app/dataservices/severity.dataservice';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-severity-update-form',
  templateUrl: './severity-update-form.component.html',
  styleUrls: ['./severity-update-form.component.css']
})
export class SeverityUpdateFormComponent implements OnInit {
 
  isSubmit = false;

   severityidBackEndErrors: number[];
   severityCodeBackEndErrors: string[];
   severityNameBackEndErrors: string[];

  severityContext:any;
  severityUpdateform: FormGroup;
  severityToBeEdited:Severity;

  constructor(
    private severityService: SeverityService,
    private severityDataService: SeverityDataService,
    public dialogRef:MatDialogRef<SeverityUpdateFormComponent>,
    @Inject(MAT_DIALOG_DATA) data

  ) {
    this.severityUpdateform = new FormGroup({
      severityid: new FormControl(),
      severityCode: new FormControl('',[Validators.required,Validators.maxLength(50)]),
      severityName: new FormControl('',[Validators.required,Validators.maxLength(50)]),
      severityDesc: new FormControl('',[Validators.maxLength(50)]),
    })
      this.severityContext = data;
   }
  
  ngOnInit() {
    this.severityToBeEdited = this.severityContext.severityContext;
    this.change();
  }
  get f() {return this.severityUpdateform.controls;}

  change(){
    this.severityUpdateform.controls['severityCode'].setValue(this.severityToBeEdited.severityCode)
    this.severityUpdateform.controls['severityName'].setValue(this.severityToBeEdited.severityName)
    this.severityUpdateform.controls['severityDesc'].setValue(this.severityToBeEdited.severityDesc)
  }
  close(){
    this.dialogRef.close();
  }
  async onFormSubmit(){
    let ok = confirm("Are you sure you want to submit?");

    if(!ok){
      return;
    }
    if(!this.severityUpdateform.valid)
    return;

    try{
      this.isSubmit=true;
      this.severityCodeBackEndErrors=null;
      this.severityNameBackEndErrors=null;
      this.severityUpdateform.value.severityid=this.severityToBeEdited.severityid;
      let result = await this.severityService.update(this.severityUpdateform.value).toPromise();
      if(result.isSuccess){
        alert(result.message);
        this.severityUpdateform.reset();
        this.severityDataService.refreshSeverities();
        this.close();
      }
      else{
        alert(result.message);  
      }
    }catch(error){
      console.error(error)
      let errs=error.error

      if(errs.isSuccess===false){
        alert(errs.message);
        return;
      }
      if(errs.errors){
        if('severityCode' in errs.errors){
          this.severityCodeBackEndErrors=errs.errors.severityCode;
        }
    }
    if(errs.errors){
      if('severityName' in errs.errors){
        this.severityNameBackEndErrors=errs.errors.severityName;
      }
  }
    this.isSubmit = false;
  }  finally{
      this.isSubmit= false;
  }
}

}

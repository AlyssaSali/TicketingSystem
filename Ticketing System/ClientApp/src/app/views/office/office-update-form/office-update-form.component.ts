import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Office } from 'src/app/models/office.model';
import { OfficeService } from 'src/app/services/office.service';
import { OfficeDataService } from 'src/app/dataservices/office.dataservice';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-office-update-form',
  templateUrl: './office-update-form.component.html',
  styleUrls: ['./office-update-form.component.css']
})
export class OfficeUpdateFormComponent implements OnInit {
 
  isSubmit = false;

   officeidBackEndErrors: number[];
   officecodeBackEndErrors: string[];
   officedescBackEndErrors: string[];
  

  officeContext:any;
  officeUpdateform: FormGroup;
  officeToBeEdited:Office;

  constructor(
    private officeService: OfficeService,
    private officeDataService: OfficeDataService,
    public dialogRef:MatDialogRef<OfficeUpdateFormComponent>,
    @Inject(MAT_DIALOG_DATA) data

  ) {
    this .officeUpdateform = new FormGroup({
      officeid: new FormControl(),
      officeCode: new FormControl('',[Validators.required,Validators.maxLength(50)]),
      officeDesc: new FormControl('',[Validators.required,Validators.maxLength(50)]),
      
      
    })
      this.officeContext = data;
   }
  
  ngOnInit() {
    this.officeToBeEdited = this.officeContext.officeContext;
    this.change();
  }
  get f() {return this.officeUpdateform.controls;}

  change(){
    this.officeUpdateform.controls['officeCode'].setValue
    (this.officeToBeEdited.officeCode)
    this.officeUpdateform.controls['officeDesc'].setValue
    (this.officeToBeEdited.officeDesc)
   
  }
  close(){
    this.dialogRef.close();
  }
  async onFormSubmit(){
    let ok = confirm("Are you sure you want to submit?");

    if(!ok){
      return;
    }
    if(!this.officeUpdateform.valid)
    return;

    try{
      this.isSubmit=true;
      this.officecodeBackEndErrors=null;
      this.officedescBackEndErrors=null;
      
      this.officeUpdateform.value.officeid=this.officeToBeEdited.officeid;
      

      let result = await this.officeService.update(this.officeUpdateform.value).toPromise();
      if(result.isSuccess){
        alert(result.message);
        this.officeUpdateform.reset();
        this.officeDataService.refreshOffices();
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
        if('officeCode' in errs.errors){
          this.officecodeBackEndErrors=errs.errors.officeCode;
        }
        
    }
    if(errs.errors){
      if('officeDesc' in errs.errors){
        this.officedescBackEndErrors=errs.errors.officeDesc;
      }
      
  }
    this.isSubmit = false;
  }  finally{
      this.isSubmit= false;
  }
}

}

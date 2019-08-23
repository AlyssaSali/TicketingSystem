import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { EmployeeType } from 'src/app/models/employeetype.model';
import { EmployeeTypeService } from 'src/app/services/employeetype.service';
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-employeetype-update-form',
  templateUrl: './employeetype-update-form.component.html',
  styleUrls: ['./employeetype-update-form.component.css']
})
export class EmployeetypeUpdateFormComponent implements OnInit {

  isSubmit = false;

  employeeTypeidBackEndErrors: number[];
  employeeTypeNameBackEndErrors: string[];
  

  employeeTypeContext:any;
  employeetypeUpdateForm: FormGroup;
  employeetypeToBeEdited:EmployeeType;


  constructor(
    private employeetypeService: EmployeeTypeService,
    private employeetypeDataService: EmployeeTypeDataService,
    public dialogRef:MatDialogRef<EmployeetypeUpdateFormComponent>,
    @Inject(MAT_DIALOG_DATA) data

  ) {
    this.employeetypeUpdateForm = new FormGroup({
      employeetypeid: new FormControl(),
      employeetypename: new FormControl('',[Validators.required,Validators.maxLength(50)])      
      
    })
      this.employeeTypeContext = data;
   }
  
  ngOnInit() {
    this.employeetypeToBeEdited = this.employeeTypeContext.employeeTypeContext;
    this.change();
  }
  get f() {return this.employeetypeUpdateForm.controls;}

  change(){
    this.employeetypeUpdateForm.controls['employeetypename'].setValue
    (this.employeetypeToBeEdited.employeeTypeName);
  }
  close(){
    this.dialogRef.close();
  }
  async onFormSubmit(){
    let ok = confirm("Are you sure you want to submit?");

    if(!ok){``
      return;
    }
    if(!this.employeetypeUpdateForm.valid)
    return;

    try{
      this.isSubmit=true;
      this.employeeTypeNameBackEndErrors=null;
      
      this.employeetypeUpdateForm.value.employeetypeid=this.employeetypeToBeEdited.employeeTypeid;
      

      let result = await this.employeetypeService.update(this.employeetypeUpdateForm.value).toPromise();
      if(result.isSuccess){
        alert(result.message);
        this.employeetypeUpdateForm.reset();
        this.employeetypeDataService.refreshEmployeeTypes();
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
        if('employeetypename' in errs.errors){
          this.employeeTypeNameBackEndErrors=errs.errors.employeeTypeName;
        }
        
    }
    
    this.isSubmit = false;
  }  finally{
      this.isSubmit= false;
  }
}

}

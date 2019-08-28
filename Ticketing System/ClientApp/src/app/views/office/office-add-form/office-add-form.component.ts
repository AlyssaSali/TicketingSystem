import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { OfficeService } from 'src/app/services/office.service';
import { OfficeDataService } from 'src/app/dataservices/office.dataservice';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-office-add-form',
  templateUrl: './office-add-form.component.html',
  styleUrls: ['./office-add-form.component.css']
})
export class OfficeAddFormComponent implements OnInit {
  officeCreateForm: FormGroup;
   isSubmit = false;
   
   officecodeBackEndErrors: string[];
   officedescBackEndErrors: string[];
   
   constructor(
     private officeService: OfficeService,
     private officeDataService: OfficeDataService,
    //  public dialogRef:MatDialogRef<OfficeAddFormComponent>
   ) {
     this .officeCreateForm = new FormGroup({
       officecode: new FormControl('',[Validators.required,Validators.maxLength(50)]),
       officedesc: new FormControl('',[Validators.required,Validators.maxLength(50)]),
     })
    }
   
 
   ngOnInit() {
   }
   get f() {return this.officeCreateForm.controls;}
 
   
   async onFormSubmit(){
     let ok = confirm("Are you sure you want to submit?");
 
     if(!ok){
       return;
     }
     if(!this.officeCreateForm.valid)
     return;
 
     try{
       this.isSubmit=true;
       this.officecodeBackEndErrors=null;
       this.officedescBackEndErrors=null;
       let result = await this.officeService.create(this.officeCreateForm.value).toPromise();
       if(result.isSuccess){
         alert(result.message);
         this.officeCreateForm.reset();
         this.officeDataService.refreshOffices();
        
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
         if('officecode' in errs.errors){
           this.officecodeBackEndErrors=errs.errors.officecode;
         }
        }
         if(errs.errors){
          if('officedesc' in errs.errors){
            this.officedescBackEndErrors=errs.errors.officedesc;
          }
         
     }
     this.isSubmit = false;
   }  finally{
       this.isSubmit= false;
   }
 }

//  close(){
//   this.dialogRef.close();
//   }

  reset(){
    this.officeCreateForm.reset();
  }
 
 }

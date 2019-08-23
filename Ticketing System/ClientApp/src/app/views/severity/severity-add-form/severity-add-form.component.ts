import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { SeverityService } from 'src/app/services/severity.service';
import { SeverityDataService } from 'src/app/dataservices/severity.dataservice';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-severity-add-form',
  templateUrl: './severity-add-form.component.html',
  styleUrls: ['./severity-add-form.component.css']
})
export class SeverityAddFormComponent implements OnInit {
  severityCreateForm: FormGroup;
   isSubmit = false;
 
   constructor(
     private severityService: SeverityService,
     private severityDataService: SeverityDataService,
     
   ) {
     this .severityCreateForm = new FormGroup({
       severityCode: new FormControl('',[Validators.required,Validators.maxLength(50)]),
       severityName: new FormControl('',[Validators.required,Validators.maxLength(50)]),
       severityDesc: new FormControl('',[Validators.maxLength(500)])
     })
    }
   
 
   ngOnInit() {
   }
   get f() {return this.severityCreateForm.controls;}
 
   
   async onFormSubmit(){
     let ok = confirm("Are you sure you want to submit?");
 
     if(!ok){
       return;
     }
     if(!this.severityCreateForm.valid)
     return;
 
     try{
       this.isSubmit=true;
       let result = await this.severityService.create(this.severityCreateForm.value).toPromise();
       if(result.isSuccess){
         alert(result.message);
         this.severityCreateForm.reset();
         this.severityDataService.refreshSeverities();
        
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
     this.isSubmit = false;
   }  finally{
       this.isSubmit= false;
   }
 }
 
 }

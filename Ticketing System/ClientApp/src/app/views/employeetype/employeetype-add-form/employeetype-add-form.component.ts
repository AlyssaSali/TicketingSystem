import { Component, OnInit } from '@angular/core';
import { EmployeeTypeService } from 'src/app/services/employeetype.service';
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-employeetype-add-form',
  templateUrl: './employeetype-add-form.component.html',
  styleUrls: ['./employeetype-add-form.component.css']
})
export class EmployeetypeAddFormComponent implements OnInit {

  employeetypeCreateForm: FormGroup;
   isSubmit = false;
 
   
   employeeTypeNameBackEndErrors: string[];
   
   
 
   constructor(
     private employeeTypeService: EmployeeTypeService,
     private employeeTypeDataService: EmployeeTypeDataService,
     
   ) {
     this .employeetypeCreateForm = new FormGroup({
       employeetypename: new FormControl('',[Validators.required,Validators.maxLength(50)]),
     })
    }
   
 
   ngOnInit() {
   }
   get f() {return this.employeetypeCreateForm.controls;}
 
   
   async onFormSubmit(){
     let ok = confirm("Are you sure you want to submit?");
 
     if(!ok){
       return;
     }
     if(!this.employeetypeCreateForm.valid)
     return;
 
     try{
       this.isSubmit=true;
       this.employeeTypeNameBackEndErrors=null;
       let result = await this.employeeTypeService.create(this.employeetypeCreateForm.value).toPromise();
       if(result.isSuccess){
         alert(result.message);
         this.employeetypeCreateForm.reset();
         this.employeeTypeDataService.refreshEmployeeTypes();
        
       }
       else{
         alert(result.message);  
       }
     }
     catch(error){
       console.error(error)
       let errs=error.error
 
       if(errs.isSuccess===false){
         alert(errs.message);
         return;
       }
       if(errs.errors){
         if('employeetypename' in errs.errors){
           this.employeeTypeNameBackEndErrors=errs.errors.employeetypename;
         }
        }
     this.isSubmit = false;
     }  
     finally{
       this.isSubmit= false;
     }
 }

}

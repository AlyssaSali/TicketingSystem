import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ItgroupService } from 'src/app/services/itgroup.service';
import { ItgroupDataService } from 'src/app/dataservices/itgroup.dataservice';

@Component({
  selector: 'app-itgroup-add-form',
  templateUrl: './itgroup-add-form.component.html',
  styleUrls: ['./itgroup-add-form.component.css']
})
export class ItgroupAddFormComponent implements OnInit {
  itgroupCreateForm: FormGroup;
   isSubmit = false;
 
   
   itgroupcodeBackEndErrors: string[];
   itgroupnameBackEndErrors: string[];
   
   
 
   constructor(
     private itgroupService: ItgroupService,
     private itgroupDataService: ItgroupDataService,
     
   ) {
     this.itgroupCreateForm = new FormGroup({
      
      itgroupcode: new FormControl('',[Validators.required,Validators.maxLength(50)]),
      itgroupname: new FormControl('',[Validators.required,Validators.maxLength(50)]),
     })
    }
   
 
   ngOnInit() {
   }
   get f() {return this.itgroupCreateForm.controls;}
 
   
   async onFormSubmit(){
     let ok = confirm("Are you sure you want to submit?");
 
     if(!ok){
       return;
     }
     if(!this.itgroupCreateForm.valid)
     return;
 
     try{
       this.isSubmit=true;
       this.itgroupcodeBackEndErrors=null;
       this.itgroupnameBackEndErrors=null;
       let result = await this.itgroupService.create(this.itgroupCreateForm.value).toPromise();
       if(result.isSuccess){
         alert(result.message);
         this.itgroupCreateForm.reset();
         this.itgroupDataService.refreshItgroups();   
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
         if('itgroupcode' in errs.errors){
           this.itgroupcodeBackEndErrors=errs.errors.itgroupcode;
         }
        }
         if(errs.errors){
          if('itgroupname' in errs.errors){
            this.itgroupnameBackEndErrors=errs.errors.itgroupname;
          }
         
     }
     this.isSubmit = false;
   }  finally{
       this.isSubmit= false;
   }
 }
 
 }

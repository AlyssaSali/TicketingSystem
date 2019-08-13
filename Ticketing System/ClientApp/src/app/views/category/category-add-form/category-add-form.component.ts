import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CategoryService } from 'src/app/services/category.service';
import { CategoryDataService } from 'src/app/dataservices/category.dataservice';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-category-add-form',
  templateUrl: './category-add-form.component.html',
  styleUrls: ['./category-add-form.component.css']
})
export class CategoryAddFormComponent implements OnInit {
  categoryCreateForm: FormGroup;
   isSubmit = false;
 
   
   categoryNameBackEndErrors: string[];
   
   
 
   constructor(
     private categoryService: CategoryService,
     private categoryDataService: CategoryDataService,
     
   ) {
     this .categoryCreateForm = new FormGroup({
       categoryName: new FormControl('',[Validators.required,Validators.maxLength(50)]),
     })
    }
   
 
   ngOnInit() {
   }
   get f() {return this.categoryCreateForm.controls;}
 
   
   async onFormSubmit(){
     let ok = confirm("Are you sure you want to submit?");
 
     if(!ok){
       return;
     }
     if(!this.categoryCreateForm.valid)
     return;
 
     try{
       this.isSubmit=true;
       this.categoryNameBackEndErrors=null;
       let result = await this.categoryService.create(this.categoryCreateForm.value).toPromise();
       if(result.isSuccess){
         alert(result.message);
         this.categoryCreateForm.reset();
         this.categoryDataService.refreshCategorys();
        
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
         if('categoryName' in errs.errors){
           this.categoryNameBackEndErrors=errs.errors.categoryName;
         }
        }
     this.isSubmit = false;
   }  finally{
       this.isSubmit= false;
   }
 }
 
 }

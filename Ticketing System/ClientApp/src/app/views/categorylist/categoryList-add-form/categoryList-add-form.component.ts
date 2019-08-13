import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CategoryListService } from 'src/app/services/categoryList.service';
import { CategoryListDataService } from 'src/app/dataservices/categoryList.dataservice';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { CategoryDataService } from 'src/app/dataservices/category.dataservice';
import { CategoryService } from 'src/app/services/category.service';
import { SeverityService } from 'src/app/services/severity.service';
import { SeverityDataService } from 'src/app/dataservices/severity.dataservice';
import { Category } from 'src/app/models/category.model';
import { Severity } from 'src/app/models/severity.model';

@Component({
  selector: 'app-categoryList-add-form',
  templateUrl: './categoryList-add-form.component.html',
  styleUrls: ['./categoryList-add-form.component.css']
})
export class CategoryListAddFormComponent implements OnInit {
  categoryListCreateForm: FormGroup;
   isSubmit = false;

   categories: Category[];
   severities: Severity[];
 
   categoryListNameBackEndErrors: string[];
   categoryNameBackEndErrors: string[];
 
   constructor(
     private categoryListService: CategoryListService,
     private categoryListDataService: CategoryListDataService,
     private categoryService: CategoryService,
     private categoryDataService: CategoryDataService,
     private severityService: SeverityService,
     private severityDataService: SeverityDataService,
   ) {
     this.categoryListCreateForm = new FormGroup({
       categoryListName: new FormControl('',[Validators.required,Validators.maxLength(50)]),
       categoryid: new FormControl(''),
       categorySelect: new FormControl('',[Validators.required]),
       categoryName: new FormControl('',[Validators.required,Validators.maxLength(50)]),
       severityid: new FormControl(''),
       severitySelect: new FormControl('',[Validators.required]),
       severityCode: new FormControl('',[Validators.required,Validators.maxLength(50)]),
       slaResponseTime: new FormControl('',[Validators.required,Validators.maxLength(50)]),
       slaResolvedTime: new FormControl('',[Validators.required,Validators.maxLength(50)]),
       itGroup: new FormControl('',[Validators.required,Validators.maxLength(50)]),
     })
    }
   
 
   ngOnInit(
   ) {
      this.categoryDataService.categorySource.subscribe(data => {
      this.getCategoryLists();
    })
      this.severityDataService.severitySource.subscribe(data => {
      this.getSeverityLists();
    })
   }
   get f() {return this.categoryListCreateForm.controls;}
 
   async getCategoryLists(){
    try {
      this.categories = await this.categoryService.getAll().toPromise();
    } catch (error) {
      console.log(error);
    }
  }

  async getSeverityLists(){
    try {
      this.severities = await this.severityService.getAll().toPromise();
    } catch (error) {
      console.log(error);
    }
  }
   
   async onFormSubmit(){
     let ok = confirm("Are you sure you want to submit?");
 
     if(!ok){
       return;
     }
    //  if(!this.categoryListCreateForm.valid)
    //  return;
 
     try{
       this.isSubmit=true;
       this.categoryListNameBackEndErrors=null;
       this.categoryNameBackEndErrors=null;
       let result = await this.categoryListService.create(this.categoryListCreateForm.value).toPromise();
       if(result.isSuccess){
         alert(result.message);
         this.categoryListCreateForm.reset();
         this.categoryListDataService.refreshCategorylists();
       }
       else{
         alert(result.message);  
       }
     }catch(error){
       console.error(error)
       let errs=error.error
 
       if(errs.isSuccess==false){
         alert(errs.message);
         return;
       }
       if(errs.errors){
         if('categoryListName' in errs.errors){
           this.categoryListNameBackEndErrors=errs.errors.categoryListName;
         }
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

 // find the selected genre from the list
 selectCategory($event){
  let category = this.categoryListCreateForm.value.categorySelect;
  if (category.length > 2) {
    if ($event.timeStamp > 200) {
      let selectedCategory = this.categories.find(data => data.categoryName == category);
      if(selectedCategory){
        this.categoryListCreateForm.controls['categoryid'].setValue(selectedCategory.categoryid);
      }
    }
  }
}

selectSeverity($event){
  let severity = this.categoryListCreateForm.value.severitySelect;
  if (severity.length > 2) {
    if ($event.timeStamp > 200) {
      let selectedSeverity = this.severities.find(data => data.severityCode == severity);
      if(selectedSeverity){
        this.categoryListCreateForm.controls['severityid'].setValue(selectedSeverity.severityid);
      }
    }
  }
}
 
 }

import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CategoryListService } from 'src/app/services/categoryList.service';
import { CategoryListDataService } from 'src/app/dataservices/categoryList.dataservice';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatDialogConfig } from '@angular/material';
import { Category } from 'src/app/models/category.model';
import { CategoryDataService } from 'src/app/dataservices/category.dataservice';
import { CategoryService } from 'src/app/services/category.service';
import { CategoryComponent } from '../../category/category.component';
import { Severity } from 'src/app/models/severity.model';
import { SeverityDataService } from 'src/app/dataservices/severity.dataservice';
import { SeverityService } from 'src/app/services/severity.service';
import { SeverityComponent } from '../../severity/severity.component';
import { Itgroup } from 'src/app/models/itgroup.model';
import { ItgroupService } from 'src/app/services/itgroup.service';
import { ItgroupDataService } from 'src/app/dataservices/itgroup.dataservice';
import { ItgroupComponent } from '../../itgroup/itgroup.component';

@Component({
  selector: 'app-categoryList-add-form',
  templateUrl: './categoryList-add-form.component.html',
  styleUrls: ['./categoryList-add-form.component.css']
})
export class CategoryListAddFormComponent implements OnInit {
  categoryListCreateForm: FormGroup;
   isSubmit = false;
   isValid = true;
 
   categoryList: Category[];
   severityList: Severity[];
   itGroupList: Itgroup[];

   constructor(
     private categoryListService: CategoryListService,
     private categoryListDataService: CategoryListDataService,
     private categoryService: CategoryService,
     private categoryDataService: CategoryDataService,
     private severityService: SeverityService,
     private severityDataService: SeverityDataService,
     private itgroupService: ItgroupService,
     private itgroupDataService: ItgroupDataService,
     private dialog: MatDialog
   ) {
     this .categoryListCreateForm = new FormGroup({
       categoryListName: new FormControl('',[Validators.required,Validators.maxLength(50)]),
       slaResponseTime: new FormControl('',[Validators.required, Validators.maxLength(50)]),
       slaResolvedTime: new FormControl('',[Validators.required, Validators.maxLength(50)]),
       slaResponseTimeExt: new FormControl(''),
       slaResolvedTimeExt: new FormControl(''),
       severityName: new FormControl(''),
       categoryType: new FormControl(''),
       categoryid: new FormControl(''),
       categorySelect: new FormControl(''),
       severityid: new FormControl(''),
       severitySelect: new FormControl(''),
       itGroupid: new FormControl(''),
       itGroupSelect: new FormControl('')
     })
    }
   
 
   ngOnInit() {
      this.categoryDataService.categorySource.subscribe( data => { this.getCategoryLists(); });
      this.severityDataService.severitySource.subscribe( data => { this.getSeverityLists(); });
      this.itgroupDataService.itgroupSource.subscribe( data => { this.getItGroupLists(); });
   }
   get f() {return this.categoryListCreateForm.controls;}
 
    
   async onFormSubmit(){
     let ok = confirm("Are you sure you want to submit?");
 
     if(!ok){
       return;
     }
     if(!this.categoryListCreateForm.valid)
     return;
 
     try{
       this.isSubmit=true;
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
 
       if(errs.isSuccess===false){
         alert(errs.message);
         return;
       }
     this.isSubmit = false;
   }  finally{
       this.isSubmit= false;
   }
 }

 async getCategoryLists(){
  try {
    this.categoryList = await this.categoryService.getAll().toPromise();
  } catch (error) {
    console.log(error);
  }
}

async getSeverityLists(){
  try {
    this.severityList = await this.severityService.getAll().toPromise();
    console.log(this.severityList);
  } catch (error) {
    console.log(error);
  }
}

async getItGroupLists(){
  try {
    this.itGroupList = await this.itgroupService.getGroups().toPromise();
  } catch (error) {
    console.log(error);
  }
}

selectCategory($event){
  let category = this.categoryListCreateForm.value.categorySelect;
  if (category.length > 2) {
    if ($event.timeStamp > 200) {
      let selectedCategory = this.categoryList.find(data => data.categoryName == category);
      if (selectedCategory) {
        this.categoryListCreateForm.controls['categoryid'].setValue(selectedCategory.categoryid);
      }
    }      
  }
}

selectSeverity($event){
  let severity = this.categoryListCreateForm.value.severitySelect;
  
  //console.log(this.severityList.values);
  if (severity.length > 0) {
    if ($event.timeStamp > 200) {
      let selectedSeverity = this.severityList.find(data => data.severityCode == severity);
      if (selectedSeverity) {
        this.categoryListCreateForm.controls['severityName'].setValue(selectedSeverity.severityName);
        this.categoryListCreateForm.controls['severityid'].setValue(selectedSeverity.severityid);
      }
    }      
  }
}

  selectItGroup($event){
    let itGroup = this.categoryListCreateForm.value.itGroupSelect;
    if (itGroup.length > 2) {
      if ($event.timeStamp > 200) {
        let selectedITGroup = this.itGroupList.find(data => data.itGroupName == itGroup);
        if (selectedITGroup) {
          this.categoryListCreateForm.controls['itGroupid'].setValue(selectedITGroup.itGroupid);
        }
      }      
    }
  }

openCategoryDialog(){
  const dialogConfig = new MatDialogConfig;
  dialogConfig.width = '600px';
  this.dialog.open(CategoryComponent, dialogConfig);
}

openSeverityDialog(){
  const dialogConfig = new MatDialogConfig;
  dialogConfig.width = '650px';
  this.dialog.open(SeverityComponent, dialogConfig);
}

openITGroupDialog(){
  const dialogConfig = new MatDialogConfig;
  dialogConfig.width = '600px';
  this.dialog.open(ItgroupComponent, dialogConfig);
}

async validateSLA(){
  var slarpt = this.categoryListCreateForm.controls['slaResponseTime']
  var slarst = this.categoryListCreateForm.controls['slaResolvedTime']
  if( slarpt == slarst || slarpt > slarst ){
    alert("Inputted value is greater than other!")
    this.isValid = false;
  } else {
    this.isValid = true;
  }
}

reset(){
  this.categoryListCreateForm.reset();
}
}

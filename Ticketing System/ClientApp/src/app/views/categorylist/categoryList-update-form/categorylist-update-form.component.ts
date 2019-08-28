import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CategoryList } from 'src/app/models/categoryList.model';
import { CategoryListService } from 'src/app/services/categoryList.service';
import { CategoryListDataService } from 'src/app/dataservices/categoryList.dataservice';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogConfig, MatDialog } from '@angular/material';
import { Severity } from 'src/app/models/severity.model';
import { Itgroup } from 'src/app/models/itgroup.model';
import { Category } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';
import { CategoryDataService } from 'src/app/dataservices/category.dataservice';
import { SeverityService } from 'src/app/services/severity.service';
import { SeverityDataService } from 'src/app/dataservices/severity.dataservice';
import { ItgroupService } from 'src/app/services/itgroup.service';
import { ItgroupDataService } from 'src/app/dataservices/itgroup.dataservice';
import { CategoryComponent } from '../../category/category.component';
import { SeverityComponent } from '../../severity/severity.component';
import { ItgroupComponent } from '../../itgroup/itgroup.component';

@Component({
  selector: 'app-categoryList-update-form',
  templateUrl: './categoryList-update-form.component.html',
  styleUrls: ['./categoryList-update-form.component.css']
})
export class CategoryListUpdateFormComponent implements OnInit {
 
  isSubmit = false;

  categoryListContext:any;
  categoryListUpdateform: FormGroup;
  categoryListToBeEdited:CategoryList;

  categoryList: Category[];
  severityList: Severity[];
  itGroupList: Itgroup[];
  initialized = false;

  constructor(
    private categoryListService: CategoryListService,
    private categoryListDataService: CategoryListDataService,
    public dialogRef:MatDialogRef<CategoryListUpdateFormComponent>,
    private categoryService: CategoryService,
    private categoryDataService: CategoryDataService,
    private severityService: SeverityService,
    private severityDataService: SeverityDataService,
    private itgroupService: ItgroupService,
    private itgroupDataService: ItgroupDataService,
    private dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) data

  ) {
    this .categoryListUpdateform = new FormGroup({
      categoryListid: new FormControl(),
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
      this.categoryListContext = data;
   }
  
  ngOnInit() {
    this.categoryListToBeEdited = this.categoryListContext.categoryListContext;
    this.categoryDataService.categorySource.subscribe(async data => {
      await this.getCategoryLists();
      if(!this.initialized){
        this.change()
        this.initialized = true;
      }
    });
  }
  get f() {return this.categoryListUpdateform.controls;}

  change(){
    this.categoryListUpdateform.controls['categoryListName'].setValue(this.categoryListToBeEdited.categoryListName),
    this.categoryListUpdateform.controls['categoryType'].setValue(this.categoryListToBeEdited.categoryType),
    this.categoryListUpdateform.controls['slaResponseTime'].setValue(this.categoryListToBeEdited.slaResponseTime),
    this.categoryListUpdateform.controls['slaResolvedTime'].setValue(this.categoryListToBeEdited.slaResolvedTime),
    this.categoryListUpdateform.controls['slaResponseTimeExt'].setValue(this.categoryListToBeEdited.slaResponseTimeExt),
    this.categoryListUpdateform.controls['slaResolvedTimeExt'].setValue(this.categoryListToBeEdited.slaResolvedTimeExt),
    this.categoryListUpdateform.controls['severityid'].setValue(this.categoryListToBeEdited.severityid);
    let severityCode = this.severityList.find(data => data.severityid === this.categoryListToBeEdited.severityid);
    this.categoryListUpdateform.controls['severitySelect'].setValue(severityCode.severityCode);
    this.categoryListUpdateform.controls['severityName'].setValue(severityCode.severityName);
    
    this.categoryListUpdateform.controls['categoryid'].setValue(this.categoryListToBeEdited.categoryid);
    let categoryName = this.categoryList.find(data => data.categoryid === this.categoryListToBeEdited.categoryid);
    this.categoryListUpdateform.controls['categorySelect'].setValue(categoryName.categoryName);

    this.categoryListUpdateform.controls['itGroupid'].setValue(this.categoryListToBeEdited.itGroupid);
    let itGroupName = this.itGroupList.find(data => data.itGroupid === this.categoryListToBeEdited.itGroupid);
    this.categoryListUpdateform.controls['itGroupSelect'].setValue(itGroupName.itGroupName);
  }
  close(){
    this.dialogRef.close();
  }
  async onFormSubmit(){
    let ok = confirm("Are you sure you want to submit?");

    if(!ok){
      return;
    }
    if(!this.categoryListUpdateform.valid)
    return;

    try{
      this.isSubmit=true;
      this.categoryListUpdateform.value.categoryListid=this.categoryListToBeEdited.categoryListid;
      let result = await this.categoryListService.update(this.categoryListUpdateform.value).toPromise();
      if(result.isSuccess){
        alert(result.message);
        this.categoryListUpdateform.reset();
        this.categoryListDataService.refreshCategorylists();
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
    this.isSubmit = false;
  }  finally{
      this.isSubmit= false;
  }
}

async getCategoryLists(){
  try {
    this.categoryList = await this.categoryService.getAll().toPromise();
    this.severityList = await this.severityService.getAll().toPromise();
    this.itGroupList = await this.itgroupService.getGroups().toPromise();
  } catch (error) {
    console.log(error);
  }
}

selectCategory($event){
  let category = this.categoryListUpdateform.value.categorySelect;
  if (category.length > 2) {
    if ($event.timeStamp > 200) {
      let selectedCategory = this.categoryList.find(data => data.categoryName == category);
      if (selectedCategory) {
        this.categoryListUpdateform.controls['categoryid'].setValue(selectedCategory.categoryid);
      }
    }      
  }
}

selectSeverity($event){
  let severity = this.categoryListUpdateform.value.severitySelect;
  
  //console.log(this.severityList.values);
  if (severity.length > 0) {
    if ($event.timeStamp > 200) {
      let selectedSeverity = this.severityList.find(data => data.severityCode == severity);
      if (selectedSeverity) {
        this.categoryListUpdateform.controls['severityName'].setValue(selectedSeverity.severityName);
        this.categoryListUpdateform.controls['severityid'].setValue(selectedSeverity.severityid);
      }
    }      
  }
}

  selectItGroup($event){
    let itGroup = this.categoryListUpdateform.value.itGroupSelect;
    if (itGroup.length > 2) {
      if ($event.timeStamp > 200) {
        let selectedITGroup = this.itGroupList.find(data => data.itGroupName == itGroup);
        if (selectedITGroup) {
          this.categoryListUpdateform.controls['itGroupid'].setValue(selectedITGroup.itGroupid);
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


}

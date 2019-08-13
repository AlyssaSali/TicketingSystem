import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CategoryList } from 'src/app/models/categoryList.model';
import { CategoryListService } from 'src/app/services/categoryList.service';
import { CategoryListDataService } from 'src/app/dataservices/categoryList.dataservice';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-categoryList-update-form',
  templateUrl: './categoryList-update-form.component.html',
  styleUrls: ['./categoryList-update-form.component.css']
})
export class CategoryListUpdateFormComponent implements OnInit {
 
  isSubmit = false;

   categoryListidBackEndErrors: number[];
   categoryListNameBackEndErrors: string[];
  

  categoryListContext:any;
  categoryListUpdateform: FormGroup;
  categoryListToBeEdited:CategoryList;

  constructor(
    private categoryListService: CategoryListService,
    private categoryListDataService: CategoryListDataService,
    public dialogRef:MatDialogRef<CategoryListUpdateFormComponent>,
    @Inject(MAT_DIALOG_DATA) data

  ) {
    this .categoryListUpdateform = new FormGroup({
       categoryListName: new FormControl('',[Validators.required,Validators.maxLength(50)]),
       categoryName: new FormControl('',[Validators.required,Validators.maxLength(50)]),
       severityCode: new FormControl('',[Validators.required,Validators.maxLength(50)]),
       slaResponseTime: new FormControl('',[Validators.required,Validators.maxLength(50)]),
       slaResolvedTime: new FormControl('',[Validators.required,Validators.maxLength(50)]),
       itGroup: new FormControl('',[Validators.required,Validators.maxLength(50)]),
    })
      this.categoryListContext = data;
   }
  
  ngOnInit() {
    this.categoryListToBeEdited = this.categoryListContext.categoryListContext;
    this.change();
  }
  get f() {return this.categoryListUpdateform.controls;}

  change(){
    this.categoryListUpdateform.controls['categoryListName'].setValue(this.categoryListToBeEdited.categoryListName)
    this.categoryListUpdateform.controls['categoryName'].setValue(this.categoryListToBeEdited.categoryName)
    this.categoryListUpdateform.controls['severityCode'].setValue(this.categoryListToBeEdited.severityCode)
    this.categoryListUpdateform.controls['slaResponseTime'].setValue(this.categoryListToBeEdited.slaResponseTime)
    this.categoryListUpdateform.controls['slaResolvedTime'].setValue(this.categoryListToBeEdited.slaResolvedTime)
    this.categoryListUpdateform.controls['itGroup'].setValue(this.categoryListToBeEdited.itGroup)
   
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
      this.categoryListNameBackEndErrors=null;
      
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
      if(errs.errors){
        if('categoryListName' in errs.errors){
          this.categoryListNameBackEndErrors=errs.errors.categoryListName;
        }
        
    }
    this.isSubmit = false;
  }  finally{
      this.isSubmit= false;
  }
}

}

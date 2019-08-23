import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Category } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';
import { CategoryDataService } from 'src/app/dataservices/category.dataservice';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-category-update-form',
  templateUrl: './category-update-form.component.html',
  styleUrls: ['./category-update-form.component.css']
})
export class CategoryUpdateFormComponent implements OnInit {
 
  isSubmit = false;

   categoryidBackEndErrors: number[];
   categoryNameBackEndErrors: string[];
  

  categoryContext:any;
  categoryUpdateform: FormGroup;
  categoryToBeEdited:Category;

  constructor(
    private categoryService: CategoryService,
    private categoryDataService: CategoryDataService,
    public dialogRef:MatDialogRef<CategoryUpdateFormComponent>,
    @Inject(MAT_DIALOG_DATA) data

  ) {
    this .categoryUpdateform = new FormGroup({
      categoryid: new FormControl(),
      categoryName: new FormControl('',[Validators.required,Validators.maxLength(50)]),
      
      
    })
      this.categoryContext = data;
   }
  
  ngOnInit() {
    this.categoryToBeEdited = this.categoryContext.categoryContext;
    this.change();
  }
  get f() {return this.categoryUpdateform.controls;}

  change(){
    this.categoryUpdateform.controls['categoryName'].setValue
    (this.categoryToBeEdited.categoryName)
   
  }
  
  async onFormSubmit(){
    let ok = confirm("Are you sure you want to submit?");

    if(!ok){
      return;
    }
    if(!this.categoryUpdateform.valid)
    return;

    try{
      this.isSubmit=true;
      this.categoryNameBackEndErrors=null;
      
      this.categoryUpdateform.value.categoryid=this.categoryToBeEdited.categoryid;
      

      let result = await this.categoryService.update(this.categoryUpdateform.value).toPromise();
      if(result.isSuccess){
        alert(result.message);
        this.categoryUpdateform.reset();
        this.categoryDataService.refreshCategorys();
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
        if('categoryName' in errs.errors){
          this.categoryNameBackEndErrors=errs.errors.categoryName;
        }
        
    }
    this.isSubmit = false;
  }  finally{
      this.isSubmit= false;
  }
}

close(){
  this.dialogRef.close();
}

}

import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/models/category.model';
import { CategoryService } from 'src/app/services/category.service';
import { CategoryDataService } from 'src/app/dataservices/category.dataservice';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material';
import { CategoryUpdateFormComponent } from './category-update-form/category-update-form.component';
import { CategoryAddFormComponent } from './category-add-form/category-add-form.component';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  categories:Category[];

  constructor(
    private categoryService: CategoryService,
    private categoryDataService: CategoryDataService,
    private dialogRef: MatDialogRef<CategoryAddFormComponent>,
    public dialog:MatDialog,
    
  ) { }

  ngOnInit() {
    this.categoryDataService.categories.subscribe(data =>{
      this.getCategorys();
    })
  }
  async getCategorys() {
    try{

      this.categories=await this.categoryService.getAll().toPromise();
    }catch(error){
      alert('Something went wrong!');
      console.error(error);
    }
  }
    async delete(categoryid){
      if(confirm('Are you sure you want to delete?')){
        try{
          let result= await this.categoryService.delete(categoryid).toPromise()
          if(result.isSuccess){
            alert(result.message)
            this.categoryDataService.refreshCategorys();
          }else{
            alert(result.message)
          }
          }catch(error){
            alert('Something went wrong');
            console.log(error)
          }
        }
      
    }
    update(category){
      const dialogConfig = new MatDialogConfig();
      dialogConfig.data={
        categoryContext:category
      };
      dialogConfig.width = '400px';
      dialogConfig.panelClass = 'custom-modalbox';
      this.dialog.open(CategoryUpdateFormComponent,dialogConfig)
    }

    close(){
      this.dialogRef.close();
    }

    // filterDate() {
    //   var re = /\/Date\(([0-9]*)\)\//;
    //   return function(x) {
    //       var m = x.match(re);
    //       if( m ) return new Date(parseInt(m[1]));
    //       else return null;
    //   };
    // }

}

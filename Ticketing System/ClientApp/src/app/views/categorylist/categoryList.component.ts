import { Component, OnInit, ViewChild } from '@angular/core';
import { CategoryList } from 'src/app/models/categoryList.model';
import { CategoryListService } from 'src/app/services/categoryList.service';
import { CategoryListDataService } from 'src/app/dataservices/categoryList.dataservice';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { CategoryListUpdateFormComponent } from './categoryList-update-form/categoryList-update-form.component';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-categoryList',
  templateUrl: './categoryList.component.html',
  styleUrls: ['./categoryList.component.css']
})
export class CategoryListComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  dtElement: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<CategoryList> = new Subject();
  
  categoryLists:CategoryList[];

  constructor(
    private categoryListService: CategoryListService,
    private categoryListDataService: CategoryListDataService,
    public dialog:MatDialog,
    
  ) { }

  ngOnInit() {
    this.categoryListDataService.categoryLists.subscribe(data =>{
      this.getCategoryLists();
    })
  }
  async getCategoryLists() {
    try{
      this.categoryLists=await this.categoryListService.getAll().toPromise();
      this.rerender();
    }catch(error){
      alert('Something went wrong!');
      console.error(error);
    }
  }
    async delete(categoryListid){
      if(confirm('Are you sure you want to delete?')){
        try{
          let result= await this.categoryListService.delete(categoryListid).toPromise()
          if(result.isSuccess){
            alert(result.message)
            this.categoryListDataService.refreshCategorylists();
          }else{
            alert(result.message)
          }
          }catch(error){
            alert('Something went wrong');
            console.log(error)
          }
        }
      
    }
    update(categoryList){
      const dialogConfig = new MatDialogConfig();
      dialogConfig.data={
        categoryListContext:categoryList
      };
      dialogConfig.width = '600';
      dialogConfig.panelClass = 'custom-modalbox';
      this.dialog.open(CategoryListUpdateFormComponent,dialogConfig)
    }

    ngAfterViewInit(): void {
      this.dtTrigger.next();
    }
  
    ngOnDestroy(): void {
      // Do not forget to unsubscribe the event
      this.dtTrigger.unsubscribe();
    }
    
    rerender(): void {
      this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        // Destroy the table first
        dtInstance.destroy();
        // Call the dtTrigger to rerender again
        this.dtTrigger.next();
      });
    }

}

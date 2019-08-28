import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { TicketSLAService } from 'src/app/services/ticketSLA.service';
import { TicketSLA } from 'src/app/models/ticketSLA.model';
import { TicketSLADataService } from 'src/app/dataservices/ticketSLA.dataservice';
import { CategoryListService } from 'src/app/services/categoryList.service';
import { CategoryListDataService } from 'src/app/dataservices/categoryList.dataservice';
import { CategoryService } from 'src/app/services/category.service';
import { CategoryDataService } from 'src/app/dataservices/category.dataservice';
import { TicketMinorDataService } from 'src/app/dataservices/ticketMinor.dataservice';
import { TicketMinorService } from 'src/app/services/ticketMinor.service';
import { Category } from 'src/app/models/category.model';
import { CategoryList } from 'src/app/models/categoryList.model';
import { ItgroupService } from 'src/app/services/itgroup.service';
import { Itgroup } from 'src/app/models/itgroup.model';

@Component({
  selector: 'app-ticket-SLA',
  templateUrl: './ticket-SLA.component.html',
  styleUrls: ['./ticket-SLA.component.css']
})
export class TicketSLAComponent implements OnInit {
  isSubmit = false;

  ticketSLAContext:any;
  ticketSLAform: FormGroup;
  ticketSLAToBeEdited:TicketSLA;

  requestCategory: Category[];
  categoryList: CategoryList[];
  categoryid: string;
  itGroupList: Itgroup[]

  constructor(
    private ticketSLAService: TicketSLAService,
    private ticketSLADataService: TicketSLADataService,
    private categoryListService: CategoryListService,
    private categoryService: CategoryService,
    private itGroupService: ItgroupService,
    public dialogRef:MatDialogRef<TicketSLAComponent>,
    //@Inject(MAT_DIALOG_DATA) data
  ) {
    this .ticketSLAform = new FormGroup({
      ticketSLAid: new FormControl(),
      categoryid: new FormControl(''),
      categorySelect: new FormControl(''),
      categoryListid: new FormControl(''),
      categoryListSelect: new FormControl(''),
      isUrgentYes: new FormControl(''),
      isUrgentNo: new FormControl(''),
      severity: new FormControl(''),
      itGroupid: new FormControl(''),
      itGroupName: new FormControl(''),
      slaResponseTime: new FormControl(''),
      slaResolvedTime: new FormControl(''),
    })
      // this.ticketSLAContext = data;
   }
  
  ngOnInit() {
    this.ticketSLADataService.ticketSLASource.subscribe( data => { 
      this.getRequestCategoryLists(); 
      this.getCategoryLists();
      this.getItGroupLists();
    });
  }
  get f() {return this.ticketSLAform.controls;}

  change(){
    this.dialogRef.close();
  }
  async onFormSubmit(){
    let ok = confirm("Are you sure you want to submit?");

    if(!ok){
      return;
    }
    if(!this.ticketSLAform.valid)
    return;

    try{
      this.isSubmit=true;
      this.ticketSLAform.value.ticketSLAid=this.ticketSLAToBeEdited.ticketSLAid;
      

      let result = await this.ticketSLAService.update(this.ticketSLAform.value).toPromise();
      if(result.isSuccess){
        alert(result.message);
        this.ticketSLAform.reset();
        this.ticketSLADataService.refreshTicketSLAs();
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

async getRequestCategoryLists(){
  try {
    this.requestCategory = await this.categoryService.getAll().toPromise();
  } catch (error) {
    console.log(error);
  }
}

async getCategoryLists(){
  try {
    this.categoryList = await this.categoryListService.getAll().toPromise();
   // this.categoryList = this.categoryList.filter(x => x.category.categoryid == this.ticketSLAform.value.categoryid)
  } catch (error) {
    console.log(error);
  }
}

async getItGroupLists(){
  try {
    this.itGroupList = await this.itGroupService.getGroups().toPromise();
    this.itGroupList = this.itGroupList.filter(x => x.itGroupid == this.ticketSLAform.value.itGroupid);
  } catch (error) {
    console.log(error);
  }
}

selectCategory($event){
  let category = this.ticketSLAform.value.categorySelect;
  if (category.length > 2) {
    if ($event.timeStamp > 200) {
      let selectedCategory = this.requestCategory.find(data => data.categoryName == category);
      if (selectedCategory) {
        this.ticketSLAform.controls['categoryid'].setValue(selectedCategory.categoryid);
        //this.getCategoryLists();
        this.getItGroupLists()
      }
    }      
  }
}

selectCategoryList($event){
  let categoryList = this.ticketSLAform.value.categoryListSelect;
  if (categoryList.length > 2) {
    if ($event.timeStamp > 200) {
      let selectedCategoryList = this.categoryList.find(data => data.categoryListName == categoryList);
      if (selectedCategoryList) {
        this.ticketSLAform.controls['categoryListid'].setValue(selectedCategoryList.categoryListid);
        this.ticketSLAform.controls['severity'].setValue(selectedCategoryList.severity.severityName);
        this.ticketSLAform.controls['itGroupid'].setValue(selectedCategoryList.itGroupid);
        this.getItGroupLists()
        this.ticketSLAform.controls['slaResponseTime'].setValue(selectedCategoryList.slaResponseTime + " " + selectedCategoryList.slaResponseTimeExt);
        this.ticketSLAform.controls['slaResolvedTime'].setValue(selectedCategoryList.slaResolvedTime + " " + selectedCategoryList.slaResolvedTimeExt);
      }
    }      
  }
}


}

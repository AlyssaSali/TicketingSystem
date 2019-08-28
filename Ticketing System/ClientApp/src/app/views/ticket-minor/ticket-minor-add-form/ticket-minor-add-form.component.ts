import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ThrowStmt } from '@angular/compiler';
import { MatDialogRef, MatDialog, MatDialogConfig } from '@angular/material';
import { Employee } from 'src/app/models/employee.model';
import { Office } from 'src/app/models/office.model';
import { CategoryList } from 'src/app/models/categoryList.model';
import { OfficeDataService } from 'src/app/dataservices/office.dataservice';
import { OfficeService } from 'src/app/services/office.service';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { EmployeeService } from 'src/app/services/employee.service';
import { CategoryListService } from 'src/app/services/categoryList.service';
import { CategoryListDataService } from 'src/app/dataservices/categoryList.dataservice';
import { TicketMinorDataService } from 'src/app/dataservices/ticketMinor.dataservice';
import { TicketMinorService } from 'src/app/services/ticketMinor.service';
import { Router } from '@angular/router';
import { OfficeComponent } from '../../office/office.component';
import { Itgroup } from 'src/app/models/itgroup.model';
import { Itgroupmember } from 'src/app/models/itgroupmember.model';
import { ItgroupmemberService } from 'src/app/services/itgroupmember.service';
import { ItgroupmemberDataService } from 'src/app/dataservices/itgroupmember.dataservice';

@Component({
  selector: 'app-ticket-minor-add-form',
  templateUrl: './ticket-minor-add-form.component.html',
  styleUrls: ['./ticket-minor-add-form.component.css']
})
export class TicketMinorAddFormComponent implements OnInit {
  ticketMinorCreateForm: FormGroup;
  isSubmit = false;

  officeList: Office[];
  itStaffList: Employee[];
  requesterList: Employee[];
  categoryList: CategoryList[];
  itGroupList: Itgroup[];
  itGroupMembers: Itgroupmember[];
  

  constructor(
    private ticketMinorService: TicketMinorService,
    private ticketMinorDataService: TicketMinorDataService,
    private officeService: OfficeService,
    private officeDataService: OfficeDataService,
    private employeeService: EmployeeService,
    private employeeDataService: EmployeeDataService,
    private categoryListService: CategoryListService,
    private categoryListDataService: CategoryListDataService,
    private itGroupMemberDataService: ItgroupmemberDataService,
    private itGroupMemberService: ItgroupmemberService,
    private dialog: MatDialog,
    public dialogRef:MatDialogRef<OfficeComponent>,

    private router: Router
    // public dialogRef: MatDialogRef<TicketEditFormComponent>
  ) { 
    this.ticketMinorCreateForm = new FormGroup({
      agentid: new FormControl(),
      description: new FormControl('', [Validators.required, Validators.maxLength(100000)]),
      status: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      workDone: new FormControl('', [Validators.required, Validators.maxLength(100000)]),
      dateOfRequest: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      timeOfRequest: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      officeid: new FormControl(),
      officeSelect: new FormControl(),
      requesterid: new FormControl(),
      requesterSelect: new FormControl(),
      workByid: new FormControl(),
      workBySelect: new FormControl(),
      categoryListid: new FormControl(),
      categoryListSelect: new FormControl(),
    })
  }

  ngOnInit() {
      this.officeDataService.officeSource.subscribe( data => { this.getOfficeLists(); });
      this.employeeDataService.employeeSource.subscribe( data => { this.getRequesterLists(); });
      this.employeeDataService.employeeSource.subscribe( data => { this.getITStaffLists(); });
      this.categoryListDataService.categoryListSource.subscribe( data => { this.getCategoryLists(); });
      // this.itGroupMemberDataService.itgroupmemberSource.subscribe( data => { this.getITGroupMembers(); });
  }

  get f() { return this.ticketMinorCreateForm.controls; }

  async onFormSubmit(){
    let ok = confirm ("Are you sure you want to submit?");

    if (!ok){
      return
    }

    if (!this.ticketMinorCreateForm.valid)
     return;

     try {
       this.isSubmit = true;
       let result = await this.ticketMinorService.create(this.ticketMinorCreateForm.value).toPromise();
      if (result.isSuccess) {
        alert(result.message);
        this.ticketMinorCreateForm.reset();
        this.router.navigate(["/ticketMinor"]);
      }
      else {
        alert(result.message);
      }
     } catch (error) {
       console.error(error)
       let errs = error.error

       if(errs.isSuccess === false){
        alert(errs.message);
        return;   
      }
        this.isSubmit = false;
     }  finally{
        this.isSubmit = false;
     }
  }

  async getOfficeLists(){
    try {
      this.officeList = await this.officeService.getAll().toPromise();
    } catch (error) {
      console.log(error);
    }
  }

  async getRequesterLists(){
    try {
      this.requesterList = await this.employeeService.ListEmployees().toPromise();
      this.requesterList = this.requesterList.filter(x => x.employeeType.employeeTypeName == 'Requester');
    } catch (error) {
      console.log(error);
    }
  }

  async getITStaffLists(){
    try {
      this.itStaffList = await this.employeeService.ListEmployees().toPromise();
    } catch (error) {
      console.log(error);
    }
  }

  async getCategoryLists(){
    try {
      this.categoryList = await this.categoryListService.getAll().toPromise();
      this.categoryList = await this.categoryList.filter(x => x.categoryType == 'Minor')
    } catch (error) {
      console.log(error);
    }
  }

  selectOffice($event){
    let office = this.ticketMinorCreateForm.value.officeSelect;
    if (office.length > 2) {
      if ($event.timeStamp > 200) {
        let selectedOffice = this.officeList.find(data => data.officeDesc == office);
        if (selectedOffice) {
          this.ticketMinorCreateForm.controls['officeid'].setValue(selectedOffice.officeid);
        }
      }      
    }
  }

  selectRequester($event){
    let employee = this.ticketMinorCreateForm.value.requesterSelect;
    if (employee.length > 2) {
      if ($event.timeStamp > 200) {
        let selectedEmployee = this.requesterList.find(data => data.fullName == employee);
        if (selectedEmployee) {
          this.ticketMinorCreateForm.controls['requesterid'].setValue(selectedEmployee.employeeID);
          this.ticketMinorCreateForm.controls['officeSelect'].setValue(selectedEmployee.office.officeDesc);
          let selectedOffice = this.officeList.find(data => data.officeDesc == this.ticketMinorCreateForm.value.officeSelect);
          if (selectedOffice) {
            this.ticketMinorCreateForm.controls['officeid'].setValue(selectedOffice.officeid);
          }
        }
      }      
    }
  }

  selectWorker($event){
    let employee = this.ticketMinorCreateForm.value.workBySelect;
    if (employee.length > 2) {
      if ($event.timeStamp > 200) {
        let selectedEmployee = this.itStaffList.find(data => data.fullName == employee);
        if (selectedEmployee) {
          this.ticketMinorCreateForm.controls['workByid'].setValue(selectedEmployee.employeeID);
        }
      }      
    }
  }

  selectCategoryList($event){
    let categoryList = this.ticketMinorCreateForm.value.categoryListSelect;
    if (categoryList.length > 2) {
      if ($event.timeStamp > 200) {
        let selectedCategoryList = this.categoryList.find(data => data.categoryListName == categoryList);
        if (selectedCategoryList) {
          this.ticketMinorCreateForm.controls['categoryListid'].setValue(selectedCategoryList.categoryListid);
          // let selectedITGroup = this.itGroupMembers.find(data => data.itGroupid == selectedCategoryList.itGroupid);
          // if (selectedITGroup) {
          //   this.getITGroupMembers(selectedITGroup.itGroupMemberid);
          // }
        }
      }      
    }
  }

  // async getITGroupMembers(itGroupMemberid){
  //   try {
  //     this.itGroupMembers = await this.itGroupMemberService.getAll().toPromise();
  //     this.itGroupMembers = this.itGroupMembers.filter(x => x.itGroupMemberid == itGroupMemberid);
  //   } catch (error) {
  //     console.log(error);
  //   }
  // }  

  reset(){
    this.ticketMinorCreateForm.reset();
  }

  loadPageEmployee(){
    this.router.navigate(["/employee"]);
  }
}

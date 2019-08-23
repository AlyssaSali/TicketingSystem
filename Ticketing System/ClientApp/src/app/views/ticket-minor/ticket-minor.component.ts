import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ThrowStmt } from '@angular/compiler';
import { MatDialogRef, MatDialog, MatDialogConfig } from '@angular/material';
import { TicketService } from 'src/app/services/ticket.service';
import { TicketDataService } from 'src/app/dataservices/ticket.dataservice';
import { OfficeComponent } from '../office/office.component';
import { OfficeAddFormComponent } from '../office/office-add-form/office-add-form.component';
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

@Component({
  selector: 'app-ticket-minor',
  templateUrl: './ticket-minor.component.html',
  styleUrls: ['./ticket-minor.component.css']
})
export class TicketMinorComponent implements OnInit {
  ticketMinorCreateForm: FormGroup;
  isSubmit = false;

  officeList: Office[];
  employeeList: Employee[];
  categoryList: CategoryList[];

  constructor(
    private ticketMinorService: TicketMinorService,
    private ticketMinorDataService: TicketMinorDataService,
    private officeService: OfficeService,
    private officeDataService: OfficeDataService,
    private employeeService: EmployeeService,
    private employeeDataService: EmployeeDataService,
    private categoryListService: CategoryListService,
    private categoryListDataService: CategoryListDataService,
    private dialog: MatDialog,
    public dialogRef:MatDialogRef<OfficeComponent>,

    private router: Router
    // public dialogRef: MatDialogRef<TicketEditFormComponent>
  ) { 
    this.ticketMinorCreateForm = new FormGroup({
      agentid: new FormControl(),
      description: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      status: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      workDone: new FormControl('', [Validators.required, Validators.maxLength(50)]),
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
      this.employeeDataService.employeeSource.subscribe( data => { this.getEmployeeLists(); });
      this.categoryListDataService.categoryListSource.subscribe( data => { this.getCategoryLists(); });
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
        this.router.navigate(["/dashboard"]);
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

  // openOfficeDialog(){//added during employee-office relationship
  //   const dialogConfig = new MatDialogConfig();
  //   dialogConfig.panelClass = 'custom-modalbox';
  //   this.dialog.open(OfficeAddFormComponent, dialogConfig);
  // }
  async getOfficeLists(){
    try {
      this.officeList = await this.officeService.getAll().toPromise();
    } catch (error) {
      console.log(error);
    }
  }

  async getEmployeeLists(){
    try {
      this.employeeList = await this.employeeService.ListEmployees().toPromise();
    } catch (error) {
      console.log(error);
    }
  }


  async getCategoryLists(){
    try {
      this.categoryList = await this.categoryListService.getAll().toPromise();
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
        let selectedEmployee = this.employeeList.find(data => data.fullName == employee);
        if (selectedEmployee) {
          this.ticketMinorCreateForm.controls['requesterid'].setValue(selectedEmployee.employeeID);
        }
      }      
    }
  }

  selectWorker($event){
    let employee = this.ticketMinorCreateForm.value.workBySelect;
    if (employee.length > 2) {
      if ($event.timeStamp > 200) {
        let selectedEmployee = this.employeeList.find(data => data.fullName == employee);
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
        }
      }      
    }
  }

  reset(){
    this.ticketMinorCreateForm.reset();
  }
}

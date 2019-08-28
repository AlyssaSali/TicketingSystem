import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { TicketMinor } from 'src/app/models/ticketMinor.model';
import { TicketMinorService } from 'src/app/services/ticketMinor.service';
import { TicketMinorDataService } from 'src/app/dataservices/ticketMinor.dataservice';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Employee } from 'src/app/models/employee.model';
import { CategoryList } from 'src/app/models/categoryList.model';
import { Office } from 'src/app/models/office.model';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { EmployeeService } from 'src/app/services/employee.service';
import { CategoryListService } from 'src/app/services/categoryList.service';
import { OfficeService } from 'src/app/services/office.service';

@Component({
  selector: 'app-ticket-minor-update-form',
  templateUrl: './ticket-minor-update-form.component.html',
  styleUrls: ['./ticket-minor-update-form.component.css']
})
export class TicketMinorUpdateFormComponent implements OnInit {
  ticketMinorContext:any;
  ticketMinorUpdateform: FormGroup;
  ticketMinorToBeViewed:TicketMinor;
  isSubmit = false;
  initialized = false;

  officeList: Office[];
  requesterList: Employee[];
  workerList: Employee[];
  employeeList: Employee[];
  categoryList: CategoryList[];
  ticketMinorList: TicketMinor[];

  constructor(
    private ticketMinorService: TicketMinorService,
    private ticketMinorDataService: TicketMinorDataService,
    private employeeService: EmployeeService,
    public dialogRef: MatDialogRef<TicketMinorUpdateFormComponent>,
    @Inject(MAT_DIALOG_DATA) data 
  ) { 
    this.ticketMinorUpdateform = new FormGroup({
      ticketMinorid: new FormControl(),
      status: new FormControl(),
      officeid: new FormControl(),
      requesterid: new FormControl(),
      categoryListid: new FormControl(),
      workByid: new FormControl(),
      workBySelect: new FormControl(),
      workDone: new FormControl('', [Validators.required, Validators.maxLength(50000)]),
      // dateAccomplished: new FormControl()
    })
      this.ticketMinorContext = data;
  }

  ngOnInit() {
    this.ticketMinorToBeViewed = this.ticketMinorContext.ticketMinorContext;
    this.getEmployeeLists();
    this.ticketMinorDataService.ticketMinorSource.subscribe(async data => {
      await this.getMinorLists();
      if(!this.initialized){
        this.change();
        this.initialized = true;
      }
    });
  }

  get f() {return this.ticketMinorUpdateform.controls; }

  change(){
    this.ticketMinorUpdateform.controls['status'].setValue(this.ticketMinorToBeViewed.status);
    this.ticketMinorUpdateform.controls['workDone'].setValue(this.ticketMinorToBeViewed.workDone);
    this.ticketMinorUpdateform.controls['officeid'].setValue(this.ticketMinorToBeViewed.officeid);
    this.ticketMinorUpdateform.controls['requesterid'].setValue(this.ticketMinorToBeViewed.requesterid);
    this.ticketMinorUpdateform.controls['categoryListid'].setValue(this.ticketMinorToBeViewed.categoryListid);
    this.ticketMinorUpdateform.controls['workByid'].setValue(this.ticketMinorToBeViewed.workByid);
    let workerid = this.ticketMinorUpdateform.value.workByid;
    let workedBy = this.employeeList.find(x => x.employeeID === workerid)
    if (workedBy){
      this.ticketMinorUpdateform.controls['workBySelect'].setValue(workedBy.fullName)
    }
  }

  close(){
    this.dialogRef.close();
  }

  async getMinorLists() {
    try{
      this.ticketMinorList = await this.ticketMinorService.getAll().toPromise();
      this.ticketMinorList = await this.ticketMinorList.filter(x => x.ticketMinorid == this.ticketMinorToBeViewed.ticketMinorid)
      this.getWorkerLists();
      this.getEmployeeLists();
    }catch(error){
      alert('Something went wrong!');
    }
  }

  async getEmployeeLists(){
    try{
      this.employeeList = await this.employeeService.ListEmployees().toPromise();
      // this.employeeList = this.employeeList.filter(x => x.employeeID == this.ticketMinorToBeViewed.workByid);
    }catch(error){
      alert('Something went wrong!');
      console.error(error);
    }
  }

  async getWorkerLists(){
    try {
      this.workerList = await this.employeeService.ListEmployees().toPromise();
      this.workerList = this.workerList.filter(x => x.employeeType.employeeTypeName == 'IT Staff');
    } catch (error) {
      console.log(error);
    }
  }

  selectWorker($event){
    let employee = this.ticketMinorUpdateform.value.workBySelect;
    if (employee.length > 2) {
      if ($event.timeStamp > 200) {
        let selectedEmployee = this.workerList.find(data => data.fullName == employee);
        if (selectedEmployee) {
          this.ticketMinorUpdateform.controls['workByid'].setValue(selectedEmployee.employeeID);
        }
      }      
    }
  }

  async onFormSubmit(){
    let ok = confirm("Are you sure you want to update?");

    if(!ok){
      return;
    }
    if(!this.ticketMinorUpdateform.valid)
    return;

    try{
      this.isSubmit = true
      this.ticketMinorUpdateform.value.ticketMinorid=this.ticketMinorToBeViewed.ticketMinorid;
      // this.dateAccomplished();
      let result = await this.ticketMinorService.update(this.ticketMinorUpdateform.value).toPromise();
      if(result.isSuccess){
        alert(result.message);
        this.ticketMinorUpdateform.reset();
        this.ticketMinorDataService.refreshTicketMinors();
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

  async dateAccomplished(){
    let status = this.ticketMinorUpdateform.controls.value.status;
    if( status == 'Close'){
        this.ticketMinorUpdateform.controls['dateAccomplished'].setValue(Date.now);
    }
  }

}

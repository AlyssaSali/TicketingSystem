import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ThrowStmt } from '@angular/compiler';
import { MatDialogRef, MatDialog, MatDialogConfig, MAT_DIALOG_DATA } from '@angular/material';
import { TicketEditFormComponent } from '../ticket-edit-form/ticket-edit-form.component';
import { TicketService } from 'src/app/services/ticket.service';
import { TicketDataService } from 'src/app/dataservices/ticket.dataservice';
import { Office } from 'src/app/models/office.model';
import { Employee } from 'src/app/models/employee.model';
import { OfficeService } from 'src/app/services/office.service';
import { OfficeDataService } from 'src/app/dataservices/office.dataservice';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { OfficeAddFormComponent } from '../../office/office-add-form/office-add-form.component';
import { Router } from '@angular/router';


@Component({
  selector: 'app-ticket-add-form',
  templateUrl: './ticket-add-form.component.html',
  styleUrls: ['./ticket-add-form.component.css']
})
export class TicketAddFormComponent implements OnInit {
  ticketCreateForm: FormGroup;
  isSubmit = false;

  officesList : Office[];
  employeesList : Employee[];
  constructor(
    private ticketService: TicketService,
    private ticketDataService: TicketDataService,
    private officeService: OfficeService,
    private officeDataService: OfficeDataService,
    private employeeService: EmployeeService,
    private employeeDataService: EmployeeDataService,
    private dialog: MatDialog,//added during employee-office relationship,
    public dialogRef:MatDialogRef<OfficeAddFormComponent>,
    private router: Router
  ) { 
    this.ticketCreateForm = new FormGroup({
      date: new FormControl(),
      time: new FormControl(),
      
      requestTitle: new FormControl('', [Validators.required]),
      requestDesc: new FormControl('', [Validators.required]),
      formOfCommu: new FormControl('', [Validators.required]),
      contactVia: new FormControl('', [Validators.required]),

      officeid: new FormControl('', Validators.required),
      officeSelect: new FormControl('', Validators.required),
      employeeid: new FormControl('', Validators.required),
      employeeSelect: new FormControl('', Validators.required)


    })
  }

  ngOnInit() {
    this.officeDataService.officeSource.subscribe( data => { this.getOfficesLists(); });
    this.employeeDataService.employeeSource.subscribe( data => { this.getEmployeesLists(); });  
  }

  get f() { return this.ticketCreateForm.controls; }

  async onFormSubmit(){
    alert(this.ticketCreateForm.controls['date'].value + " " + this.ticketCreateForm.controls['time'].value);
    let ok = confirm ("Are you sure you want to submit?");

    if (!ok){
      return
    }

    if (!this.ticketCreateForm.valid)
     return;

     try {
       this.isSubmit = true;
       let result = await this.ticketService.create(this.ticketCreateForm.value).toPromise();
      if (result.isSuccess) {
        alert(result.message);
        this.ticketCreateForm.reset();
        this.router.navigate(["/ticketEdit"])
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

  async getOfficesLists(){//added during employee-office relationship
    try {
      this.officesList = await this.officeService.getAll().toPromise();
    } catch (error) {
      console.log(error);
    }
  }

  async getEmployeesLists(){//added during employee-employeetype relationship
    try {
      this.employeesList = await this.employeeService.ListEmployees().toPromise();
    } catch (error) {
      console.log(error);
    }
  }

  selectOffice($event){//added during employee-office relationship
    let office = this.ticketCreateForm.value.officeSelect;
    if (office.length > 2) {
      if ($event.timeStamp > 200) {
        let selectedOffice = this.officesList.find(data => data.officeDesc == office);
        if (selectedOffice) {
          this.ticketCreateForm.controls['officeid'].setValue(selectedOffice.officeid);
          
        }
      }      
    }
  }

  selectEmployee($event){//added during employee-employeetype relationship
    let employee = this.ticketCreateForm.value.employeeSelect;
    if (employee.length > 2) {
      if ($event.timeStamp > 200) {
        let selectedEmployee = this.employeesList.find(data => data.fullName == employee);
        if (selectedEmployee) {
          this.ticketCreateForm.controls['employeeid'].setValue(selectedEmployee.employeeID);
          this.ticketCreateForm.controls['formOfCommu'].setValue(selectedEmployee.formOfCommu);
          this.ticketCreateForm.controls['contactVia'].setValue(selectedEmployee.contactInfo);          
        }
      }      
    }
  }

  openOfficeDialog(){//added during employee-office relationship
    const dialogConfig = new MatDialogConfig();
    dialogConfig.panelClass = 'custom-modalbox';
    this.dialog.open(OfficeAddFormComponent, dialogConfig);
  }

  close(){
    this.dialogRef.close();
  }

  reset(){
    this.ticketCreateForm.reset();
  }
}

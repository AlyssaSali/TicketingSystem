import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ThrowStmt } from '@angular/compiler';
import { MatDialogRef, MatDialog, MatDialogConfig, MAT_DIALOG_DATA } from '@angular/material';
import { TicketEditFormComponent } from '../ticket-edit-form/ticket-edit-form.component';
import { TicketService } from 'src/app/services/ticket.service';
import { TicketDataService } from 'src/app/dataservices/ticket.dataservice';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { OfficeDataService } from 'src/app/dataservices/office.dataservice';
import { EmployeeService } from 'src/app/services/employee.service';
import { OfficeService } from 'src/app/services/office.service';
import { Office } from 'src/app/models/office.model';
import { Employee } from 'src/app/models/employee.model';


@Component({
  selector: 'app-ticket-add-form',
  templateUrl: './ticket-add-form.component.html',
  styleUrls: ['./ticket-add-form.component.css']
})
export class TicketAddFormComponent implements OnInit {
  ticketCreateForm: FormGroup;
  isSubmit = false;

  dateRequestedBackEndErrors: string[];
  contactInfoBackEndErrors: string[];
  formOfCommuBackEndErrors: string[];
  CategoryBackEndErrors: string[];
  requestTitleBackEndErrors: string[];
  requestDescEndErrors: string[];
  severityBackEndErrors: string[];
  responseTimeInfoBackEndErrors: string[];
  resolveTimeInfoBackEndErrors: string[];
//added during employee-office relationship
  officesList : Office[];
  employeesList: Employee[];

  
  constructor(
    private ticketService: TicketService,
    private ticketDataService: TicketDataService,
    private employeeService: EmployeeService,
    private employeeDataService: EmployeeDataService,
    private officeService: OfficeService,
    private officeDataService: OfficeDataService,
    private dialog: MatDialog
  ) { 
    this.ticketCreateForm = new FormGroup({
      dateRequested: new FormControl(),
      contactInfo: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      formOfCommu: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      
      employeeid: new FormControl('', [Validators.required]),
      employeeSelect: new FormControl('', [Validators.required]),

      officeid: new FormControl('', [Validators.required]),
      officeSelect: new FormControl('', [Validators.required]),

      Category: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      requestTitle: new FormControl('', [Validators.required]),
      requestDesc: new FormControl('', [Validators.required]),
      severity: new FormControl('', [Validators.required]),
      responseTime: new FormControl('', [Validators.required]),
      resolveTime: new FormControl('', [Validators.required]),
      itGroup: new FormControl('', [Validators.required])
    })
  }

  ngOnInit() {
  }

  get f() { return this.ticketCreateForm.controls; }

  async onFormSubmit(){
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
        this.ticketDataService.refreshTickets();
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

}

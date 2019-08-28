import { Component, OnInit, ViewChild } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { TicketMinor } from 'src/app/models/ticketMinor.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { TicketService } from 'src/app/services/ticket.service';
import { TicketDataService } from 'src/app/dataservices/ticket.dataservice';
import { TicketMinorService } from 'src/app/services/ticketMinor.service';
import { TicketMinorDataService } from 'src/app/dataservices/ticketMinor.dataservice';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { Router } from '@angular/router';
import { Employee } from 'src/app/models/employee.model';
import { TicketMinorDetailsComponent } from '../ticket-minor/ticket-minor-details/ticket-minor-details.component';
import { TicketMinorUpdateFormComponent } from '../ticket-minor/ticket-minor-update-form/ticket-minor-update-form.component';

@Component({
  selector: 'app-ticket-history',
  templateUrl: './ticket-history.component.html',
  styleUrls: ['./ticket-history.component.css']
})
export class TicketHistoryComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  dtElement: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<TicketMinor> = new Subject();

  ticketMinorList: TicketMinor[];
  dialogOpen = false;
  ticketTableForm: FormGroup;

  search:any = {};
  filter :string = "All";
  statBar: boolean;

  ticketMinorContext:any;
  ticketMinorToBeViewed:TicketMinor;
  employeeList: Employee[];
  employeeid: string;

  constructor(
    private ticketMinorService: TicketMinorService,
    private ticketMinorDataService: TicketMinorDataService,
    private employeeService: EmployeeService,
    public dialog: MatDialog,
    private router: Router,
    // private toasterService: ToasterService
   ) {
     this.ticketTableForm = new FormGroup({
       txtSearch: new FormControl ('',[Validators.required]),
       btnApprove: new FormControl (''),
       txtStatus: new FormControl ('')
     })
   }

  ngOnInit() {
    this.ticketMinorDataService.ticketMinors.subscribe(data =>{
    this.getTicketMinorLists();
    this.getEmployeeLists();
    })
  }
  get f() {return this.ticketTableForm.controls;}

  async getTicketMinorLists(){
    try {
      this.ticketMinorList = await this.ticketMinorService.getAll().toPromise()
      this.ticketMinorList = this.ticketMinorList.filter(x => x.status == 'Close');
      this.rerender();
      // this.toasterService.popAsync('success', 'Product has been deleted Successfully!');
    } catch (error) {
      alert('something went wrong!');
      console.error(error);
    }
  }

  async getEmployeeLists() {
    try{
      this.employeeList = await this.employeeService.ListEmployees().toPromise();
    }catch(error){
      alert('Something went wrong!');
      console.error(error);
    }
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

    loadPage(){
      this.router.navigate(["/ticketAddMinor"]);
    }

    viewDetails(ticketMinor){
      const dialogConfig = new MatDialogConfig();
      dialogConfig.data={
        ticketMinorContext:ticketMinor
      };
      dialogConfig.panelClass = 'custom-modalbox';
      this.dialog.open(TicketMinorDetailsComponent,dialogConfig)
    }

    update(ticketMinor){
      const dialogConfig = new MatDialogConfig();
      dialogConfig.data={
        ticketMinorContext:ticketMinor
      };
      dialogConfig.panelClass = 'custom-modalbox';
      this.dialog.open(TicketMinorUpdateFormComponent,dialogConfig)
    }

    async delete(ticketMinorid){
      if(confirm('Are you sure you want to delete?')){
        try{
          let result= await this.ticketMinorService.delete(ticketMinorid).toPromise()
          if(result.isSuccess){
            alert(result.message)
            this.ticketMinorDataService.refreshTicketMinors();
          }else{
            alert(result.message)
          }
          }catch(error){
            alert('Something went wrong');
            console.log(error)
          }
        }
    }
  }

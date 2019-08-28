import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { TicketService } from 'src/app/services/ticket.service';
import { Ticket } from 'src/app/models/ticket.model';
import { MatDialogConfig, MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { TicketDataService } from 'src/app/dataservices/ticket.dataservice';
import { TicketMinor } from 'src/app/models/ticketMinor.model';
import { TicketMinorDataService } from 'src/app/dataservices/ticketMinor.dataservice';
import { TicketMinorService } from 'src/app/services/ticketMinor.service';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { Router } from '@angular/router';
import { TicketMinorUpdateFormComponent } from './ticket-minor-update-form/ticket-minor-update-form.component';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { TicketMinorDetailsComponent } from './ticket-minor-details/ticket-minor-details.component';

@Component({
  selector: 'app-ticket-minor',
  templateUrl: './ticket-minor.component.html',
  styleUrls: ['./ticket-minor.component.css']
})
export class TicketMinorComponent implements OnInit {
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
    private ticketService: TicketService,
    private ticketDataService: TicketDataService,
    private ticketMinorService: TicketMinorService,
    private ticketMinorDataService: TicketMinorDataService,
    private employeeService: EmployeeService,
    private employeeDataServvice: EmployeeDataService,
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
      this.ticketMinorList = this.ticketMinorList.filter(x => x.status == 'Open');
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

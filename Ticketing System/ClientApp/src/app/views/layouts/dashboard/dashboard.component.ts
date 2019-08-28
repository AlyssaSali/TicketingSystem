import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { TicketAddFormComponent } from '../../ticket/ticket-add-form/ticket-add-form.component';
import { TicketMinor } from 'src/app/models/ticketMinor.model';
import { TicketService } from 'src/app/services/ticket.service';
import { TicketDataService } from 'src/app/dataservices/ticket.dataservice';
import { TicketMinorService } from 'src/app/services/ticketMinor.service';
import { TicketMinorDataService } from 'src/app/dataservices/ticketMinor.dataservice';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { TicketMinorUpdateFormComponent } from '../../ticket-minor/ticket-minor-update-form/ticket-minor-update-form.component';
import { TicketMinorDetailsComponent } from '../../ticket-minor/ticket-minor-details/ticket-minor-details.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  dtElement: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<TicketMinor> = new Subject();
  
  ticketMinorList: TicketMinor[];
  filter: string = "All";
  employeeList: Employee[];

  constructor(
    private ticketService: TicketService,
    private ticketDataService: TicketDataService,
    private ticketMinorService: TicketMinorService,
    private ticketMinorDataService: TicketMinorDataService,
    private employeeService: EmployeeService,
    private employeeDataService: EmployeeDataService,
    public dialog: MatDialog,
  ) { }

  ngOnInit() {
    this.ticketMinorDataService.ticketMinors.subscribe(data =>{ this.getTicketMinorLists(this.filter); })
    this.employeeDataService.employees.subscribe(data =>{ this.getEmployeeLists(); })
  }

  async getTicketMinorLists(f){
    try {
      this.ticketMinorList = await this.ticketMinorService.getAll().toPromise();
      this.ticketMinorList=this.ticketMinorList.filter(x=>x.status=='Open');
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

  viewDetails(ticketMinor){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data={
      ticketMinorContext:ticketMinor
    };
    dialogConfig.panelClass = 'custom-modalbox';
    this.dialog.open(TicketMinorDetailsComponent,dialogConfig)
  }
}

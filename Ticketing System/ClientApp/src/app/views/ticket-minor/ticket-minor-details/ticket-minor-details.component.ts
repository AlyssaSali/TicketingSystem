import { Component, OnInit, Inject } from '@angular/core';
import { TicketMinor } from 'src/app/models/ticketMinor.model';
import { FormGroup, FormControl } from '@angular/forms';
import { Office } from 'src/app/models/office.model';
import { Employee } from 'src/app/models/employee.model';
import { CategoryList } from 'src/app/models/categoryList.model';
import { TicketMinorService } from 'src/app/services/ticketMinor.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogConfig, MatDialog } from '@angular/material';
import { TicketMinorUpdateFormComponent } from '../ticket-minor-update-form/ticket-minor-update-form.component';
import { TicketMinorDataService } from 'src/app/dataservices/ticketMinor.dataservice';

@Component({
  selector: 'app-ticket-minor-details',
  templateUrl: './ticket-minor-details.component.html',
  styleUrls: ['./ticket-minor-details.component.css']
})
export class TicketMinorDetailsComponent implements OnInit {
  ticketMinorContext:any;
  ticketMinorViewform: FormGroup;
  ticketMinorToBeViewed:TicketMinor;
  isSubmit= true;

  officeList: Office[];
  employeeList: Employee[];
  categoryList: CategoryList[];
  ticketMinorList: TicketMinor[];


  constructor(
    private ticketMinorService: TicketMinorService,
    private ticketMinorDataService: TicketMinorDataService,
    private employeeService: EmployeeService,
    public dialogRef: MatDialogRef<TicketMinorDetailsComponent>,
    public dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) data 
  ) {
    this.ticketMinorContext = data;
  }

  ngOnInit() {
    this.ticketMinorDataService.ticketMinors.subscribe(data =>{
      this.getMinorLists();
    })
    this.ticketMinorToBeViewed = this.ticketMinorContext.ticketMinorContext;
  }
  get f() {return this.ticketMinorViewform.controls; }

  close(){
    this.dialogRef.close();
  }

  async getMinorLists() {
    try{
      this.ticketMinorList = await this.ticketMinorService.getAll().toPromise();
      this.ticketMinorList = this.ticketMinorList.filter(x => x.ticketMinorid == this.ticketMinorToBeViewed.ticketMinorid);
      this.getEmployeeLists();
    }catch(error){
      alert('Something went wrong!');
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

  update(ticketMinor){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data={
      ticketMinorContext:ticketMinor
    };
    dialogConfig.panelClass = 'custom-modalbox';
    this.close();
    this.dialog.open(TicketMinorUpdateFormComponent,dialogConfig)
  }

}

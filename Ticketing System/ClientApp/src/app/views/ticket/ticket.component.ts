import { Component, OnInit } from '@angular/core';
import { TicketService } from 'src/app/services/ticket.service';
import { Ticket } from 'src/app/models/ticket.model';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { TicketDataService } from 'src/app/dataservices/ticket.dataservice';
<<<<<<< HEAD
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { OfficeDataService } from 'src/app/dataservices/office.dataservice';
=======
import { TicketMinor } from 'src/app/models/ticketMinor.model';
import { TicketMinorDataService } from 'src/app/dataservices/ticketMinor.dataservice';
import { TicketMinorService } from 'src/app/services/ticketMinor.service';
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {
  tickets: Ticket[];
  ticketMinorList: TicketMinor[];
  dialogOpen = false;
  ticketTableForm: FormGroup;

  search:any = {};

  constructor(
    private ticketService: TicketService,
    private ticketDataService: TicketDataService,
<<<<<<< HEAD
    private employeeDataService: EmployeeDataService,
    private officeDataService: OfficeDataService,
=======
    private ticketMinorService: TicketMinorService,
    private ticketMinorDataService: TicketMinorDataService,
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
    public dialog: MatDialog
   ) {
     this.ticketTableForm = new FormGroup({
       txtSearch: new FormControl ('',[Validators.required]),
       btnApprove: new FormControl (''),
     })
   }

  ngOnInit() {
    this.ticketMinorDataService.ticketMinors.subscribe(data =>{
      this.getTicketMinorLists();
    })
  }
  get f() {return this.ticketTableForm.controls;}

  async getTicketMinorLists(){
    try {
      this.ticketMinorList = await this.ticketMinorService.getAll().toPromise();
    } catch (error) {
      alert('something went wrong!');
      console.error(error);
    }
  }

  // async delete(id){
  //   if(confirm("Are you sure you want to delete?")){
  //     try{
  //       let result = await this.ticketService.delete(id).toPromise();
  //       if(result.isSuccess){
  //         alert(result.message)
  //         this.ticketDataService.refreshTickets();
  //       }  else {
  //         alert(result.message)
  //       }
  //     } catch (error) {
  //       alert("Something went wrong");
  //       console.log(error)
  //     }
  //   }
  // }
  }

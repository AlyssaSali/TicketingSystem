import { Component, OnInit } from '@angular/core';
import { TicketService } from 'src/app/services/ticket.service';
import { Ticket } from 'src/app/models/ticket.model';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { TicketDataService } from 'src/app/dataservices/ticket.dataservice';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {
  tickets: Ticket[];
  dialogOpen = false;
  ticketTableForm: FormGroup;

  search:any = {};

  constructor(
    private ticketService: TicketService,
    private ticketDataService: TicketDataService,
    public dialog: MatDialog
   ) {
     this.ticketTableForm = new FormGroup({
       txtSearch: new FormControl ('',[Validators.required]),
       btnApprove: new FormControl (''),
     })
   }

  ngOnInit() {
    // this.ticketDataService.tickets.subscribe( data => { this.getTickets();})
  }
  get f() {return this.ticketTableForm.controls;}

  // async getTickets(){
  //   try {
  //     this.tickets = await this.ticketService.getAll().toPromise();
  //   } catch (error) {
  //     alert('something went wrong!');
  //     console.error(error);
  //   }
  // }

  async delete(id){
    if(confirm("Are you sure you want to delete?")){
      try{
        let result = await this.ticketService.delete(id).toPromise();
        if(result.isSuccess){
          alert(result.message)
          this.ticketDataService.refreshTickets();
        }  else {
          alert(result.message)
        }
      } catch (error) {
        alert("Something went wrong");
        console.log(error)
      }
    }
  }
  }

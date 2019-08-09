import { Component, OnInit } from '@angular/core';
import { TicketService } from 'src/app/services/ticket.service';
import { TicketDataservice } from 'src/app/dataservices/ticket.dataservice';
import { Ticket } from 'src/app/models/ticket.model';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { TicketAddFormComponent } from './ticket-add-form/ticket-add-form.component';

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
    private ticketDataService: TicketDataservice,
    public dialog: MatDialog
   ) {
     this.ticketTableForm = new FormGroup({
       txtSearch: new FormControl ('',[Validators.required])
     })
   }

  ngOnInit() {
    // this.ticketDataService.tickets.subscribe( data => { this.getTickets();})
  }

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
          this.ticketDataService.refreshBooks();
        }  else {
          alert(result.message)
        }
      } catch (error) {
        alert("Something went wrong");
        console.log(error)
      }
    }
  }

  // createTicket(ticket){
  //   const dialogConfig = new MatDialogConfig();
  //   dialogConfig.data = {
  //     ticketContext: ticket
  //   };
  //   dialogConfig.width = '900px';
  //   // dialogConfig.height = '600px';
  //   this.dialog.open(TicketAddFormComponent, dialogConfig)
  // }

  // async onFormSubmit(){
  //     try {
  //       let result = await this.ticketService.goSearch(this.ticketTableForm.value).toPromise();  
  //     } catch(error) {
  //       console.error(error)
  //       let errs = error.error
  //     }
  //   }

    // onChange(){
    //   var ticketstore = this.tickets;
    //   JSON.stringify(this.search);
    //   // var this.search = JSON.stringify(this.search.value);
    //    if(this.search){
    //     ticketstore = ticketstore.filter(v => v.title == this.search || 
    //                                       v.genre.name == this.search ||
    //                                       v.author.firstname == this.search ||
    //                                       v.author.lastname == this.search ||
    //                                       v.copyright == this.search);
    //    }
    //     this.tickets = ticketstore;
    // }
  
    // resetFilter(){
    //   this.search = {};
    //   this.onChange();
    //   this.ticketDataService.refreshBooks();
    // }
  }

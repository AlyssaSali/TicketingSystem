import { Component, OnInit } from '@angular/core';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { TicketSLAComponent } from '../../ticket-SLA/ticket-SLA.component';
import { TicketApprovalComponent } from '../../ticket-approval/ticket-approval.component';

@Component({
  selector: 'app-ticket-edit-form',
  templateUrl: './ticket-edit-form.component.html',
  styleUrls: ['./ticket-edit-form.component.css']
})
export class TicketEditFormComponent implements OnInit {

  constructor(
    public dialog:MatDialog,
  ) { }

  ngOnInit() {
  }

  ticketSLA(ticket){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data={
      officeContext:ticket
    };
    dialogConfig.width='800px';
    //dialogConfig.height='600px';
    this.dialog.open(TicketSLAComponent,dialogConfig)
  }

  ticketApproval(ticket){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data={
      officeContext:ticket
    };
    dialogConfig.width='800px';
    //dialogConfig.height='600px';
    this.dialog.open(TicketApprovalComponent,dialogConfig)
  }
  

}

import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-ticket-approval',
  templateUrl: './ticket-approval.component.html',
  styleUrls: ['./ticket-approval.component.css']
})
export class TicketApprovalComponent implements OnInit {

  constructor(
    public dialogRef:MatDialogRef<TicketApprovalComponent>,
    @Inject(MAT_DIALOG_DATA) data
  ) { }

  ngOnInit() {
  }

  close(){
    this.dialogRef.close();
  }

}

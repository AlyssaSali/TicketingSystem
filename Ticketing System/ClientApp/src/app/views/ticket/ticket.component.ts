import { Component, OnInit, ViewChild } from '@angular/core';
import { TicketService } from 'src/app/services/ticket.service';
import { Ticket } from 'src/app/models/ticket.model';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { TicketDataService } from 'src/app/dataservices/ticket.dataservice';
import { TicketMinor } from 'src/app/models/ticketMinor.model';
import { TicketMinorDataService } from 'src/app/dataservices/ticketMinor.dataservice';
import { TicketMinorService } from 'src/app/services/ticketMinor.service';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  dtElement: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<Ticket> = new Subject();

  tickets: Ticket[];
  ticketMinorList: TicketMinor[];
  dialogOpen = false;
  ticketTableForm: FormGroup;

  search:any = {};

  constructor(
    private ticketService: TicketService,
    private ticketDataService: TicketDataService,
    private ticketMinorService: TicketMinorService,
    private ticketMinorDataService: TicketMinorDataService,
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
      this.rerender();
    } catch (error) {
      alert('something went wrong!');
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
  }

import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ThrowStmt } from '@angular/compiler';
import { MatDialogRef, MatDialog } from '@angular/material';
import { TicketDataservice } from 'src/app/dataservices/ticket.dataservice';
import { TicketEditFormComponent } from '../ticket-edit-form/ticket-edit-form.component';
import { TicketService } from 'src/app/services/ticket.service';

@Component({
  selector: 'app-ticket-add-form',
  templateUrl: './ticket-add-form.component.html',
  styleUrls: ['./ticket-add-form.component.css']
})
export class TicketAddFormComponent implements OnInit {
  ticketCreateForm: FormGroup;
  isSubmit = false;

  nameBackEndErrors: string[];

  constructor(
    private ticketService: TicketService,
    private ticketDataService: TicketDataservice,
    // public dialogRef: MatDialogRef<TicketEditFormComponent>
  ) { 
    this.ticketCreateForm = new FormGroup({
      date: new FormControl(),
      time: new FormControl(),
      emailAddress: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      formOfCommu: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      requestedBy: new FormControl('', [Validators.maxLength(50)]),
      office: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      requestCategory: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      requestSubCategory: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      requestTitle: new FormControl('', [Validators.required]),
      requestDesc: new FormControl('', [Validators.required]),
      severity: new FormControl('', [Validators.required]),
      responseTime: new FormControl('', [Validators.required]),
      resolveTime: new FormControl('', [Validators.required]),
      technician: new FormControl('', [Validators.required]),
      isUrgent: new FormControl()
    })
  }

  ngOnInit() {
  }

  get f() { return this.ticketCreateForm.controls; }

  async onFormSubmit(){
    let ok = confirm ("Are you sure you want to submit?");

    if (!ok){
      return
    }

    if (!this.ticketCreateForm.valid)
     return;

     try {
       this.isSubmit = true;
       this.nameBackEndErrors = null;
       let result = await this.ticketService.create(this.ticketCreateForm.value).toPromise();
      if (result.isSuccess) {
        alert(result.message);
        this.ticketCreateForm.reset();
        this.ticketDataService.refreshBooks();
      }
      else {
        alert(result.message);
      }
     } catch (error) {
       console.error(error)
       let errs = error.error

       if(errs.isSuccess === false){
        alert(errs.message);
        return;   
      }
      
      if(errs.error){
        if('name' in errs.errors) {
          this.nameBackEndErrors = errs.errors.name;
        }
        }

        this.isSubmit = false;
     }  finally{
        this.isSubmit = false;
     }
  }

  // close(){
  //     this.dialogRef.close();
  //   }
}

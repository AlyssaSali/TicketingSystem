import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { TicketSLAService } from 'src/app/services/ticketSLA.service';
import { TicketSLA } from 'src/app/models/ticketSLA.model';
import { TicketSLADataService } from 'src/app/dataservices/ticketSLA.dataservice';

@Component({
  selector: 'app-ticket-SLA',
  templateUrl: './ticket-SLA.component.html',
  styleUrls: ['./ticket-SLA.component.css']
})
export class TicketSLAComponent implements OnInit {
 
  isSubmit = false;

   ticketSLAidBackEndErrors: number[];
   ticketSLAcodeBackEndErrors: string[];
   ticketSLAdescBackEndErrors: string[];
  

  ticketSLAContext:any;
  ticketSLAUpdateform: FormGroup;
  ticketSLAToBeEdited:TicketSLA;

  constructor(
    private ticketSLAService: TicketSLAService,
    private ticketSLADataService: TicketSLADataService,
    // @Inject(MAT_DIALOG_DATA) data

  ) {
    this .ticketSLAUpdateform = new FormGroup({
      ticketSLAid: new FormControl(),
      ticketSLACode: new FormControl('',[Validators.required,Validators.maxLength(50)]),
      ticketSLADesc: new FormControl('',[Validators.required,Validators.maxLength(50)]),
      
      
    })
      // this.ticketSLAContext = data;
   }
  
  ngOnInit() {
    this.ticketSLAToBeEdited = this.ticketSLAContext.ticketSLAContext;
    this.change();
  }
  get f() {return this.ticketSLAUpdateform.controls;}

  change(){
    
   
  }
  async onFormSubmit(){
    let ok = confirm("Are you sure you want to submit?");

    if(!ok){
      return;
    }
    if(!this.ticketSLAUpdateform.valid)
    return;

    try{
      this.isSubmit=true;
      this.ticketSLAcodeBackEndErrors=null;
      this.ticketSLAdescBackEndErrors=null;
      
      this.ticketSLAUpdateform.value.ticketSLAid=this.ticketSLAToBeEdited.ticketSLAid;
      

      let result = await this.ticketSLAService.update(this.ticketSLAUpdateform.value).toPromise();
      if(result.isSuccess){
        alert(result.message);
        this.ticketSLAUpdateform.reset();
        this.ticketSLADataService.refreshTicketSLAs();
      }
      else{
        alert(result.message);  
      }
    }catch(error){
      console.error(error)
      let errs=error.error

      if(errs.isSuccess===false){
        alert(errs.message);
        return;
      }
      if(errs.errors){
        if('ticketSLACode' in errs.errors){
          this.ticketSLAcodeBackEndErrors=errs.errors.ticketSLACode;
        }
        
    }
    if(errs.errors){
      if('ticketSLADesc' in errs.errors){
        this.ticketSLAdescBackEndErrors=errs.errors.ticketSLADesc;
      }
      
  }
    this.isSubmit = false;
  }  finally{
      this.isSubmit= false;
  }
}

}

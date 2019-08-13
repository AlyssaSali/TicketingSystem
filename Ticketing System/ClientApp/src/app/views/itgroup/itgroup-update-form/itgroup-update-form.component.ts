import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ItgroupDataService } from 'src/app/dataservices/itgroup.dataservice';
import { ItgroupService } from 'src/app/services/itgroup.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Itgroup } from 'src/app/models/itgroup.model';

@Component({
  selector: 'app-itgroup-update-form',
  templateUrl: './itgroup-update-form.component.html',
  styleUrls: ['./itgroup-update-form.component.css']
})
export class ItgroupUpdateFormComponent implements OnInit {
 
    isSubmit = false;
  
     itgroupidBackEndErrors: number[];
     itgroupcodeBackEndErrors: string[];
     itgroupnameBackEndErrors: string[];
    
  
    itgroupContext:any;
    itgroupUpdateform: FormGroup;
    itgroupToBeEdited:Itgroup;
  
    constructor(
      private itgroupService: ItgroupService,
      private itgroupDataService: ItgroupDataService,
      public dialogRef:MatDialogRef<ItgroupUpdateFormComponent>,
      @Inject(MAT_DIALOG_DATA) data
  
    ) {
      this .itgroupUpdateform = new FormGroup({
        itgroupid: new FormControl(),
        itgroupCode: new FormControl('',[Validators.required,Validators.maxLength(50)]),
        itgroupName: new FormControl('',[Validators.required,Validators.maxLength(50)]),
        
        
      })
        this.itgroupContext = data;
     }
    
    ngOnInit() {
      this.itgroupToBeEdited = this.itgroupContext.itgroupContext;
      this.change();
    }
    get f() {return this.itgroupUpdateform.controls;}
  
    change(){
      this.itgroupUpdateform.controls['itgroupCode'].setValue
      (this.itgroupToBeEdited.itGroupCode)
      this.itgroupUpdateform.controls['itgroupName'].setValue
      (this.itgroupToBeEdited.itGroupName)
     
    }
    close(){
      this.dialogRef.close();
    }
    async onFormSubmit(){
      let ok = confirm("Are you sure you want to submit?");
  
      if(!ok){
        return;
      }
      if(!this.itgroupUpdateform.valid)
      return;
  
      try{
        this.isSubmit=true;
        this.itgroupcodeBackEndErrors=null;
        this.itgroupnameBackEndErrors=null;
        
        this.itgroupUpdateform.value.itgroupid=this.itgroupToBeEdited.itGroupid;
        
  
        let result = await this.itgroupService.update(this.itgroupUpdateform.value).toPromise();
        if(result.isSuccess){
          alert(result.message);
          this.itgroupUpdateform.reset();
          this.itgroupDataService.refreshItgroups();
          this.close();
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
          if('itgroupCode' in errs.errors){
            this.itgroupcodeBackEndErrors=errs.errors.itgroupCode;
          }
          
      }
      if(errs.errors){
        if('itgroupName' in errs.errors){
          this.itgroupnameBackEndErrors=errs.errors.itgroupName;
        }
        
    }
      this.isSubmit = false;
    }  finally{
        this.isSubmit= false;
    }
  }
  
  }
  

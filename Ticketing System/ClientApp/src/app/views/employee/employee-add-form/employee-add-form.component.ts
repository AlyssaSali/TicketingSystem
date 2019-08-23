import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { MatDialog, MatDialogConfig, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { OfficeService } from 'src/app/services/office.service';
import { OfficeDataService } from 'src/app/dataservices/office.dataservice';
import { Office } from 'src/app/models/office.model';
import { OfficeComponent } from '../../office/office.component';
import { EmployeeUpdateFormComponent } from '../employee-update-form/employee-update-form.component';
import { OfficeAddFormComponent } from '../../office/office-add-form/office-add-form.component';

@Component({
  selector: 'app-employee-add-form',
  templateUrl: './employee-add-form.component.html',
  styleUrls: ['./employee-add-form.component.css']
})
export class EmployeeAddFormComponent implements OnInit {
  employeeCreateForm: FormGroup;
  isSubmit = false;

  firstNameBackEndErrors: string[];
  lastNameBackEndErrors: string[];
  emailAddressBackEndErrors: string[];
  officeBackEndErrors: string[];
//added during employee-office relationship
  officesList : Office[];

  dialogOpen = false;
  router: any;
//added during employee-office relationship
  constructor(
    private employeeService: EmployeeService,
    private employeeDataService: EmployeeDataService,
    private officeService: OfficeService,//added during employee-office relationship
    private officeDataService: OfficeDataService,//added during employee-office relationship
    private dialog: MatDialog,//added during employee-office relationship,
    public dialogRef:MatDialogRef<OfficeAddFormComponent>,
    // @Inject(MAT_DIALOG_DATA) data
  ) { 
    //sets front-end max length
    this.employeeCreateForm = new FormGroup({
      firstname: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      lastname: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      emailaddress: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      //office: new FormControl('', [Validators.required, Validators.maxLength(50)])
      officeID: new FormControl('', Validators.required),//added during employee-office relationship
      officeSelect: new FormControl('', Validators.required)//added during employee-office relationship
    })
  }

  ngOnInit() {
    //added during employee-office relationship
    this.officeDataService.officeSource.subscribe( data => {
      this.getOfficeLists();
    });
    //added during employee-office relationship
  }

  get f() { return this.employeeCreateForm.controls; }

  async onFormSubmit() {
    let ok = confirm("are you sure you want to submit");
    //end function if user did not confirm
    if(!ok){
      return;
    }

    if(!this.employeeCreateForm.valid){
      return;
    }

    try{
      this.isSubmit = true;
      this.firstNameBackEndErrors = null;
      this.lastNameBackEndErrors = null;
      this.emailAddressBackEndErrors = null;
      this.officeBackEndErrors = null;
      let result = await this.employeeService.CreateEmployee(this.employeeCreateForm.value).toPromise();
      if(result.isSuccess){
        alert(result.message);
        this.employeeCreateForm.reset();
        this.employeeDataService.refreshEmployees();
        
      } 
      else {
        alert(result.message);
      }
    }
    catch(error){
      console.error(error);
      let errs = error.error

      if(errs.isSuccess===false){
        alert(errs.message);
        return;
      }

      if(errs.errors) {
        if('firstname' in errs.errors){
          this.firstNameBackEndErrors = errs.errors.firstname;//shows data annotations error message
        }
        if('firstname' in errs.errors){
          this.lastNameBackEndErrors = errs.errors.lastname;//shows data annotations error message
        }
        if('firstname' in errs.errors){
          this.emailAddressBackEndErrors = errs.errors.emailaddress;//shows data annotations error message
        }
        if('firstname' in errs.errors){
          this.officeBackEndErrors = errs.errors.itgroup;//shows data annotations error message
        }
      }

      this.isSubmit = false;//enables button
    }
    finally{
      this.isSubmit = false;//enables button
    }
  }

  async getOfficeLists(){//added during employee-office relationship
    try {
      this.officesList = await this.officeService.getAll().toPromise();
    } catch (error) {
      console.log(error);
    }
  }

  selectOffice($event){//added during employee-office relationship
    let office = this.employeeCreateForm.value.officeSelect;
    if (office.length > 2) {
      if ($event.timeStamp > 200) {
        let selectedOffice = this.officesList.find(data => data.officeCode == office);
        if (selectedOffice) {
          this.employeeCreateForm.controls['officeID'].setValue(selectedOffice.officeid);
        }
      }      
    }
  }

  openOfficeDialog(){//added during employee-office relationship
    const dialogConfig = new MatDialogConfig();
    dialogConfig.panelClass = 'custom-modalbox';
    this.dialog.open(OfficeAddFormComponent, dialogConfig);
  }

  close(){
    this.dialogRef.close();
  }

  reset(){
    this.employeeCreateForm.reset();
  }

}

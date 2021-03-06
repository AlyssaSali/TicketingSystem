import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { EmployeeService } from 'src/app/services/employee.service';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog, MatDialogConfig } from '@angular/material';
import { OfficeService } from 'src/app/services/office.service';
import { OfficeDataService } from 'src/app/dataservices/office.dataservice';
import { Office } from 'src/app/models/office.model';
import { OfficeComponent } from '../../office/office.component';
import { EmployeeType } from 'src/app/models/employeetype.model';
<<<<<<< HEAD
import { EmployeetypeComponent } from '../../employeetype/employeetype.component';
import { EmployeeTypeService } from 'src/app/services/employeetype.service';
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
=======
<<<<<<< HEAD
import { EmployeetypeComponent } from '../../employeetype/employeetype.component';
import { EmployeeTypeService } from 'src/app/services/employeetype.service';
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
=======
<<<<<<< HEAD
import { EmployeetypeComponent } from '../../employeetype/employeetype.component';
import { EmployeeTypeService } from 'src/app/services/employeetype.service';
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
=======
import { EmployeeTypeService } from 'src/app/services/employeetype.service';
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
import { EmployeetypeComponent } from '../../employeetype/employeetype.component';
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2

@Component({
  selector: 'app-employee-update-form',
  templateUrl: './employee-update-form.component.html',
  styleUrls: ['./employee-update-form.component.css']
})
export class EmployeeUpdateFormComponent implements OnInit {
  isSubmit=false;
  firstNameBackEndErrors: string[];
  lastNameBackEndErrors: string[];
<<<<<<< HEAD
  emailAddressBackEndErrors: string[];
  officeBackEndErrors: string[];
  //added during employee-office relationship
=======
<<<<<<< HEAD
  emailAddressBackEndErrors: string[];
  officeBackEndErrors: string[];
  //added during employee-office relationship
=======
<<<<<<< HEAD
  emailAddressBackEndErrors: string[];
  officeBackEndErrors: string[];
  //added during employee-office relationship
=======
  formOfCommuBackEndErrors: string[];
  contactInfoBackEndErrors: string[];

>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
  employeeContext: any;
  employeeUpdateForm: FormGroup;
  employeeToBeEdited: Employee;
  //added during employee-office relationship
  officesList : Office[];
  initialized = false;
  //added during employee-office relationship

  //added during employee-employeetype relationship
<<<<<<< HEAD
  // employeeTypesList : EmployeeType[];
=======
  employeeTypesList : EmployeeType[];
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
  //added during employee-employeetype relationship
  constructor(
    private employeeService: EmployeeService,
    private employeeDataService: EmployeeDataService,
    private officeService: OfficeService,//added during employee-office relationship
<<<<<<< HEAD
    private officeDataService: OfficeDataService,//added during employee-office relationship\
=======
<<<<<<< HEAD
    private officeDataService: OfficeDataService,//added during employee-office relationship\
=======
<<<<<<< HEAD
    private officeDataService: OfficeDataService,//added during employee-office relationship\
    // private employeeTypeService: EmployeeTypeService,//added during employee-employeetype relationship
    // private employeeTypeDataService: EmployeeTypeDataService,//added during employee-employeetype relationship
=======
    private officeDataService: OfficeDataService,//added during employee-office relationship
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
    private employeeTypeService: EmployeeTypeService,//added during employee-employeetype relationship
    private employeeTypeDataService: EmployeeTypeDataService,//added during employee-employeetype relationship
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
    private dialog: MatDialog,//added during employee-office relationship
    public dialogRef: MatDialogRef<EmployeeUpdateFormComponent>,
    @Inject(MAT_DIALOG_DATA) data
  ) {
    this.employeeUpdateForm = new FormGroup({
      employeeid: new FormControl(),
      firstname: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      lastname: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      formofcommu: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      contactinfo: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      //office: new FormControl('', [Validators.required, Validators.maxLength(50)])
      officeID: new FormControl('', Validators.required),//added during employee-office relationship
      officeSelect: new FormControl('', Validators.required),//added during employee-office relationship
<<<<<<< HEAD
      // employeetypeID: new FormControl('', Validators.required),//added during employee-employeetype relationship
      // employeetypeSelect: new FormControl('', Validators.required)//added during employee-employeetype relationship
=======
      employeetypeID: new FormControl('', Validators.required),//added during employee-employeetype relationship
      employeetypeSelect: new FormControl('', Validators.required)//added during employee-employeetype relationship
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
    });
    this.employeeContext = data;
   }

  async ngOnInit() {
    this.employeeToBeEdited = this.employeeContext.employeeContext;
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
    this.employeeDataService.employeeSource.subscribe(async data => {
      await this.getEmployeeLists();
      if(!this.initialized){
        this.change()
        this.initialized = true;
      }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
    //this.change();
    //added during employee-office relationship
    //to show updated office list when office is updated
    this.employeeDataService.employeeSource.subscribe( data=> {
      this.getOfficeEmployeeTypeLists();//added during employee-employeetype relationship
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
    });
  }

  get f() { return this.employeeUpdateForm.controls; }

  change(){
    this.employeeUpdateForm.controls['firstname'].setValue(this.employeeToBeEdited.firstName);
    this.employeeUpdateForm.controls['lastname'].setValue(this.employeeToBeEdited.lastName);
    this.employeeUpdateForm.controls['formofcommu'].setValue(this.employeeToBeEdited.formOfCommu);
    this.employeeUpdateForm.controls['contactinfo'].setValue(this.employeeToBeEdited.contactInfo);
    //this.employeeUpdateForm.controls['office'].setValue(this.employeeToBeEdited.office);

    //added during employee-office relationship
    this.employeeUpdateForm.controls['officeID'].setValue(this.employeeToBeEdited.officeid);
    let officeCode = this.officesList.find(data => data.officeid === this.employeeToBeEdited.officeid);
    this.employeeUpdateForm.controls['officeSelect'].setValue(officeCode.officeCode);
    //added during employee-office relationship

    //added during employee-employeetype relationship
<<<<<<< HEAD
    // this.employeeUpdateForm.controls['employeetypeID'].setValue(this.employeeToBeEdited.employeeTypeid);
    // let employeeTypeCode = this.employeeTypesList.find(data => data.employeeTypeid === this.employeeToBeEdited.employeeTypeid);
    // this.employeeUpdateForm.controls['employeetypeSelect'].setValue(employeeTypeCode.employeeTypeName);
=======
    this.employeeUpdateForm.controls['employeetypeID'].setValue(this.employeeToBeEdited.employeeTypeid);
    let employeeTypeCode = this.employeeTypesList.find(data => data.employeeTypeid === this.employeeToBeEdited.employeeTypeid);
    this.employeeUpdateForm.controls['employeetypeSelect'].setValue(employeeTypeCode.employeeTypeName);
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
    //added during employee-employeetype relationship
  }

  close(){
    this.dialogRef.close();
  }

  async onFormSubmit() {
    let ok = confirm("are you sure you want to submit");
    //end function if user did not confirm
    if(!ok){
      return;
    }

    if(!this.employeeUpdateForm.valid){
      return;
    }

    try{
      this.isSubmit = true;
      this.firstNameBackEndErrors = null;
      this.lastNameBackEndErrors = null;
      this.emailAddressBackEndErrors = null;
      this.officeBackEndErrors = null;
      this.employeeUpdateForm.value.employeeid = this.employeeToBeEdited.employeeID;
      let result = await this.employeeService.UpdateEmployee(this.employeeUpdateForm.value).toPromise();
      if(result.isSuccess){
        alert(result.message);
        this.employeeUpdateForm.reset();
        this.employeeDataService.refreshEmployees();
        this.close();
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
          this.officeBackEndErrors = errs.errors.office;//shows data annotations error message
        }
      }

      this.isSubmit = false;//enables button
    }
    finally{
      this.isSubmit = false;//enables button
    }
  }

<<<<<<< HEAD
  async getEmployeeLists(){
    try {
      this.officesList = await this.officeService.getAll().toPromise();
      this.employeeTypesList = await this.employeeTypeService.getAll().toPromise();
=======
<<<<<<< HEAD
  async getEmployeeLists(){
    try {
      this.officesList = await this.officeService.getAll().toPromise();
      this.employeeTypesList = await this.employeeTypeService.getAll().toPromise();
=======
<<<<<<< HEAD
  async getEmployeeLists(){
    try {
      this.officesList = await this.officeService.getAll().toPromise();
      // this.employeeTypesList = await this.employeeTypeService.getAll().toPromise();
=======
  async getOfficeEmployeeTypeLists(){
    try {
      this.officesList = await this.officeService.getAll().toPromise();
      this.employeeTypesList = await this.employeeTypeService.getAll().toPromise();
      if (!this.initialized) {
        this.change();
        this.initialized;
      }
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
    } catch (error) {
      console.log(error);
    }
  }

  selectOffice($event){//added during employee-office relationship
    let office = this.employeeUpdateForm.value.officeSelect;
    if (office.length > 2) {
      if ($event.timeStamp > 200) {
        let selectedOffice = this.officesList.find(data => data.officeCode == office);
        if (selectedOffice) {
          this.employeeUpdateForm.controls['officeID'].setValue(selectedOffice.officeid);
        }
      }      
    }
  }

<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
  // selectEmployeeType($event){//added during employee-employeetype relationship
  //   let emptype = this.employeeUpdateForm.value.employeetypeSelect;
  //   if (emptype.length > 2) {
  //     if ($event.timeStamp > 200) {
  //       let selectedEmployeeType = this.employeeTypesList.find(data => data.employeeTypeName == emptype);
  //       if (selectedEmployeeType) {
  //         this.employeeUpdateForm.controls['employeetypeID'].setValue(selectedEmployeeType.employeeTypeid);
  //       }
  //     }      
  //   }
  // }
=======

>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
  selectEmployeeType($event){//added during employee-employeetype relationship
    let emptype = this.employeeUpdateForm.value.employeetypeSelect;
    if (emptype.length > 2) {
      if ($event.timeStamp > 200) {
        let selectedEmployeeType = this.employeeTypesList.find(data => data.employeeTypeName == emptype);
        if (selectedEmployeeType) {
          this.employeeUpdateForm.controls['employeetypeID'].setValue(selectedEmployeeType.employeeTypeid);
        }
      }      
    }
  }
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4

  openOfficeDialog(){//added during employee-office relationship
    const dialogConfig = new MatDialogConfig;
    dialogConfig.width = '600px';
    dialogConfig.height = '600px';
    this.dialog.open(OfficeComponent, dialogConfig);
  }

<<<<<<< HEAD
  // openEmployeeTpyeDialog(){//added during employee-office relationship
  //   const dialogConfig = new MatDialogConfig;
  //   dialogConfig.width = '600px';
  //   dialogConfig.height = '600px';
  //   this.dialog.open(EmployeetypeComponent, dialogConfig);
  // }
=======
  openEmployeeTpyeDialog(){//added during employee-office relationship
    const dialogConfig = new MatDialogConfig;
    dialogConfig.width = '600px';
    dialogConfig.height = '600px';
    this.dialog.open(EmployeetypeComponent, dialogConfig);
  }
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
}



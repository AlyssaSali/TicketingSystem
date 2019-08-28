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
<<<<<<< HEAD
import { EmployeeType } from 'src/app/models/employeetype.model';
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
import { EmployeeTypeService } from 'src/app/services/employeetype.service';
=======
<<<<<<< HEAD
import { EmployeeType } from 'src/app/models/employeetype.model';
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
import { EmployeeTypeService } from 'src/app/services/employeetype.service';
=======
<<<<<<< HEAD
import { EmployeeType } from 'src/app/models/employeetype.model';
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
import { EmployeeTypeService } from 'src/app/services/employeetype.service';
=======
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2

@Component({
  selector: 'app-employee-add-form',
  templateUrl: './employee-add-form.component.html',
  styleUrls: ['./employee-add-form.component.css']
})
export class EmployeeAddFormComponent implements OnInit {
  employeeCreateForm: FormGroup;
  isSubmit = false;
<<<<<<< HEAD
//added during employee-office relationship
  officesList : Office[];
  employeeTypesList : EmployeeType[];

=======
<<<<<<< HEAD
//added during employee-office relationship
  officesList : Office[];
  employeeTypesList : EmployeeType[];

=======
<<<<<<< HEAD
//added during employee-office relationship
  officesList : Office[];
  employeeTypesList : EmployeeType[];

=======

  firstNameBackEndErrors: string[];
  lastNameBackEndErrors: string[];
  formOfCommuBackEndErrors: string[];
  contactInfoBackEndErrors: string[];
//added during employee-office relationship
  officesList : Office[];
  
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
  dialogOpen = false;
  router: any;
//added during employee-office relationship
  constructor(
    private employeeService: EmployeeService,
    private employeeDataService: EmployeeDataService,
<<<<<<< HEAD
    private employeeTypeService: EmployeeTypeService,
    private employeeTypeDataService: EmployeeTypeDataService,
=======
<<<<<<< HEAD
    private employeeTypeService: EmployeeTypeService,
    private employeeTypeDataService: EmployeeTypeDataService,
=======
    // private employeeTypeService: EmployeeTypeService,
    // private employeeTypeDataService: EmployeeTypeDataService,
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
    private officeService: OfficeService,//added during employee-office relationship
    private officeDataService: OfficeDataService,//added during employee-office relationship
    private dialog: MatDialog,//added during employee-office relationship,
    // public dialogRef:MatDialogRef<OfficeAddFormComponent>,
    // @Inject(MAT_DIALOG_DATA) data
  ) { 
    //sets front-end max length
    this.employeeCreateForm = new FormGroup({
      firstname: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      lastname: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      formofcommu: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      contactinfo: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      //office: new FormControl('', [Validators.required, Validators.maxLength(50)])
      officeID: new FormControl('', Validators.required),//added during employee-office relationship
      officeSelect: new FormControl('', Validators.required),//added during employee-office relationship
<<<<<<< HEAD
      // employeetypeID: new FormControl('', Validators.required),//added during employee-office relationship
      // employeetypeSelect: new FormControl('', Validators.required)//added during employee-office relationship
=======
      employeetypeID: new FormControl('', Validators.required),//added during employee-office relationship
      employeetypeSelect: new FormControl('', Validators.required)//added during employee-office relationship
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
    })
  }

  ngOnInit() {
    //added during employee-office relationship
<<<<<<< HEAD
    this.officeDataService.officeSource.subscribe( data => { this.getOfficeLists(); });
    this.employeeTypeDataService.employeeTypeSource.subscribe( data => { this.getEmployeeTypeLists(); });  
=======
<<<<<<< HEAD
    this.officeDataService.officeSource.subscribe( data => { this.getOfficeLists(); });
    this.employeeTypeDataService.employeeTypeSource.subscribe( data => { this.getEmployeeTypeLists(); });  
=======
<<<<<<< HEAD
    this.officeDataService.officeSource.subscribe( data => { this.getOfficeLists(); });
    // this.employeeTypeDataService.employeeTypeSource.subscribe( data => { this.getEmployeeTypeLists(); });  
    // //added during employee-office relationship
=======
    this.officeDataService.officeSource.subscribe( data => {
      this.getOfficeLists();
      this.getEmployeeTypeLists();      
    });
    
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
    //added during employee-office relationship
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
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
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
      this.firstNameBackEndErrors = null;
      this.lastNameBackEndErrors = null;
      this.formOfCommuBackEndErrors = null;
      this.contactInfoBackEndErrors = null;
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
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

<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
      if(errs.errors) {
        if('firstname' in errs.errors){
          this.firstNameBackEndErrors = errs.errors.firstname;//shows data annotations error message
        }
        if('lastname' in errs.errors){
          this.lastNameBackEndErrors = errs.errors.lastname;//shows data annotations error message
        }
        if('formofcommu' in errs.errors){
          this.formOfCommuBackEndErrors = errs.errors.formofcommu;//shows data annotations error message
        }
        if('contactinfo' in errs.errors){
          this.contactInfoBackEndErrors = errs.errors.contactinfo;//shows data annotations error message
        }
        
      }

>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
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

<<<<<<< HEAD
  // async getEmployeeTypeLists(){//added during employee-employeetype relationship
  //   try {
  //     this.employeeTypesList = await this.employeeTypeService.getAll().toPromise();
  //   } catch (error) {
  //     console.log(error);
  //   }
  // }
=======
  async getEmployeeTypeLists(){//added during employee-employeetype relationship
    try {
      this.employeeTypesList = await this.employeeTypeService.getAll().toPromise();
    } catch (error) {
      console.log(error);
    }
  }
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4

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

  selectEmployeeType($event){//added during employee-employeetype relationship
    let emptype = this.employeeCreateForm.value.employeetypeSelect;
    if (emptype.length > 2) {
      if ($event.timeStamp > 200) {
        let selectedEmployeeType = this.employeeTypesList.find(data => data.employeeTypeName == emptype);
        if (selectedEmployeeType) {
          this.employeeCreateForm.controls['employeetypeID'].setValue(selectedEmployeeType.employeeTypeid);          
        }
      }      
    }
  }

  // selectEmployeeType($event){//added during employee-employeetype relationship
  //   let emptype = this.employeeCreateForm.value.employeetypeSelect;
  //   if (emptype.length > 2) {
  //     if ($event.timeStamp > 200) {
  //       let selectedEmployeeType = this.employeeTypesList.find(data => data.employeeTypeName == emptype);
  //       if (selectedEmployeeType) {
  //         this.employeeCreateForm.controls['employeetypeID'].setValue(selectedEmployeeType.employeeTypeid);          
  //       }
  //     }      
  //   }
  // }

  openOfficeDialog(){//added during employee-office relationship
    const dialogConfig = new MatDialogConfig();
    dialogConfig.panelClass = 'custom-modalbox';
    this.dialog.open(OfficeAddFormComponent, dialogConfig);
  }

<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
  // close(){
  //   this.dialogRef.close();
  // }
=======
<<<<<<< HEAD
  openEmployeeTypeDialog(){//added during employee-employeetype relationship
    const dialogConfig = new MatDialogConfig;
    dialogConfig.width = '600px';
    dialogConfig.height = '600px';
    this.dialog.open(EmployeetypeComponent, dialogConfig);
  }
=======
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
  close(){
    this.dialogRef.close();
  }
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4

  reset(){
    this.employeeCreateForm.reset();
  }

}

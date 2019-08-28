import { Component, OnInit, Inject } from '@angular/core';
import { EmployeeEmployeeType } from 'src/app/models/employee-employee-type.model';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeEmployeeTypeDataService } from 'src/app/dataservices/employee-employee-type.dataservice';
import { EmployeeEmployeeTypeService } from 'src/app/services/employee-employee-type.service';
import { EmployeeTypeService } from 'src/app/services/employeetype.service';
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatDialogConfig } from '@angular/material';
import { EmployeeType } from 'src/app/models/employeetype.model';
import { EmployeetypeComponent } from '../../employeetype/employeetype.component';
import { EmployeeComponent } from '../../employee/employee.component';

@Component({
  selector: 'app-employee-employee-type-update-form',
  templateUrl: './employee-employee-type-update-form.component.html',
  styleUrls: ['./employee-employee-type-update-form.component.css']
})
export class EmployeeEmployeeTypeUpdateFormComponent implements OnInit {

  isSubmit = false;
  

  employeeEmployeeTypeContext: any;
  employeeEmployeeTypeUpdateForm: FormGroup;
  employeeEmployeeTypeToBeEditted: EmployeeEmployeeType;

  employeeTypesList: EmployeeType[];
  initialized = false;
  
  employeesList: Employee[];
  selectedEmployees: Employee[] = [];

  constructor(
    private employeeEmployeeTypeService: EmployeeEmployeeTypeService,
    private employeeEmployeeTypeDataService: EmployeeEmployeeTypeDataService,
    private employeeTypeService: EmployeeTypeService,
    private employeeTypeDataService: EmployeeTypeDataService,
    private employeeService: EmployeeService,
    private employeeDataService: EmployeeDataService,
    private dialog: MatDialog,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<EmployeeEmployeeTypeUpdateFormComponent>,
    @Inject(MAT_DIALOG_DATA) data
  ) { 
    this.employeeEmployeeTypeUpdateForm = this.formBuilder.group({
      employeeEmployeeTypeid: new FormControl(''),
      employeeTypeid: new FormControl('',Validators.required),
      employeeTypeSelect: new FormControl('',Validators.required),

      employeeID: new FormControl(''),
      employeeSelect: new FormControl(''),
      employeeIdList: this.formBuilder.array([])
    })
    this.employeeEmployeeTypeContext = data;
  }

  get f() { return this.employeeEmployeeTypeUpdateForm.controls;}

  async ngOnInit() {
    this.employeeEmployeeTypeToBeEditted = this.employeeEmployeeTypeContext.employeeEmployeeTypeContext;
    this.employeeTypeDataService.employeeTypeSource.subscribe(async data => {
      await this.getEmployeeTypeLists();
      if(!this.initialized){
        this.change()
        this.initialized = true;
      }
    })
    this.employeeDataService.employeeSource.subscribe(async data => {
      await this.getEmployeeLists();
      if(!this.initialized){
        this.change()
        this.initialized = true;
      }
    })

  }
  
  change(){
    this.employeeEmployeeTypeUpdateForm.controls['employeeTypeid'].setValue(this.employeeEmployeeTypeToBeEditted.employeeTypeid);
    // this.itgroupmemberUpdateForm.controls['employeeID'].setValue(this.itgroupmemberToBeEditted.employeeID);

   let employeeTypeName = this.employeeTypesList.find(data => data.employeeTypeid === this.employeeEmployeeTypeToBeEditted.employeeTypeid)
    this.employeeEmployeeTypeUpdateForm.controls['employeeTypeSelect'].setValue(employeeTypeName.employeeTypeName);
    this.selectedEmployees = this.employeeEmployeeTypeToBeEditted.employees;
    console.log(this.selectedEmployees)
    console.log(this.employeeEmployeeTypeUpdateForm.value)
  }

  close(){
    this.dialogRef.close();
  }

  async onFormSubmit() {
    let ok = confirm("Are you sure you want to submit?");
    if(!ok){
      return; 
    }

    if (!this.employeeEmployeeTypeUpdateForm.valid)
      return;
      
    try {
      this.isSubmit = true; // sets the isSubmit, disables button
      this.employeeEmployeeTypeUpdateForm.value.employeeEmployeeTypeid = this.employeeEmployeeTypeToBeEditted.employeeEmployeeTypeid;
      this.employeeEmployeeTypeUpdateForm.value.employeeIdList = this.selectedEmployees.map(data => {return data.employeeID})
      let result = await this.employeeEmployeeTypeService.update(this.employeeEmployeeTypeUpdateForm.value).toPromise();
      if (result.isSuccess) {
        alert(result.message);
        this.employeeEmployeeTypeUpdateForm.reset();
        this.employeeEmployeeTypeDataService.refreshEmployeeEmployeeTypes(); // triggers a function that will refresh other component that subscribe to it
        this.close();
      }
      else {
        alert(result.message);
      }
    } catch (error) {
      console.error(error)
      let errs = error.error
      
      if(errs.isSuccess === false){
        alert(errs.message); // shows the customed error message
        return;
      } 
      

      this.isSubmit = false; // resets the isSubmit, enables button
    } finally{
      this.isSubmit = false; // resets the isSubmit, enables button
    }
  }

  async getEmployeeLists(){
    try {
      this.employeesList = await this.employeeService.ListEmployees().toPromise();
    } catch (error) {
      console.log(error);
    }

  }
  async getEmployeeTypeLists(){
    try {
      this.employeeTypesList = await this.employeeTypeService.getAll().toPromise();
    } catch (error) {
      console.log(error);
    }
  }

 
  selectEmployeeType($event){
    let employeeType = this.employeeEmployeeTypeUpdateForm.value.employeeTypeSelect;
    if (employeeType.length >= 2) {
      if ($event.timeStamp > 200) {
        let selectedEmployeeType = this.employeeTypesList.find(data => data.employeeTypeName == employeeType);
        if(selectedEmployeeType){
          this.employeeEmployeeTypeUpdateForm.controls['employeeTypeid'].setValue(selectedEmployeeType.employeeTypeid);
        }
      }
    }
  }


 selectEmployee($event){
  let employee = this.employeeEmployeeTypeUpdateForm.value.employeeSelect;
  if (employee.length > 2) {
    if ($event.timeStamp > 200) {
      let selectedEmployee = this.employeesList.find(data => data.fullName == employee);
      if(selectedEmployee){
        
        if(!this.selectedEmployees.some(data => data === selectedEmployee))
          this.selectedEmployees.push(selectedEmployee);
      }
    }
  }
}


 removeEmployee(employee){

  let newEmployeeLists = this.selectedEmployees.filter(data => data != employee );
  this.selectedEmployees = newEmployeeLists
}

openEmployeeTypeDialog(){
  const dialogConfig = new MatDialogConfig();
  
  dialogConfig.width = '600px';
  dialogConfig.height = '600px';
  this.dialog.open(EmployeetypeComponent, dialogConfig)
}

openEmployeeDialog(){
  const dialogConfig = new MatDialogConfig();
  
  dialogConfig.width = '600px';
  dialogConfig.height = '600px';
  this.dialog.open(EmployeeComponent, dialogConfig)
}
 
}

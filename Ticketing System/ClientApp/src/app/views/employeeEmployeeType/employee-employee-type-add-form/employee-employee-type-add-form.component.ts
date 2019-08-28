import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { EmployeeType } from 'src/app/models/employeetype.model';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeEmployeeTypeService } from 'src/app/services/employee-employee-type.service';
import { EmployeeEmployeeTypeDataService } from 'src/app/dataservices/employee-employee-type.dataservice';
import { EmployeeTypeService } from 'src/app/services/employeetype.service';
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { EmployeeComponent } from '../../employee/employee.component';
import { EmployeetypeComponent } from '../../employeetype/employeetype.component';

@Component({
  selector: 'app-employee-employee-type-add-form',
  templateUrl: './employee-employee-type-add-form.component.html',
  styleUrls: ['./employee-employee-type-add-form.component.css']
})
export class EmployeeEmployeeTypeAddFormComponent implements OnInit {

  employeeEmployeeTypeCreateForm: FormGroup;
  isSubmit = false;

  

  employeeTypesList: EmployeeType[];
  selectedEmployeeTypes: EmployeeType[] = [];
  dialogOpen = false;

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
    private formBuilder: FormBuilder
  ) { 
    this.employeeEmployeeTypeCreateForm = this.formBuilder.group({
      employeeTypeid: new FormControl(''),
      employeeTypeSelect: new FormControl(''),

      employeeID: new FormControl(''),
      employeeSelect: new FormControl(''),
      employeeIdList: this.formBuilder.array([])
    })
  }

  ngOnInit() {
    this.employeeTypeDataService.employeeTypeSource.subscribe(data => {
      this.getEmployeeTypeLists();
    })
    this.employeeDataService.employeeSource.subscribe(data => {
      this.getEmployeeLists();
    })
  }
 
  get f() { return this.employeeEmployeeTypeCreateForm.controls; }
 
  async onFormSubmit() {
    let ok = confirm("Are you sure you want to submit?");
    if(!ok){
      return; 
    }
    if (!this.employeeEmployeeTypeCreateForm.valid){
      return;
  }
    try {
      this.isSubmit = true; 

      if(this.selectedEmployees){                                       
        this.employeeEmployeeTypeCreateForm.value.employeeIdList = this.selectedEmployees.map(data => {return data.employeeID})
      }
      let result = await this.employeeEmployeeTypeService.create(this.employeeEmployeeTypeCreateForm.value).toPromise();
      if (result.isSuccess) {
        alert(result.message);
        this.employeeEmployeeTypeCreateForm.reset();
        this.selectedEmployees = [];
        this.employeeEmployeeTypeDataService.refreshEmployeeEmployeeTypes(); 
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
     

      this.isSubmit = false; 
    } finally{
      this.isSubmit = false; 
    }
  }

  async getEmployeeTypeLists(){
    try {
      this.employeeTypesList = await this.employeeTypeService.getAll().toPromise();
    } catch (error) {
      console.log(error);
    }
  }

  async getEmployeeLists(){
    try {
      this.employeesList = await this.employeeService.ListEmployees().toPromise();
    } catch (error) {
      console.log(error);
    }
  }
  selectEmployeeType($event){
    let employeeType = this.employeeEmployeeTypeCreateForm.value.employeeTypeSelect;
    if (employeeType.length >= 2) {
      if ($event.timeStamp > 200) {
        let selectedEmployeeType = this.employeeTypesList.find(data => data.employeeTypeName == employeeType);
        
        if(selectedEmployeeType){
          this.employeeEmployeeTypeCreateForm.controls['employeeTypeid'].setValue(selectedEmployeeType.employeeTypeid);
        }
      }
    }
  }

  selectEmployee($event){
    let employee = this.employeeEmployeeTypeCreateForm.value.employeeSelect;
    if (employee.length >= 2) {
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
    
    dialogConfig.width = '700px';
    this.dialog.open(EmployeeComponent, dialogConfig)
  }
}

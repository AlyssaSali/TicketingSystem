import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl, FormBuilder } from '@angular/forms';
import { Employee } from 'src/app/models/employee.model';
import { Itgroup } from 'src/app/models/itgroup.model';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { ItgroupService } from 'src/app/services/itgroup.service';
import { ItgroupDataService } from 'src/app/dataservices/itgroup.dataservice';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { ItgroupmemberService } from 'src/app/services/itgroupmember.service';
import { ItgroupmemberDataService } from 'src/app/dataservices/itgroupmember.dataservice';
import { EmployeeComponent } from '../../employee/employee.component';
import { ItgroupComponent } from '../../itgroup/itgroup.component';

@Component({
  selector: 'app-itgroupmember-add-form',
  templateUrl: './itgroupmember-add-form.component.html',
  styleUrls: ['./itgroupmember-add-form.component.css']
})
export class ItgroupmemberAddFormComponent implements OnInit {
  itgroupmemberCreateForm: FormGroup;
  isSubmit = false;

  

  itgroupsList: Itgroup[];
  selectedItgroups: Itgroup[] = [];
  dialogOpen = false;

  employeesList: Employee[];
  selectedEmployees: Employee[] = [];

  constructor(
    private itgroupmemberService: ItgroupmemberService,
    private itgroupmemberDataService: ItgroupmemberDataService,
    private itgroupService: ItgroupService,
    private itgroupDataService: ItgroupDataService,
    private employeeService: EmployeeService,
    private employeeDataService: EmployeeDataService,
    private dialog: MatDialog,
    private formBuilder: FormBuilder
  ) { 
    this.itgroupmemberCreateForm = this.formBuilder.group({
      itGroupid: new FormControl('',Validators.required),
      itgroupSelect: new FormControl('',Validators.required),

      employeeID: new FormControl(''),
      employeeSelect: new FormControl(''),
      employeeIdList: this.formBuilder.array([])
    })
  }

  ngOnInit() {
    this.itgroupDataService.itgroupSource.subscribe(data => {
      this.getItgroupLists();
    })
    this.employeeDataService.employeeSource.subscribe(data => {
      this.getEmployeeLists();
    })
  }
 
  get f() { return this.itgroupmemberCreateForm.controls; }
 
  async onFormSubmit() {
    let ok = confirm("Are you sure you want to submit?");
    if(!ok){
      return; 
    }
    if (!this.itgroupmemberCreateForm.valid){
      return;
  }
    try {
      this.isSubmit = true; 

      if(this.selectedEmployees){                                       
        this.itgroupmemberCreateForm.value.employeeIdList = this.selectedEmployees.map(data => {return data.employeeID})
      }
      let result = await this.itgroupmemberService.create(this.itgroupmemberCreateForm.value).toPromise();
      if (result.isSuccess) {
        alert(result.message);
        this.itgroupmemberCreateForm.reset();
        this.selectedEmployees = [];
        this.itgroupmemberDataService.refreshItgroupmembers(); 
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

  async getItgroupLists(){
    try {
      this.itgroupsList = await this.itgroupService.getGroups().toPromise();
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
  selectItgroup($event){
    let itgroup = this.itgroupmemberCreateForm.value.itgroupSelect;
    if (itgroup.length >= 2) {
      if ($event.timeStamp > 200) {
        let selectedItgroup = this.itgroupsList.find(data => data.itGroupName == itgroup);
        
        if(selectedItgroup){
          this.itgroupmemberCreateForm.controls['itGroupid'].setValue(selectedItgroup.itGroupid);
        }
      }
    }
  }

  selectEmployee($event){
    let employee = this.itgroupmemberCreateForm.value.employeeSelect;
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

  openItgroupDialog(){
    const dialogConfig = new MatDialogConfig();
    
    dialogConfig.width = '600px';
    dialogConfig.height = '600px';
    this.dialog.open(ItgroupComponent, dialogConfig)
  }

  openEmployeeDialog(){
    const dialogConfig = new MatDialogConfig();
    
    dialogConfig.width = '700px';
    this.dialog.open(EmployeeComponent, dialogConfig)
  }
}
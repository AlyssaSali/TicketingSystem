import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Itgroupmember } from 'src/app/models/itgroupmember.model';
import { Itgroup } from 'src/app/models/itgroup.model';
import { Employee } from 'src/app/models/employee.model';
import { ItgroupmemberService } from 'src/app/services/itgroupmember.service';
import { ItgroupmemberDataService } from 'src/app/dataservices/itgroupmember.dataservice';
import { ItgroupService } from 'src/app/services/itgroup.service';
import { ItgroupDataService } from 'src/app/dataservices/itgroup.dataservice';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatDialogConfig } from '@angular/material';
import { ItgroupComponent } from '../../itgroup/itgroup.component';
import { EmployeeComponent } from '../../employee/employee.component';

@Component({
  selector: 'app-itgroupmember-update-form',
  templateUrl: './itgroupmember-update-form.component.html',
  styleUrls: ['./itgroupmember-update-form.component.css']
})
export class ItgroupmemberUpdateFormComponent implements OnInit {

  isSubmit = false;
  

  itgroupmemberContext: any;
  itgroupmemberUpdateForm: FormGroup;
  itgroupmemberToBeEditted: Itgroupmember;

  itgroupsList: Itgroup[];
  initialized = false;
  
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
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<ItgroupmemberUpdateFormComponent>,
    @Inject(MAT_DIALOG_DATA) data
  ) { 
    this.itgroupmemberUpdateForm = this.formBuilder.group({
      itGroupMemberid: new FormControl(''),
      itGroupid: new FormControl('',Validators.required),
      itgroupSelect: new FormControl('',Validators.required),

      employeeID: new FormControl(''),
      employeeSelect: new FormControl(''),
      employeeIdList: this.formBuilder.array([])
    })
    this.itgroupmemberContext = data;
  }

  get f() { return this.itgroupmemberUpdateForm.controls;}

  async ngOnInit() {
    this.itgroupmemberToBeEditted = this.itgroupmemberContext.itgroupmemberContext;
    this.itgroupDataService.itgroupSource.subscribe(async data => {
      await this.getItgroupLists();
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
    this.itgroupmemberUpdateForm.controls['itGroupid'].setValue(this.itgroupmemberToBeEditted.itGroupid);
    // this.itgroupmemberUpdateForm.controls['employeeID'].setValue(this.itgroupmemberToBeEditted.employeeID);

   let itGroupName = this.itgroupsList.find(data => data.itGroupid === this.itgroupmemberToBeEditted.itGroupid)
    this.itgroupmemberUpdateForm.controls['itgroupSelect'].setValue(itGroupName.itGroupName);
    this.selectedEmployees = this.itgroupmemberToBeEditted.employees;
    console.log(this.selectedEmployees)
    console.log(this.itgroupmemberUpdateForm.value)
  }

  close(){
    this.dialogRef.close();
  }

  async onFormSubmit() {
    let ok = confirm("Are you sure you want to submit?");
    if(!ok){
      return; 
    }

    if (!this.itgroupmemberUpdateForm.valid)
      return;
      
    try {
      this.isSubmit = true; // sets the isSubmit, disables button
      this.itgroupmemberUpdateForm.value.itGroupMemberid = this.itgroupmemberToBeEditted.itGroupMemberid;
      this.itgroupmemberUpdateForm.value.employeeIdList = this.selectedEmployees.map(data => {return data.employeeID})
      let result = await this.itgroupmemberService.update(this.itgroupmemberUpdateForm.value).toPromise();
      if (result.isSuccess) {
        alert(result.message);
        this.itgroupmemberUpdateForm.reset();
        this.itgroupmemberDataService.refreshItgroupmembers(); // triggers a function that will refresh other component that subscribe to it
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
  async getItgroupLists(){
    try {
      this.itgroupsList = await this.itgroupService.getGroups().toPromise();
    } catch (error) {
      console.log(error);
    }
  }

 
  selectItgroup($event){
    let itgroup = this.itgroupmemberUpdateForm.value.itgroupSelect;
    if (itgroup.length >= 2) {
      if ($event.timeStamp > 200) {
        let selectedItgroup = this.itgroupsList.find(data => data.itGroupName == itgroup);
        if(selectedItgroup){
          this.itgroupmemberUpdateForm.controls['itGroupid'].setValue(selectedItgroup.itGroupid);
        }
      }
    }
  }


 selectEmployee($event){
  let employee = this.itgroupmemberUpdateForm.value.employeeSelect;
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
  
  dialogConfig.width = '600px';
  dialogConfig.height = '600px';
  this.dialog.open(EmployeeComponent, dialogConfig)
}
 
}
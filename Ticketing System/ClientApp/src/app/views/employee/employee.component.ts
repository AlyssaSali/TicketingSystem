import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { EmployeeUpdateFormComponent } from './employee-update-form/employee-update-form.component';
import { OfficeDataService } from 'src/app/dataservices/office.dataservice';
<<<<<<< HEAD
=======
<<<<<<< HEAD
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
=======
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employees: Employee[];

  constructor(
    private employeeService: EmployeeService,
    private employeeDataService: EmployeeDataService,
    private officeDataService: OfficeDataService,
    private employeeTypeDataService: EmployeeTypeDataService,
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    this.employeeDataService.employees.subscribe( data => {
      this.getEmployees();
    })
  }

  async getEmployees() {
    try {
      this.employees = await this.employeeService.ListEmployees().toPromise();
      console.log(this.employees);
    } catch (error) {
      alert("something went wrong");
      console.error(error);
    }
  }

  update(employee){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      employeeContext: employee
    };
    dialogConfig.panelClass = 'custom-modalbox';
    this.dialog.open(EmployeeUpdateFormComponent, dialogConfig);
  }

  async delete(id){
    if(confirm('are you sure you want to delete?')){
      try {
        let result = await this.employeeService.DeleteEmployee(id).toPromise();
        if(result.isSuccess){
          alert(result.message);
          this.employeeDataService.refreshEmployees();
        }
        else {
          alert(result.message);
          
        }

      } catch (error) {
        alert("something went wrong");
        console.log(error);
      }
    }
  }
}

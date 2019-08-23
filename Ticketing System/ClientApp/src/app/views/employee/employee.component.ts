import { Component, OnInit, ViewChild } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDataService } from 'src/app/dataservices/employee.dataservice';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { EmployeeUpdateFormComponent } from './employee-update-form/employee-update-form.component';
import { OfficeDataService } from 'src/app/dataservices/office.dataservice';
<<<<<<< HEAD
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
=======
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  dtElement: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<Employee> = new Subject();
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
<<<<<<< HEAD
      this.rerender();
=======
      console.log(this.employees);
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
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
  ngAfterViewInit(): void {
    this.dtTrigger.next();
  }

  ngOnDestroy(): void {
    // Do not forget to unsubscribe the event
    this.dtTrigger.unsubscribe();
  }

  rerender(): void {
    this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
      // Destroy the table first
      dtInstance.destroy();
      // Call the dtTrigger to rerender again
      this.dtTrigger.next();
    });
  }
}

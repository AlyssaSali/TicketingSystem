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
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
=======
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
<<<<<<< HEAD
=======
<<<<<<< HEAD
  @ViewChild(DataTableDirective, {static: false})
  dtElement: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<Employee> = new Subject();
  
=======
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
  employees: Employee[];

  constructor(
    private employeeService: EmployeeService,
    private employeeDataService: EmployeeDataService,
    private officeDataService: OfficeDataService,
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
<<<<<<< HEAD
=======
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
    } catch (error) {
      alert("something went wrong");
      console.error(error);
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

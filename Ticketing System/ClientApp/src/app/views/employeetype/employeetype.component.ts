import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeType } from 'src/app/models/employeetype.model';
import { EmployeeTypeService } from 'src/app/services/employeetype.service';
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { EmployeetypeUpdateFormComponent } from './employeetype-update-form/employeetype-update-form.component';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-employeetype',
  templateUrl: './employeetype.component.html',
  styleUrls: ['./employeetype.component.css']
})
export class EmployeetypeComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  dtElement: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<EmployeeType> = new Subject();
  
  employeeTypes:EmployeeType[];
  constructor(
    private employeeTypeService: EmployeeTypeService,
    private employeeTypeDataService: EmployeeTypeDataService,
    public dialog:MatDialog,
    
  ) { }

  ngOnInit() {
    this.employeeTypeDataService.employeeTypes.subscribe(data =>{
      this.getEmployeeTypes();
    })
  }
  async getEmployeeTypes() {
    try{
      this.employeeTypes=await this.employeeTypeService.getAll().toPromise();
      this.rerender();
    }catch(error){
      alert('Something went wrong!');
      console.error(error);
    }
  }
  async delete(employeeTypeid){
    if(confirm('Are you sure you want to delete?')){
      try{
        let result= await this.employeeTypeService.delete(employeeTypeid).toPromise()
        if(result.isSuccess){
          alert(result.message)
          this.employeeTypeDataService.refreshEmployeeTypes();
        }else{
          alert(result.message)
        }
        }catch(error){
          alert('Something went wrong');
          console.log(error)
        }
      }
    
  }
  update(employeeType){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data={
      employeeTypeContext:employeeType
    };
<<<<<<< HEAD
    dialogConfig.width = '400px';
    dialogConfig.panelClass = 'custom-modalbox';
=======
<<<<<<< HEAD
    dialogConfig.width = '400px';
    dialogConfig.panelClass = 'custom-modalbox';
=======
<<<<<<< HEAD
    dialogConfig.width = '400px';
    dialogConfig.panelClass = 'custom-modalbox';
=======
    dialogConfig.width='600px';
    //dialogConfig.height='600px';
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
    this.dialog.open(EmployeetypeUpdateFormComponent,dialogConfig)
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

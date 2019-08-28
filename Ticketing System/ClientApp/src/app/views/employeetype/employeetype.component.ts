import { Component, OnInit } from '@angular/core';
import { EmployeeType } from 'src/app/models/employeetype.model';
import { EmployeeTypeService } from 'src/app/services/employeetype.service';
import { EmployeeTypeDataService } from 'src/app/dataservices/employeetype.dataservice';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { EmployeetypeUpdateFormComponent } from './employeetype-update-form/employeetype-update-form.component';

@Component({
  selector: 'app-employeetype',
  templateUrl: './employeetype.component.html',
  styleUrls: ['./employeetype.component.css']
})
export class EmployeetypeComponent implements OnInit {
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
    dialogConfig.width = '400px';
    dialogConfig.panelClass = 'custom-modalbox';
    this.dialog.open(EmployeetypeUpdateFormComponent,dialogConfig)
  }

}

import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeEmployeeType } from 'src/app/models/employee-employee-type.model';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import { MatDialog, MatDialogConfig } from '@angular/material';
import { EmployeeEmployeeTypeUpdateFormComponent } from '../employee-employee-type-update-form/employee-employee-type-update-form.component';
import { EmployeeEmployeeTypeService } from 'src/app/services/employee-employee-type.service';
import { EmployeeEmployeeTypeDataService } from 'src/app/dataservices/employee-employee-type.dataservice';

@Component({
  selector: 'app-employee-employee-type',
  templateUrl: './employee-employee-type.component.html',
  styleUrls: ['./employee-employee-type.component.css']
})
export class EmployeeEmployeeTypeComponent implements OnInit {

  employeeEmployeeTypes: EmployeeEmployeeType[];
  dialogOpen = false;
    
  @ViewChild(DataTableDirective, {static: false})
  dtElement: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<EmployeeEmployeeType> = new Subject();

    constructor(
      private employeeEmployeeTypeService: EmployeeEmployeeTypeService,
      private employeeEmployeeTypeDataService: EmployeeEmployeeTypeDataService,
      // private itgroupDataService: ItgroupDataService,
      public dialog:MatDialog,
      
    ) { }
  
    ngOnInit() {
      this.employeeEmployeeTypeDataService.employeeEmployeeTypes.subscribe(data =>{
        this.getEmployeeEmployeeTypes();
      })
   
      // this.itgroupDataService.itgroups.subscribe(data =>{
      //   this.getItgroupmembers();
      // })
    }
    // async getItgroupmembers() {
    //   try{
  
    //     this.itgroupmembers=await this.itgroupmemberService.getAll().toPromise();
    //   }catch(error){
    //     alert('Something went wrong!');
    //     console.error(error);
    //   }
    // }
    async getEmployeeEmployeeTypes(){
      try {
        this.dtOptions = {    
          pagingType: "full_numbers",    
          pageLength: 10,    
          serverSide: true,    
          processing: true,    
          searching: true,    
          ajax: async (dataTablesParameters: any, callback) => {    
            let data = await this.employeeEmployeeTypeService.getDataServerSide(dataTablesParameters).toPromise()
            this.employeeEmployeeTypes = data.data;   
            console.log(this.employeeEmployeeTypes); 
            callback({    
              recordsTotal: data.recordsTotal,    
              recordsFiltered: data.recordsFiltered,    
              data: []    
            });    
          },    
          columns: [null, null, null]    
        };
        this.rerender()
      } catch (error) {
        alert('Something went wrong!');
        console.error(error);
      }
    }
      async delete(employeeEmployeeTypeid){
        if(confirm('Are you sure you want to delete?')){
          try{
            let result= await this.employeeEmployeeTypeService.delete(employeeEmployeeTypeid).toPromise()
            if(result.isSuccess){
              alert(result.message)
              this.employeeEmployeeTypeDataService.refreshEmployeeEmployeeTypes();
            }else{
              alert(result.message)
            }
            }catch(error){
              alert('Something went wrong');
              console.log(error)
            }
          }
        
      }
      // update(itgroupmember){
      //   const dialogConfig = new MatDialogConfig();
      //   dialogConfig.data={
      //     itgroupmemberContext:itgroupmember
      //   };
      //   dialogConfig.width='600px';
      //   //dialogConfig.height='600px';
      //   this.dialog.open(ItgroupmemberUpdateFormComponent,dialogConfig)
      // }
      update(employeeEmployeeType){
        const dialogConfig = new MatDialogConfig();
        employeeEmployeeType.employeeIdList = employeeEmployeeType.employees.map(data => {return data.employeeID})
        console.log(this.employeeEmployeeTypes);
        dialogConfig.data = {
          employeeEmployeeTypeContext: employeeEmployeeType
        };
        dialogConfig.width = '600px';
        dialogConfig.maxHeight = '1000px';
        this.dialogOpen =  true;
        let dialogRef = this.dialog.open(EmployeeEmployeeTypeUpdateFormComponent, dialogConfig)
        dialogRef.afterClosed().subscribe( data => {
          this.dialogOpen = false;
        })
      }
      ngAfterViewInit(): void {
        this.dtTrigger.next();
      }
    
      ngOnDestroy(): void {
        // Do not forget to unsubscribe the event
        this.dtTrigger.unsubscribe();
      }
    
      rerender(): void {
        if(this.dtElement){
          this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
            // Destroy the table first
            dtInstance.destroy();
            // Call the dtTrigger to rerender again
            this.dtTrigger.next();
          });
        }
      }
   }

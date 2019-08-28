import { Component, OnInit, ViewChild } from '@angular/core';
import { Itgroupmember } from 'src/app/models/itgroupmember.model';
import { ItgroupmemberDataService } from 'src/app/dataservices/itgroupmember.dataservice';
import { ItgroupmemberService } from 'src/app/services/itgroupmember.service';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { ItgroupmemberUpdateFormComponent } from './itgroupmember-update-form/itgroupmember-update-form.component';
import { ItgroupDataService } from 'src/app/dataservices/itgroup.dataservice';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
  selector: 'app-itgroupmember',
  templateUrl: './itgroupmember.component.html'
})
export class ItgroupmemberComponent implements OnInit {
itgroupmembers: Itgroupmember[];
  dialogOpen = false;
    
  @ViewChild(DataTableDirective, {static: false})
  dtElement: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<Itgroupmember> = new Subject();

    constructor(
      private itgroupmemberService: ItgroupmemberService,
      private itgroupmemberDataService: ItgroupmemberDataService,
      // private itgroupDataService: ItgroupDataService,
      public dialog:MatDialog,
      
    ) { }
  
    ngOnInit() {
      this.itgroupmemberDataService.itgroupmembers.subscribe(data =>{
        this.getItgroupmembers();
      })
    }

    async getItgroupmembers(){
      try {
        this.dtOptions = {    
          pagingType: "full_numbers",    
          pageLength: 10,    
          serverSide: true,    
          processing: true,    
          searching: true,    
          ajax: async (dataTablesParameters: any, callback) => {    
            let data = await this.itgroupmemberService.getDataServerSide(dataTablesParameters).toPromise()
            this.itgroupmembers = data.data;   
            console.log(this.itgroupmembers); 
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
      async delete(itGroupMemberid){
        if(confirm('Are you sure you want to delete?')){
          try{
            let result= await this.itgroupmemberService.delete(itGroupMemberid).toPromise()
            if(result.isSuccess){
              alert(result.message)
              this.itgroupmemberDataService.refreshItgroupmembers();
            }else{
              alert(result.message)
            }
            }catch(error){
              alert('Something went wrong');
              console.log(error)
            }
          }
        
      }
      
      update(itgroupmember){
        const dialogConfig = new MatDialogConfig();
        itgroupmember.employeeIdList = itgroupmember.employees.map(data => {return data.employeeID})
        console.log(this.itgroupmembers);
        dialogConfig.data = {
          itgroupmemberContext: itgroupmember
        };
        dialogConfig.panelClass = 'custom-modalbox';
        this.dialogOpen =  true;
        let dialogRef = this.dialog.open(ItgroupmemberUpdateFormComponent, dialogConfig)
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
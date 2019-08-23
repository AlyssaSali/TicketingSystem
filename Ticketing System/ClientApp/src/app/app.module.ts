import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
<<<<<<< HEAD
=======
<<<<<<< HEAD
import { AppComponent } from './app.component';
=======
>>>>>>> ridz
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { NavMenuComponent } from './views/layouts/nav-menu/nav-menu.component';
import { EmployeeComponent } from './views/employee/employee.component';
import { EmployeeAddFormComponent } from './views/employee/employee-add-form/employee-add-form.component';
import { EmployeeUpdateFormComponent } from './views/employee/employee-update-form/employee-update-form.component';
import { MatDialogModule, MatSidenavModule, MatDialogRef } from '@angular/material';
import { OfficeUpdateFormComponent } from './views/office/office-update-form/office-update-form.component';
import { OfficeComponent } from './views/office/office.component';
import { OfficeAddFormComponent } from './views/office/office-add-form/office-add-form.component';
<<<<<<< HEAD


=======
<<<<<<< HEAD
=======

>>>>>>> ridz
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
import { HomeComponent } from './views/home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TicketComponent } from './views/ticket/ticket.component';
import { TicketAddFormComponent } from './views/ticket/ticket-add-form/ticket-add-form.component';
import { TicketEditFormComponent } from './views/ticket/ticket-edit-form/ticket-edit-form.component';
import { CommonModule } from '@angular/common';
import { SidenavComponent } from './views/layouts/sidenav/sidenav.component';
import { SeverityComponent } from './views/severity/severity.component';
import { SeverityAddFormComponent } from './views/severity/severity-add-form/severity-add-form.component';
import { SeverityUpdateFormComponent } from './views/severity/severity-update-form/severity-update-form.component';
import { DashboardComponent } from './views/layouts/dashboard/dashboard.component';
import { TicketMinorComponent } from './views/ticket-minor/ticket-minor.component';
import { TicketApprovalComponent } from './views/ticket-approval/ticket-approval.component';
import { TicketSLAComponent } from './views/ticket-SLA/ticket-SLA.component';
import { CategoryComponent } from './views/category/category.component';
import { CategoryAddFormComponent } from './views/category/category-add-form/category-add-form.component';
import { CategoryUpdateFormComponent } from './views/category/category-update-form/category-update-form.component';
<<<<<<< HEAD
import { CategoryListUpdateFormComponent } from './views/categoryList/categoryList-update-form/categoryList-update-form.component';
import { CategoryListAddFormComponent } from './views/categoryList/categoryList-add-form/categoryList-add-form.component';
import { CategoryListComponent } from './views/categoryList/categoryList.component';
<<<<<<< HEAD
=======
=======
>>>>>>> ridz
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
import { ItgroupComponent } from './views/itgroup/itgroup.component';
import { ItgroupAddFormComponent } from './views/itgroup/itgroup-add-form/itgroup-add-form.component';
import { ItgroupUpdateFormComponent } from './views/itgroup/itgroup-update-form/itgroup-update-form.component';
import { ItgroupDataService } from './dataservices/itgroup.dataservice';
<<<<<<< HEAD
import { EmployeetypeComponent } from './views/employeetype/employeetype.component';
import { EmployeetypeAddFormComponent } from './views/employeetype/employeetype-add-form/employeetype-add-form.component';
import { EmployeetypeUpdateFormComponent } from './views/employeetype/employeetype-update-form/employeetype-update-form.component';
=======
<<<<<<< HEAD
import { ToastrModule } from 'ngx-toastr';
import { ItgroupmemberComponent } from './views/itgroupmember/itgroupmember.component';
import { ItgroupmemberAddFormComponent } from './views/itgroupmember/itgroupmember-add-form/itgroupmember-add-form.component';
import { ItgroupmemberUpdateFormComponent } from './views/itgroupmember/itgroupmember-update-form/itgroupmember-update-form.component';
import {DataTablesModule} from 'angular-datatables';

=======
import { CategoryListUpdateFormComponent } from './views/categoryList/categoryList-update-form/categoryList-update-form.component';
import { CategoryListAddFormComponent } from './views/categoryList/categoryList-add-form/categoryList-add-form.component';
import { CategoryListComponent } from './views/categoryList/categoryList.component';
import { FooterComponent } from './views/layouts/footer/footer.component';
import { ModalsComponent } from './views/layouts/modals/modals.component';
>>>>>>> ridz
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SeverityComponent,
    SeverityAddFormComponent,
    SeverityUpdateFormComponent,
    TicketComponent,
    TicketAddFormComponent,
    TicketEditFormComponent,
    TicketMinorComponent,
    TicketApprovalComponent,
    EmployeeComponent,
    EmployeeAddFormComponent,
    EmployeeUpdateFormComponent,
    OfficeComponent,
    OfficeAddFormComponent,
    OfficeUpdateFormComponent,
    SidenavComponent,
    DashboardComponent,
    FooterComponent,
    TicketSLAComponent,
    CategoryComponent,
    CategoryAddFormComponent,
    CategoryUpdateFormComponent,
    CategoryListComponent,
    CategoryListAddFormComponent,
    CategoryListUpdateFormComponent,
    ItgroupComponent,
    ItgroupAddFormComponent,
<<<<<<< HEAD
    ItgroupUpdateFormComponent,
<<<<<<< HEAD
    EmployeetypeComponent,
    EmployeetypeAddFormComponent,
    EmployeetypeUpdateFormComponent
  ],
=======
    ItgroupmemberComponent,
    ItgroupmemberAddFormComponent,
    ItgroupmemberUpdateFormComponent
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
=======
<<<<<<< HEAD
    ItgroupUpdateFormComponent
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15

],
=======
    ItgroupUpdateFormComponent,
    ModalsComponent
  ],
>>>>>>> ridz
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatDialogModule,
<<<<<<< HEAD
    //ToastrModule.forRoot(),
    CommonModule
  ],
  entryComponents:[
    EmployeeUpdateFormComponent, 
    OfficeUpdateFormComponent, 
    ItgroupUpdateFormComponent,
=======
<<<<<<< HEAD
    CommonModule,
    ToastrModule.forRoot(),
    DataTablesModule
  ],
  entryComponents: [EmployeeUpdateFormComponent, OfficeUpdateFormComponent, ItgroupUpdateFormComponent, TicketAddFormComponent,
    SeverityUpdateFormComponent,ItgroupmemberUpdateFormComponent,
    TicketSLAComponent,
    TicketApprovalComponent,
    CategoryUpdateFormComponent,
    CategoryListUpdateFormComponent],
    bootstrap: [AppComponent]
=======
    CommonModule
  ],
  entryComponents:[
    EmployeeUpdateFormComponent,
    OfficeUpdateFormComponent,
    OfficeAddFormComponent,
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
    TicketAddFormComponent, 
    SeverityUpdateFormComponent, 
    TicketSLAComponent,
    TicketApprovalComponent,
    CategoryUpdateFormComponent,
<<<<<<< HEAD
    CategoryListUpdateFormComponent,
    EmployeetypeUpdateFormComponent
  ],
  providers: [],
=======
    CategoryAddFormComponent,
    CategoryListUpdateFormComponent,
    ItgroupUpdateFormComponent,
    ModalsComponent
  ],
  providers: [
    {provide: MatDialogRef, useValue: {}},
  ],
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
  bootstrap: [AppComponent]
>>>>>>> ridz
})
export class AppModule { }

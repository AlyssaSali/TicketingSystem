import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './views/home/home.component';
<<<<<<< HEAD
import { RouterModule, Routes } from '@angular/router';
import { SeverityComponent } from './views/severity/severity.component';
import { TicketComponent } from './views/ticket/ticket.component';
import { OfficeComponent } from './views/office/office.component';
import { EmployeeComponent } from './views/employee/employee.component';
=======
<<<<<<< HEAD
import { EmployeeComponent } from './views/employee/employee.component';
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
import { CounterComponent } from './views/counter/counter.component';
import { FetchDataComponent } from './views/fetch-data/fetch-data.component';
import { EmployeeComponent } from './views/employee/employee.component';
=======
>>>>>>> ridz
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
import { RouterModule, Routes } from '@angular/router';
import { SeverityComponent } from './views/severity/severity.component';
import { OfficeComponent } from './views/office/office.component';
<<<<<<< HEAD
=======
<<<<<<< HEAD
import { EmployeeComponent } from './views/employee/employee.component';
=======
<<<<<<< HEAD
=======
import { EmployeeComponent } from './views/employee/employee.component';
>>>>>>> ridz
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
import { SidenavComponent } from './views/layouts/sidenav/sidenav.component';
import { DashboardComponent } from './views/layouts/dashboard/dashboard.component';
import { TicketMinorAddFormComponent } from './views/ticket-minor/ticket-minor-add-form/ticket-minor-add-form.component';
import { TicketApprovalComponent } from './views/ticket-approval/ticket-approval.component';
import { TicketSLAComponent } from './views/ticket-SLA/ticket-SLA.component';
import { CategoryComponent } from './views/category/category.component';
import { CategoryListComponent } from './views/categoryList/categoryList.component';
<<<<<<< HEAD
=======
<<<<<<< HEAD
import { EmployeetypeComponent } from './views/employeetype/employeetype.component';
import { ItgroupmemberComponent } from './views/itgroupmember/itgroupmember.component';
=======
<<<<<<< HEAD
import { ItgroupComponent } from './views/itgroup/itgroup.component';
<<<<<<< HEAD
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
import { EmployeetypeComponent } from './views/employeetype/employeetype.component';
import { ItgroupComponent } from './views/itgroup/itgroup.component';
import { ItgroupmemberComponent } from './views/itgroupmember/itgroupmember.component';
<<<<<<< HEAD
import { ModalsComponent } from './views/layouts/modals/modals.component';
import { TicketMinorComponent } from './views/ticket-minor/ticket-minor.component';
import { TicketAddFormComponent } from './views/ticket/ticket-add-form/ticket-add-form.component';
import { TicketHistoryComponent } from './views/ticket-history/ticket-history.component';
=======
=======
>>>>>>> 63171424717892a87f2f85c43afeee8014c441ad
=======
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
import { ModalsComponent } from './views/layouts/modals/modals.component';
import { RegisterComponent } from './views/auth/register/register.component';
import { AuthGuard } from './guard/auth.guard';
import { ForgotPasswordComponent } from './views/auth/forgot-password/forgot-password.component';
import { EmployeeEmployeeTypeComponent } from './views/employeeEmployeeType/employee-employee-type/employee-employee-type.component';

>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7

const routes: Routes = [
  {path: '', component: HomeComponent, pathMatch: 'full'},
<<<<<<< HEAD
  {path: 'severity', component: SeverityComponent, canActivate:[AuthGuard]},
  {path: 'ticketMinor', component: TicketMinorComponent, canActivate:[AuthGuard]},
  {path: 'ticketApproval', component: TicketApprovalComponent, canActivate:[AuthGuard]},
  {path: 'setting', component: SidenavComponent, canActivate:[AuthGuard]},
  {path: 'dashboard', component: DashboardComponent, canActivate:[AuthGuard]},
  {path: 'ticketSLA', component: TicketSLAComponent, canActivate:[AuthGuard]},
  {path: 'category', component: CategoryComponent, canActivate:[AuthGuard]},
  {path: 'categoryList', component: CategoryListComponent, canActivate:[AuthGuard]},
  { path: 'itgroup', component: ItgroupComponent, canActivate:[AuthGuard]},
  { path: 'employeeType', component: EmployeetypeComponent, canActivate:[AuthGuard]},
  {path: 'itgroupmember', component: ItgroupmemberComponent, canActivate:[AuthGuard]},
  {path: 'employeeEmployeeType', component: EmployeeEmployeeTypeComponent, canActivate:[AuthGuard]},
  { path: 'office', component: OfficeComponent , canActivate:[AuthGuard]},
  { path: 'employee', component: EmployeeComponent , canActivate:[AuthGuard]},
  { path: 'categoryList', component: CategoryListComponent , canActivate:[AuthGuard]},
  { path: 'employeetype', component: EmployeetypeComponent , canActivate:[AuthGuard]},
  { path: 'modals', component: ModalsComponent, canActivate:[AuthGuard]},
  { path: 'register', component: RegisterComponent, canActivate:[AuthGuard], data: {permittedRoles:['Admin']}},
  { path: 'forgot-password', component: ForgotPasswordComponent}
=======
  {path: 'severity', component: SeverityComponent},
  {path: 'ticket', component: TicketComponent},
  {path: 'ticketAdd', component: TicketAddFormComponent},
  {path: 'ticketEdit', component: TicketEditFormComponent},
  {path: 'ticketMinor', component: TicketMinorComponent},
  {path: 'ticketAddMinor', component: TicketMinorAddFormComponent},
  {path: 'ticketApproval', component: TicketApprovalComponent},
  {path: 'setting', component: SidenavComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'ticketSLA', component: TicketSLAComponent},
  {path: 'category', component: CategoryComponent},
  {path: 'categoryList', component: CategoryListComponent},
  { path: 'itgroup', component: ItgroupComponent},
  { path: 'employeeType', component: EmployeetypeComponent},
  {path: 'categoryList', component: CategoryListComponent},
  { path: 'itgroup', component: ItgroupComponent},
  {path: 'itgroupmember', component: ItgroupmemberComponent},
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'office', component: OfficeComponent },
  { path: 'employee', component: EmployeeComponent },
  { path: 'itgroup', component: ItgroupComponent },
  { path: 'categoryList', component: CategoryListComponent },
<<<<<<< HEAD
  { path: 'modals', component: ModalsComponent},
  { path: 'ticketHistory', component: TicketHistoryComponent}
=======
  { path: 'modals', component: ModalsComponent}
>>>>>>> ridz
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
]

@NgModule({
  imports:[RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

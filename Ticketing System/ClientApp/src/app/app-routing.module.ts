import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './views/home/home.component';
import { EmployeeComponent } from './views/employee/employee.component';
import { RouterModule, Routes } from '@angular/router';
import { SeverityComponent } from './views/severity/severity.component';
import { OfficeComponent } from './views/office/office.component';
import { SidenavComponent } from './views/layouts/sidenav/sidenav.component';
import { DashboardComponent } from './views/layouts/dashboard/dashboard.component';
import { TicketMinorComponent } from './views/ticket-minor/ticket-minor.component';
import { TicketApprovalComponent } from './views/ticket-approval/ticket-approval.component';
import { TicketSLAComponent } from './views/ticket-SLA/ticket-SLA.component';
import { CategoryComponent } from './views/category/category.component';
import { ItgroupComponent } from './views/itgroup/itgroup.component';
import { CategoryListComponent } from './views/categoryList/categoryList.component';
import { EmployeetypeComponent } from './views/employeetype/employeetype.component';
import { ItgroupmemberComponent } from './views/itgroupmember/itgroupmember.component';
import { ModalsComponent } from './views/layouts/modals/modals.component';
import { RegisterComponent } from './views/auth/register/register.component';
import { AuthGuard } from './guard/auth.guard';
import { ForgotPasswordComponent } from './views/auth/forgot-password/forgot-password.component';
import { EmployeeEmployeeTypeComponent } from './views/employeeEmployeeType/employee-employee-type/employee-employee-type.component';


const routes: Routes = [
  {path: '', component: HomeComponent, pathMatch: 'full'},
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
]

@NgModule({
  imports:[RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

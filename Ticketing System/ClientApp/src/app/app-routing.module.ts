import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './views/home/home.component';
import { RouterModule, Routes } from '@angular/router';
import { SeverityComponent } from './views/severity/severity.component';
import { TicketComponent } from './views/ticket/ticket.component';
import { TicketAddFormComponent } from './views/ticket/ticket-add-form/ticket-add-form.component';
import { OfficeComponent } from './views/office/office.component';
import { EmployeeComponent } from './views/employee/employee.component';
<<<<<<< HEAD
import { SidenavComponent } from './views/layouts/sidenav/sidenav.component';
import { DashboardComponent } from './views/layouts/dashboard/dashboard.component';
import { TicketMinorComponent } from './views/ticket-minor/ticket-minor.component';
import { TicketApprovalComponent } from './views/ticket-approval/ticket-approval.component';
import { TicketSLAComponent } from './views/ticket-SLA/ticket-SLA.component';
import { TicketEditFormComponent } from './views/ticket/ticket-edit-form/ticket-edit-form.component';
import { CategoryComponent } from './views/category/category.component';
import { CategoryListComponent } from './views/categoryList/categoryList.component';

const routes: Routes = [
  {path: '', component: HomeComponent, pathMatch: 'full'},
  {path: 'severity', component: SeverityComponent},
  {path: 'ticket', component: TicketComponent},
  {path: 'ticketAdd', component: TicketAddFormComponent},
  {path: 'ticketEdit', component: TicketEditFormComponent},
  {path: 'ticketMinor', component: TicketMinorComponent},
  {path: 'ticketApproval', component: TicketApprovalComponent},
  {path: 'office', component: OfficeComponent},
  {path: 'employee', component: EmployeeComponent},
  {path: 'setting', component: SidenavComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'ticketSLA', component: TicketSLAComponent},
  {path: 'category', component: CategoryComponent},
  {path: 'categoryList', component: CategoryListComponent},
=======
import { ItgroupComponent } from './views/itgroup/itgroup.component';


const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full'},
  { path: 'counter', component: CounterComponent},
  { path: 'fetch-data', component: FetchDataComponent},
  { path: 'office', component: OfficeComponent},
  { path: 'employee', component: EmployeeComponent},
  { path: 'itgroup', component: ItgroupComponent}
  
>>>>>>> 672730fec7a9527c892fc88cfb34fa9e84777be3
]

@NgModule({
  imports:[RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './views/home/home.component';
<<<<<<< HEAD
import { CounterComponent } from './views/counter/counter.component';
import { FetchDataComponent } from './views/fetch-data/fetch-data.component';
import { EmployeeComponent } from './views/employee/employee.component';
=======
>>>>>>> ridz
import { RouterModule, Routes } from '@angular/router';
import { SeverityComponent } from './views/severity/severity.component';
import { TicketComponent } from './views/ticket/ticket.component';
import { TicketAddFormComponent } from './views/ticket/ticket-add-form/ticket-add-form.component';
import { OfficeComponent } from './views/office/office.component';
<<<<<<< HEAD
=======
import { EmployeeComponent } from './views/employee/employee.component';
>>>>>>> ridz
import { SidenavComponent } from './views/layouts/sidenav/sidenav.component';
import { DashboardComponent } from './views/layouts/dashboard/dashboard.component';
import { TicketMinorComponent } from './views/ticket-minor/ticket-minor.component';
import { TicketApprovalComponent } from './views/ticket-approval/ticket-approval.component';
import { TicketSLAComponent } from './views/ticket-SLA/ticket-SLA.component';
import { TicketEditFormComponent } from './views/ticket/ticket-edit-form/ticket-edit-form.component';
import { CategoryComponent } from './views/category/category.component';
import { ItgroupComponent } from './views/itgroup/itgroup.component';
import { CategoryListComponent } from './views/categoryList/categoryList.component';
<<<<<<< HEAD
import { ItgroupComponent } from './views/itgroup/itgroup.component';
<<<<<<< HEAD
import { ItgroupmemberComponent } from './views/itgroupmember/itgroupmember.component';
=======
=======
import { ModalsComponent } from './views/layouts/modals/modals.component';
>>>>>>> ridz
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15

const routes: Routes = [
  {path: '', component: HomeComponent, pathMatch: 'full'},
  {path: 'severity', component: SeverityComponent},
  {path: 'ticket', component: TicketComponent},
  {path: 'ticketAdd', component: TicketAddFormComponent},
  {path: 'ticketEdit', component: TicketEditFormComponent},
  {path: 'ticketMinor', component: TicketMinorComponent},
  {path: 'ticketApproval', component: TicketApprovalComponent},
  {path: 'setting', component: SidenavComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'ticketSLA', component: TicketSLAComponent},
  {path: 'category', component: CategoryComponent},
<<<<<<< HEAD
  {path: 'categoryList', component: CategoryListComponent},
  { path: 'itgroup', component: ItgroupComponent},
  {path: 'itgroupmember', component: ItgroupmemberComponent}
  
=======
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'office', component: OfficeComponent },
  { path: 'employee', component: EmployeeComponent },
  { path: 'itgroup', component: ItgroupComponent },
  { path: 'categoryList', component: CategoryListComponent },
  { path: 'modals', component: ModalsComponent}
>>>>>>> ridz
]

@NgModule({
  imports:[RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

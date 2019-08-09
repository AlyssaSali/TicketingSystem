import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { MatDialogModule } from '@angular/material';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './views/layouts/nav-menu/nav-menu.component';
<<<<<<< HEAD
import { HomeComponent } from './views/home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SeverityComponent } from './views/severity/severity.component';
import { SeverityAddFormComponent } from './views/severity/severity-add-form/severity-add-form.component';
import { SeverityEditFormComponent } from './views/severity/severity-edit-form/severity-edit-form.component';
import { TicketComponent } from './views/ticket/ticket.component';
import { TicketAddFormComponent } from './views/ticket/ticket-add-form/ticket-add-form.component';
import { TicketEditFormComponent } from './views/ticket/ticket-edit-form/ticket-edit-form.component';
=======
<<<<<<< HEAD
import { EmployeeComponent } from './views/employee/employee.component';
import { EmployeeAddFormComponent } from './views/employee/employee-add-form/employee-add-form.component';
import { EmployeeUpdateFormComponent } from './views/employee/employee-update-form/employee-update-form.component';

=======
import { OfficeComponent } from './views/office/office.component';
import { OfficeAddFormComponent } from './views/office/office-add-form/office-add-form.component';
import { OfficeUpdateFormComponent } from './views/office/office-update-form/office-update-form.component';
import { MatDialogModule } from '@angular/material';
>>>>>>> 6d2d6532e882551e73784511ee1ca6b02e942cb4
>>>>>>> d03904ae63c76b400a8493dbaf62e20d91bc2e2f

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
<<<<<<< HEAD
    HomeComponent,
    SeverityComponent,
    SeverityAddFormComponent,
    SeverityEditFormComponent,
    TicketComponent,
    TicketAddFormComponent,
    TicketEditFormComponent
],
=======
<<<<<<< HEAD
    EmployeeComponent,
    EmployeeAddFormComponent,
    EmployeeUpdateFormComponent
=======
    OfficeComponent,
    OfficeAddFormComponent,
    OfficeUpdateFormComponent
>>>>>>> 6d2d6532e882551e73784511ee1ca6b02e942cb4
  ],
>>>>>>> d03904ae63c76b400a8493dbaf62e20d91bc2e2f
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatDialogModule,
    ToastrModule.forRoot()
  ],
  entryComponents:[SeverityEditFormComponent, TicketAddFormComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

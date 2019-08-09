import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './views/home/home.component';
import { FetchDataComponent } from './views/fetch-data/fetch-data.component';
import { CounterComponent } from './views/counter/counter.component';
import { NavMenuComponent } from './views/layouts/nav-menu/nav-menu.component';
import { EmployeeComponent } from './views/employee/employee.component';
import { EmployeeAddFormComponent } from './views/employee/employee-add-form/employee-add-form.component';
import { EmployeeUpdateFormComponent } from './views/employee/employee-update-form/employee-update-form.component';


@NgModule({
  declarations: [
    AppComponent, 
    HomeComponent,
    FetchDataComponent,
    CounterComponent,
    NavMenuComponent,
    EmployeeComponent,
    EmployeeAddFormComponent,
    EmployeeUpdateFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

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
import { OfficeComponent } from './views/office/office.component';
import { OfficeAddFormComponent } from './views/office/office-add-form/office-add-form.component';
import { OfficeUpdateFormComponent } from './views/office/office-update-form/office-update-form.component';
import { MatDialogModule } from '@angular/material';

@NgModule({
  declarations: [
    AppComponent, 
    HomeComponent,
    FetchDataComponent,
    CounterComponent,
    NavMenuComponent,
    OfficeComponent,
    OfficeAddFormComponent,
    OfficeUpdateFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatDialogModule,
  ],
  entryComponents:[OfficeUpdateFormComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import {AddEmployeeComponent } from './employee/addEmployee/add-employee.component'
import { EmployeeListComponent } from './employee/employeeList/list-employee.component'
import {EmployeeDetailsComponent } from './employee/employeeDetail/detail-employee.component'

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AddEmployeeComponent,
    EmployeeListComponent,
    EmployeeDetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: EmployeeListComponent, pathMatch: 'full' },
      { path: 'employee-list', component: EmployeeListComponent },
      { path: 'employee-list/:id', component: EmployeeDetailsComponent },
      { path: 'employee-add', component: AddEmployeeComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

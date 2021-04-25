import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavbarComponent } from './components/main/navbar/navbar.component';
import { SidebarComponent } from './components/main/sidebar/sidebar.component';
import { HttpClientModule } from '@angular/common/http';
import { EmployeesComponent } from './components/main/employees/employees.component';
import { HomeComponent } from './components/main/home/home.component';
import { EmployeeCardComponent } from './components/main/employee-card/employee-card.component';
import { LoginComponent } from './components/main/login/login.component';
import { NotFoundComponent } from './components/main/not-found/not-found.component';
import { EmplRoutingModule } from './empl-routing/empl-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidebarComponent,
    EmployeesComponent,
    HomeComponent,
    EmployeeCardComponent,
    LoginComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    EmplRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

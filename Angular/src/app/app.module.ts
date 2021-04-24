import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavbarComponent } from './components/main/navbar/navbar.component';
import { SidebarComponent } from './components/main/sidebar/sidebar.component';
import { HttpClientModule } from '@angular/common/http';
import { EmployeesComponent } from './components/main/employees/employees.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidebarComponent,
    EmployeesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

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
import { ReactiveFormsModule } from '@angular/forms';
import { EmployeeInfoComponent } from './components/main/employee-info/employee-info.component';
import { PersonalDetailsComponent } from './components/main/employee-info/personal-details/personal-details.component';
import { CareerComponent } from './components/main/employee-info/career/career.component';
import { VacationComponent } from './components/main/employee-info/vacation/vacation.component';
import { AnalyticsComponent } from './components/main/analytics/analytics.component';
import { OAuthModule } from 'angular-oauth2-oidc';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidebarComponent,
    EmployeesComponent,
    HomeComponent,
    EmployeeCardComponent,
    LoginComponent,
    NotFoundComponent,
    EmployeeInfoComponent,
    PersonalDetailsComponent,
    CareerComponent,
    VacationComponent,
    AnalyticsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    EmplRoutingModule,
    OAuthModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

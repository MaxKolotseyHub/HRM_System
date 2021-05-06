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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmployeeInfoComponent } from './components/main/employee-info/employee-info.component';
import { PersonalDetailsComponent } from './components/main/employee-info/personal-details/personal-details.component';
import { CareerComponent } from './components/main/employee-info/career/career.component';
import { VacationComponent } from './components/main/employee-info/vacation/vacation.component';
import { AnalyticsComponent } from './components/main/analytics/analytics.component';
import { OAuthModule } from 'angular-oauth2-oidc';
import { ChartsModule } from 'ng2-charts';
import { EmplPerDeptComponent } from './components/main/analytics/charts/empl-per-dept/empl-per-dept.component';
import { EffComponent } from './components/main/analytics/charts/eff/eff.component';
import { AvgSalComponent } from './components/main/analytics/charts/avg-sal/avg-sal.component';
import { CreateEmployeeComponent } from './components/main/create-employee/create-employee.component';
import { DepartamentItemComponent } from './components/main/admin/departament/departament-item/departament-item.component';
import { DepartamentsComponent } from './components/main/admin/departament/departaments/departaments.component';
import { CreateDepartamentComponent } from './components/main/admin/departament/create-departament/create-departament.component';
import { UpdateDepartamentComponent } from './components/main/admin/departament/update-departament/update-departament.component';
import { CreateJobComponent } from './components/main/admin/jobs/create-job/create-job.component';
import { JobItemComponent } from './components/main/admin/jobs/job-item/job-item.component';
import { JobsComponent } from './components/main/admin/jobs/jobs/jobs.component';
import { UpdateJobComponent } from './components/main/admin/jobs/update-job/update-job.component';
import { FilterPipe } from './filters/filter.pipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RegistrationComponent } from './components/main/registration/registration.component';

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
    AnalyticsComponent,
    EmplPerDeptComponent,
    EffComponent,
    AvgSalComponent,
    CreateEmployeeComponent,
    DepartamentItemComponent,
    DepartamentsComponent,
    CreateDepartamentComponent,
    UpdateDepartamentComponent,
    CreateJobComponent,
    JobItemComponent,
    JobsComponent,
    UpdateJobComponent,
    FilterPipe,
    RegistrationComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    EmplRoutingModule,
    OAuthModule.forRoot(),
    ChartsModule,
    FormsModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

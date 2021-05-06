import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../components/main/home/home.component';
import { EmployeesComponent } from '../components/main/employees/employees.component';
import { LoginComponent } from '../components/main/login/login.component';
import { NotFoundComponent } from '../components/main/not-found/not-found.component';
import { EmployeesGuard } from '../employees.guard';
import { EmployeeInfoComponent } from '../components/main/employee-info/employee-info.component';
import { AnalyticsComponent } from '../components/main/analytics/analytics.component';
import { CreateEmployeeComponent } from '../components/main/create-employee/create-employee.component';
import { DepartamentsComponent } from '../components/main/admin/departament/departaments/departaments.component';
import { CreateDepartamentComponent } from '../components/main/admin/departament/create-departament/create-departament.component';
import { UpdateDepartamentComponent } from '../components/main/admin/departament/update-departament/update-departament.component';
import { CreateJobComponent } from '../components/main/admin/jobs/create-job/create-job.component';
import { UpdateJobComponent } from '../components/main/admin/jobs/update-job/update-job.component';
import { JobsComponent } from '../components/main/admin/jobs/jobs/jobs.component';
import { AdminGuard } from '../admin.guard';
import { RegistrationComponent } from '../components/main/registration/registration.component';

export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'employees', component: EmployeesComponent, canActivate: [EmployeesGuard] },
  { path: 'employee', component: CreateEmployeeComponent, canActivate: [EmployeesGuard] },
  { path: 'employees/:id', component: EmployeeInfoComponent, canActivate: [EmployeesGuard] },
  { path: 'analytics', component: AnalyticsComponent, canActivate: [EmployeesGuard] },
  { path: 'departaments', component: DepartamentsComponent, canActivate: [AdminGuard] },
  { path: 'departaments/:id', component: UpdateDepartamentComponent, canActivate: [AdminGuard] },
  { path: 'departament', component: CreateDepartamentComponent, canActivate: [AdminGuard] },
  { path: 'jobs', component: JobsComponent, canActivate: [AdminGuard] },
  { path: 'jobs/:id', component: UpdateJobComponent, canActivate: [AdminGuard] },
  { path: 'job', component: CreateJobComponent, canActivate: [AdminGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class EmplRoutingModule { }

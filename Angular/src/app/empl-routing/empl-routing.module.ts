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

export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'employees', component: EmployeesComponent, canActivate: [EmployeesGuard] },
  { path: 'employee', component: CreateEmployeeComponent, canActivate: [EmployeesGuard] },
  { path: 'employees/:id', component: EmployeeInfoComponent, canActivate: [EmployeesGuard] },
  { path: 'analytics', component: AnalyticsComponent, canActivate: [EmployeesGuard] },
  { path: 'login', component: LoginComponent },
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

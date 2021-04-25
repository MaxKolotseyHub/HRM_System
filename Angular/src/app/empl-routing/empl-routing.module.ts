import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../components/main/home/home.component';
import { EmployeesComponent } from '../components/main/employees/employees.component';
import { LoginComponent } from '../components/main/login/login.component';
import { NotFoundComponent } from '../components/main/not-found/not-found.component';

export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'employees', component: EmployeesComponent },
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

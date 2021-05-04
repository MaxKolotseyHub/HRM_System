import { JsonpClientBackend } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { EmployeeDto } from 'src/app/models/employeeDto';
import { EmployeeService } from 'src/app/services/employee.service';
import { fadeInOnEnterAnimation, slideInRightOnEnterAnimation } from 'angular-animations';
@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss'],
  providers: [],
  animations: [
    fadeInOnEnterAnimation(),
    slideInRightOnEnterAnimation()
  ]
})
export class EmployeesComponent implements OnInit {

  employees: EmployeeDto[] = [];
  search = '';

  constructor(private employeesSrv: EmployeeService) { }

  ngOnInit(): void {
    this.employeesSrv.getEmployees().subscribe(model => { this.employees = model; });
  }

}

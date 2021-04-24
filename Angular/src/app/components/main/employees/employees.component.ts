import { Component, OnInit } from '@angular/core';
import { EmployeeDto } from 'src/app/models/employeeDto';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {

  employees: Array<EmployeeDto>;

  constructor(private employeeSrv: EmployeeService) { }

  ngOnInit(): void {
    this.employeeSrv.getEmployees().subscribe(model => this.employees = model);
  }

}

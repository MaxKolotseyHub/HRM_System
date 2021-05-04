import { JsonpClientBackend } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { EmployeeDto } from 'src/app/models/employeeDto';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss'],
  providers: []
})
export class EmployeesComponent implements OnInit {

  employees: EmployeeDto[] = [];
  employeesCopy: EmployeeDto[];
  search: string;

  constructor(private employeesSrv: EmployeeService) { }

  ngOnInit(): void {
    this.employeesSrv.getEmployees().subscribe(model => { this.employees = model; this.employeesCopy = JSON.parse(JSON.stringify(model)) });
  }

  searching(s: string) {
    console.log(this.search);


    if (this.search.length != 0) {
      this.employees = [];

      this.employeesCopy.forEach(i => {
        if (i.FullName.includes(this.search))
          this.employees.push(i);
      })
    } else {
      this.employees = this.employeesCopy;
    }
  }
}

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

  @Input() empl: EmployeeDto;

  constructor() { }

  ngOnInit(): void {

  }


}

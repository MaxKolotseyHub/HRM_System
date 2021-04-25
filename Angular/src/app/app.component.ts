import { isNgTemplate } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { EmployeeDto } from './models/employeeDto';
import { EmployeeService } from './services/employee.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {


  constructor() {

  }

  ngOnInit(): void {
  }

  title = 'Angular';
}

import { isNgTemplate } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { EmployeeDto } from './models/employeeDto';
import { EmployeeService } from './services/employee.service';
import { LoginService } from './services/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  loggedIn: boolean;

  constructor(private loginService: LoginService) {

  }

  ngOnInit(): void {
    this.loginService.LoggedOn$.subscribe(loggedIn => this.loggedIn = loggedIn);
  }

  title = 'Angular';
}

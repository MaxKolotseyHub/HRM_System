import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { EmployeeDto } from 'src/app/models/employeeDto';

@Component({
  selector: 'app-employee-card',
  templateUrl: './employee-card.component.html',
  styleUrls: ['./employee-card.component.scss']
})
export class EmployeeCardComponent implements OnInit {

  @Input() empl: EmployeeDto;

  constructor() { }

  ngOnInit(): void {
  }

}

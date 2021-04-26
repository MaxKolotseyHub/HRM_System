import { InvokeFunctionExpr } from '@angular/compiler';
import { Component, Input, OnInit } from '@angular/core';
import { EmployeesGuard } from 'src/app/employees.guard';
import { DepartamentDto } from 'src/app/models/departaments/departamentDto';
import { EmployeeInfo } from 'src/app/models/employeeInfo';
import { EmployeeInfoDto } from 'src/app/models/EmployeeInfoDto';
import { JobDto } from 'src/app/models/jobs/jobDto';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-personal-details',
  templateUrl: './personal-details.component.html',
  styleUrls: ['./personal-details.component.scss']
})
export class PersonalDetailsComponent implements OnInit {

  @Input() employee: EmployeeInfoDto;
  @Input() departament: DepartamentDto;

  empl: EmployeeInfo;

  constructor(private employeeService: EmployeeService) {
  }

  ngOnInit(): void {
    this.empl = this.employee;
    console.log(this.empl);
  }

  updatePesonalInfo() {
    console.log(this.empl);
    this.employee.SecondName = 'Флексовый';
    this.employeeService.updatePersonalInfo(this.employee)
      .subscribe(info => console.log(info));
  }
}

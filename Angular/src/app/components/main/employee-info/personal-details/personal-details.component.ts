import { InvokeFunctionExpr } from '@angular/compiler';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { switchMap } from 'rxjs/operators';
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

  emplGroup: FormGroup;
  empl: EmployeeInfo;

  constructor(private employeeService: EmployeeService, private fb: FormBuilder, private router: Router) {
  }

  ngOnInit(): void {
    console.log(this.employee);

    this.emplGroup = this.fb.group({
      FirstName: [this.employee.FirstName, [Validators.required]],
      SecondName: [this.employee.SecondName, [Validators.required]],
      Email: [this.employee.Email, [Validators.required, Validators.email]],
      ThirdName: [this.employee.ThirdName, [Validators.required]]
    });
  }

  updatePesonalInfo() {
    if (this.emplGroup.invalid)
      return;

    this.employee.FirstName = this.emplGroup.value.FirstName;
    this.employee.SecondName = this.emplGroup.value.SecondName;
    this.employee.ThirdName = this.emplGroup.value.ThirdName;
    this.employee.Email = this.emplGroup.value.Email;
    this.employeeService.updatePersonalInfo(this.employee).subscribe();
  }

  fire() {
    this.employeeService.fire(this.employee.Id).subscribe(_ => this.router.navigate(['employees']));
  }
}

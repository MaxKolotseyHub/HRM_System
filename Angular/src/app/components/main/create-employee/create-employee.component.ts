import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DepartamentDto } from 'src/app/models/departaments/departamentDto';
import { JobDto } from 'src/app/models/jobs/jobDto';
import { DepartamentService } from 'src/app/services/departament.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { JobsService } from 'src/app/services/jobs.service';

@Component({
  selector: 'app-create-employee',
  templateUrl: './create-employee.component.html',
  styleUrls: ['./create-employee.component.scss']
})
export class CreateEmployeeComponent implements OnInit {

  emplGroup: FormGroup;
  departaments: DepartamentDto[] = [];
  jobs: JobDto[] = [];
  loading = false;

  constructor(
    private departamentsService: DepartamentService,
    private jobsService: JobsService,
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.departamentsService.getAll().subscribe(data => this.departaments = data);
    this.jobsService.getAll().subscribe(data => {
      this.jobs = data;
    });

    this.emplGroup = this.fb.group({
      FirstName: ['', [Validators.required]],
      SecondName: ['', [Validators.required]],
      ThirdName: ['', [Validators.required]],
      Email: ['', [Validators.required, Validators.email]],
      PhoneNumber: ['', [Validators.required]],
      Birthday: ['', [Validators.required]],
      HireDate: ['', [Validators.required]],
      Efficiency: [100, [Validators.required]],
      DepartamentId: ['', [Validators.required]],
      JobId: ['', [Validators.required]],
      Salary: ['', [Validators.required]]
    });

  }

  createEmployee() {
    this.loading = true;
    this.employeeService.createEmployee(this.emplGroup.getRawValue()).subscribe(res => this.router.navigate(["employees"]), _ => this.loading = false, () => this.loading = false);
  }
}

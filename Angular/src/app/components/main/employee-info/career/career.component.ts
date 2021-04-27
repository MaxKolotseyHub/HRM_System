import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DepartamentDto } from 'src/app/models/departaments/departamentDto';
import { EmployeeInfoDto } from 'src/app/models/EmployeeInfoDto';
import { JobDto } from 'src/app/models/jobs/jobDto';
import { DepartamentService } from 'src/app/services/departament.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { JobsService } from 'src/app/services/jobs.service';

@Component({
  selector: 'app-career',
  templateUrl: './career.component.html',
  styleUrls: ['./career.component.scss']
})
export class CareerComponent implements OnInit {

  @Input() job: JobDto;
  @Input() employee: EmployeeInfoDto;
  @Input() departament: DepartamentDto;
  selectedDept: DepartamentDto;
  originalEmployee: EmployeeInfoDto;
  departaments: DepartamentDto[] = [];
  jobs: JobDto[] = [];

  jobGroup: FormGroup;
  efficiencyGroup: FormGroup;
  yearBonus: number;

  constructor(private departamentsService: DepartamentService, private jobsService: JobsService, private fb: FormBuilder, private employeeService: EmployeeService) {
    this.jobGroup = this.fb.group({
      selectedDept: ['', [Validators.required]],
      selectedJob: ['', [Validators.required]],
      Salary: ['', [Validators.required]]
    });
    this.efficiencyGroup = this.fb.group({
      Efficiency: ['', [Validators.required, Validators.min(0)]]
    });
  }

  ngOnInit(): void {
    this.departamentsService.getAll().subscribe(data => this.departaments = data);
    this.jobsService.getAll().subscribe(data => this.jobs = data);
  }

  changeJobInfo() {
    if (this.jobGroup.invalid)
      return;
    this.originalEmployee = JSON.parse(JSON.stringify(this.employee));
    this.employee.NewSalary = this.jobGroup.value.Salary;
    this.employee.NewDepartamentId = this.jobGroup.value.selectedDept;
    this.employee.NewJobId = this.jobGroup.value.selectedJob;

    this.employeeService.changeJobInfo(this.employee).subscribe(resp => console.log(resp));
  }

  changeEfficiency() {
    if (this.efficiencyGroup.invalid)
      return;

    this.employeeService.changeEfficiency(this.employee.Id, this.efficiencyGroup.value.Efficiency).subscribe(_ => {
      this.employee.Efficiency = this.efficiencyGroup.value.Efficiency;
      this.countBonus();
    });
  }

  countBonus() {
    this.yearBonus = this.employee.Efficiency * 12 * 0.3 * this.employee.Salary;
  }

}

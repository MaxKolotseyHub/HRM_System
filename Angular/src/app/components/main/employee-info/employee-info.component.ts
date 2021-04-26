import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { DepartamentDto } from 'src/app/models/departaments/departamentDto';
import { EmployeeInfoDto } from 'src/app/models/EmployeeInfoDto';
import { JobDto } from 'src/app/models/jobs/jobDto';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee-info',
  templateUrl: './employee-info.component.html',
  styleUrls: ['./employee-info.component.scss']
})
export class EmployeeInfoComponent implements OnInit {

  id: number;
  employee: EmployeeInfoDto;
  departament: DepartamentDto;
  job: JobDto;
  tab: number;

  constructor(private route: ActivatedRoute, private employeeService: EmployeeService) {
    route.paramMap.pipe(switchMap((params) => {
      this.id = +params.get('id');
      return this.employeeService.getEmployeeById(this.id);
    })
    ).subscribe(data => {
      this.employee = data;

      this.departament = this.employee.Depts.find((item, i, array) => item.Id == this.employee.DepartamentId);
      this.job = this.employee.Jobs.find((item, i, array) => item.Id == this.employee.JobId);
      this.tab = 1;
    });

  }

  ngOnInit(): void {

  }

  openTab(tabId: number) {
    this.tab = tabId;
  }
}

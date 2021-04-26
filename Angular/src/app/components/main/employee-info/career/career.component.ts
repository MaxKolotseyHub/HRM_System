import { Component, Input, OnInit } from '@angular/core';
import { DepartamentDto } from 'src/app/models/departaments/departamentDto';
import { EmployeeInfoDto } from 'src/app/models/EmployeeInfoDto';
import { JobDto } from 'src/app/models/jobs/jobDto';

@Component({
  selector: 'app-career',
  templateUrl: './career.component.html',
  styleUrls: ['./career.component.scss']
})
export class CareerComponent implements OnInit {

  @Input() job: JobDto;
  @Input() employee: EmployeeInfoDto;
  @Input() departament: DepartamentDto;

  constructor() { }

  ngOnInit(): void {
  }

}

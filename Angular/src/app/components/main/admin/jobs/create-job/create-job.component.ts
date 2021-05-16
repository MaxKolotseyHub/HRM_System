import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JobsService } from 'src/app/services/jobs.service';
import { jobMaxSalaryValidator } from 'src/app/validators/registration.validator';

@Component({
  selector: 'app-create-job',
  templateUrl: './create-job.component.html',
  styleUrls: ['./create-job.component.scss']
})
export class CreateJobComponent implements OnInit {

  jobGroup: FormGroup;

  constructor(private fb: FormBuilder, private jobsService: JobsService, private router: Router) { }

  ngOnInit(): void {
    this.jobGroup = this.fb.group({
      Title: ['', [Validators.required]],
      MinSalary: ['', [Validators.required, Validators.min(0)]],
      MaxSalary: ['', [Validators.required, Validators.min(0)]],
    }, { validators: jobMaxSalaryValidator });
  }

  create() {
    this.jobsService.create(this.jobGroup.getRawValue()).subscribe(_ => this.router.navigate(["jobs"]));
  }

}

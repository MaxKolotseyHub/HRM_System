import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { JobDto } from 'src/app/models/jobs/jobDto';
import { JobsService } from 'src/app/services/jobs.service';

@Component({
  selector: 'app-update-job',
  templateUrl: './update-job.component.html',
  styleUrls: ['./update-job.component.scss']
})
export class UpdateJobComponent implements OnInit {

  depGroup: FormGroup;
  id: number;
  job: JobDto;

  constructor(private fb: FormBuilder, private jobsService: JobsService, private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.depGroup = this.fb.group({
    });

    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.jobsService.getById(+this.id).subscribe(res => {
        this.job = res;
        this.depGroup.addControl('Title', new FormControl(this.job.Title, Validators.required));
        this.depGroup.addControl('Id', new FormControl(this.job.Id, Validators.required));
        this.depGroup.addControl('MinSalary', new FormControl(this.job.MinSalary, Validators.required));
        this.depGroup.addControl('MaxSalary', new FormControl(this.job.MaxSalary, Validators.required));
      });
    });

  }

  update() {
    this.jobsService.update(this.depGroup.getRawValue()).subscribe(_ => this.router.navigate(["jobs"]));
  }
}

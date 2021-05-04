import { Component, OnInit } from '@angular/core';
import { JobDto } from 'src/app/models/jobs/jobDto';
import { JobsService } from 'src/app/services/jobs.service';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.scss']
})
export class JobsComponent implements OnInit {

  jobs: JobDto[] = [];

  constructor(private jobsService: JobsService) { }

  ngOnInit(): void {
    this.jobsService.getAll().subscribe(res => this.jobs = res);

    this.jobsService.deleted$.subscribe(v => {
      if (v)
        this.jobsService.getAll().subscribe(data => this.jobs = data);
    });
  }

}

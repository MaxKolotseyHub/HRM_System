import { Component, Input, OnInit } from '@angular/core';
import { JobDto } from 'src/app/models/jobs/jobDto';
import { JobsService } from 'src/app/services/jobs.service';

@Component({
  selector: 'app-job-item',
  templateUrl: './job-item.component.html',
  styleUrls: ['./job-item.component.scss']
})
export class JobItemComponent implements OnInit {

  @Input() job: JobDto;

  constructor(private jobsService: JobsService) { }

  ngOnInit(): void {

  }
  delete() {
    this.jobsService.delete(this.job.Id).subscribe(_ => this.jobsService.deleted());
  }
}

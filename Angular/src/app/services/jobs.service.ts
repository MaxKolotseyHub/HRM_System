import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { JobDto } from '../models/jobs/jobDto';

@Injectable({
  providedIn: 'root'
})
export class JobsService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<JobDto[]>(`${environment.backendUrl}/api/jobs`)
  }
}

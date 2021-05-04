import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { share } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { JobDto } from '../models/jobs/jobDto';

@Injectable({
  providedIn: 'root'
})
export class JobsService {

  constructor(private http: HttpClient) { }
  private deleteSubj = new BehaviorSubject<boolean>(false);

  getAll() {
    return this.http.get<JobDto[]>(`${environment.backendUrl}/api/jobs`).pipe(share());
  }


  get deleted$() {
    return this.deleteSubj.asObservable();
  }

  deleted() {
    this.deleteSubj.next(true);
  }

  delete(id: number) {
    return this.http.delete(`${environment.backendUrl}/api/jobs/${id}`);
  }

  create(model: string) {
    return this.http.post(`${environment.backendUrl}/api/jobs`, model);
  }

  getById(id: number) {
    return this.http.get<JobDto>(`${environment.backendUrl}/api/jobs/${id}`);
  }

  update(model: string) {
    return this.http.put(`${environment.backendUrl}/api/jobs`, model);
  }
}

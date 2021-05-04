import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DepartamentDto } from '../models/departaments/departamentDto';

@Injectable({
  providedIn: 'root'
})
export class DepartamentService {

  constructor(private http: HttpClient) { }

  private deleteSubj = new BehaviorSubject<boolean>(false);

  getAll() {
    return this.http.get<DepartamentDto[]>(`${environment.backendUrl}/api/departaments`);
  }

  getById(id: number) {
    return this.http.get<DepartamentDto>(`${environment.backendUrl}/api/departaments/${id}`);
  }

  delete(id: number) {
    return this.http.delete(`${environment.backendUrl}/api/departaments/${id}`);
  }

  create(model: string) {
    return this.http.post(`${environment.backendUrl}/api/departaments`, model);
  }

  update(model: DepartamentDto) {
    return this.http.put(`${environment.backendUrl}/api/departaments`, model);
  }

  get deleted$() {
    return this.deleteSubj.asObservable();
  }

  deleted() {
    this.deleteSubj.next(true);
  }

}

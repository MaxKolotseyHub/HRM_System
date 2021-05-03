import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { share } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { DepartamentDto } from '../models/departaments/departamentDto';

@Injectable({
  providedIn: 'root'
})
export class DepartamentService {

  constructor(private http: HttpClient) { }


  getAll() {
    return this.http.get<DepartamentDto[]>(`${environment.backendUrl}/api/departaments`).pipe(share());
  }

}

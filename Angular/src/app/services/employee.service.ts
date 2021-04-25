import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { EmployeeDto } from '../models/employeeDto';
import { EmployeeInfoDto } from '../models/EmployeeInfoDto';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  getEmployees() {
    return this.http.get<Array<EmployeeDto>>(`${environment.backendUrl}/api/employees`);
  }

  getEmployeeById(id: number) {
    return this.http.get<EmployeeInfoDto>(`${environment.backendUrl}/api/employees/${id}`);
  }

  updatePersonalInfo(model: EmployeeInfoDto) {
    return this.http.post(`${environment.backendUrl}/api/employees/info`, model)
  }
}

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { EmployeeDto } from '../models/employeeDto';
import { EmployeeInfoDto } from '../models/EmployeeInfoDto';
import { VacationDto } from '../models/vacation/vacationDto';

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

  getVacation(id: number) {
    return this.http.get<VacationDto>(`${environment.backendUrl}/api/employees/vacation/${id}`)
  }

  startVacation(model: VacationDto) {
    return this.http.post<VacationDto>(`${environment.backendUrl}/api/employees/vacation`, model, {
      headers: {
        'Accept': '*/*',
        'Accept-Language': 'ru-BY,ru;q=0.9,en-GB;q=0.8,en;q=0.7,ru-RU;q=0.6,en-US;q=0.5',
        'Content-Type': 'application/json'
      }
    })
  }

  changeJobInfo(model: EmployeeInfoDto) {
    return this.http.post(`${environment.backendUrl}/api/employees`, model)
  }

  changeEfficiency(id: number, val: number) {
    return this.http.get(`${environment.backendUrl}/api/employees/efficiency?id=${id}&efficiency=${val}`)
  }
}

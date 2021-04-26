import { Component, Input, OnInit } from '@angular/core';
import { VacationDto } from 'src/app/models/vacation/vacationDto';
import { EmployeeService } from 'src/app/services/employee.service';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-vacation',
  templateUrl: './vacation.component.html',
  styleUrls: ['./vacation.component.scss']
})
export class VacationComponent implements OnInit {

  @Input() id: number;
  vacation: VacationDto;
  vacationGroup: FormGroup;


  constructor(private employeeService: EmployeeService, private fb: FormBuilder) {
    this.vacationGroup = this.fb.group({
      StartDate: ['', [Validators.required]],
      EndDate: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    this.employeeService.getVacation(this.id).subscribe(data => this.vacation = data);
  }

  startVacation() {
    this.vacation.StartDate = this.vacationGroup.value.StartDate;
    this.vacation.EndDate = this.vacationGroup.value.EndDate;
    console.log(this.vacation);
    this.employeeService.startVacation(this.vacation).subscribe(response => console.log(response));
  }
}

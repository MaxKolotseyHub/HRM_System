import { ReturnStatement } from '@angular/compiler';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ChartDataSets, ChartType } from 'chart.js';
import { BaseChartDirective, Label, MultiDataSet } from 'ng2-charts';
import { map, switchMap } from 'rxjs/operators';
import { DepartamentDto } from 'src/app/models/departaments/departamentDto';
import { EmployeeDto } from 'src/app/models/employeeDto';
import { EmployeeInfo } from 'src/app/models/employeeInfo';
import { DepartamentService } from 'src/app/services/departament.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { SidebarService } from 'src/app/services/sidebar.service';

@Component({
  selector: 'app-analytics',
  templateUrl: './analytics.component.html',
  styleUrls: ['./analytics.component.scss']
})
export class AnalyticsComponent implements OnInit {

  emps: EmployeeDto[] = [];
  deps: DepartamentDto[] = [];

  doughnutChartLabels: Label[] = [];
  doughnutChartData: MultiDataSet = [];
  doughnutChartLabelsSal: Label[] = [];
  doughnutChartDataSal: MultiDataSet = [];

  barChartLabels: Label[] = [];
  barChartData: ChartDataSets[] = [];
  showEmpDep = false;
  showEff = false;
  showSal = false;
  currentChartTitle = '';

  constructor(private empService: EmployeeService, private deptService: DepartamentService, private sidebarService: SidebarService) { }
  ngOnInit(): void {
    this.empService.getEmployees().pipe(switchMap(emps => {
      this.emps = emps;
      return this.deptService.getAll();
    })).subscribe(deps => {
      this.deps = deps;
      this.avgSal();
    });
  }

  avgSal() {
    this.currentChartTitle = 'Средний оклад';
    this.parseSal();
    this.showEff = false;
    this.showEmpDep = false;
    this.showSal = true;
  }

  empDep() {
    this.currentChartTitle = 'Сотрудники по департаментам';
    this.parseEmps();

    this.showEff = false;
    this.showSal = false;
    this.showEmpDep = true;
  }

  eff() {
    this.currentChartTitle = 'Эффективность';
    let data = [];
    let label = 'Эффективность';

    if (this.barChartLabels.length == 0) {
      this.emps.forEach(e => {
        this.barChartLabels.push(e.FullName);
        data.push(e.Efficiency);
      });

      this.barChartData.push({ data: data, label: label });
    }
    this.showEmpDep = false;
    this.showSal = false;
    this.showEff = true;
  }

  parseEmps() {
    if (this.doughnutChartData.length > 0)
      return;
    let data = [];
    this.deps.forEach(x => {
      let count = 0;
      this.emps.forEach(i => {
        if (i.DepartamentTitle == x.Title)
          count++;
      });
      this.doughnutChartLabels.push(x.Title);
      data.push(count);
    });
    this.doughnutChartData.push(data);
  }


  parseSal() {
    if (this.doughnutChartDataSal.length > 0)
      return;
    let data = [];
    this.deps.forEach(x => {
      let count = 0;
      let sal = 0;
      this.emps.forEach(i => {
        if (i.DepartamentTitle == x.Title) {
          sal += i.Salary;
          count++;
        }
      });
      this.doughnutChartLabelsSal.push(x.Title);
      data.push(sal / count);
    });
    this.doughnutChartDataSal.push(data);
  }

}

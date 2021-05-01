import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ChartType } from 'chart.js';
import { BaseChartDirective, Label, MultiDataSet } from 'ng2-charts';

@Component({
  selector: 'app-empl-per-dept',
  templateUrl: './empl-per-dept.component.html',
  styleUrls: ['./empl-per-dept.component.scss']
})
export class EmplPerDeptComponent implements OnInit {


  @Input() doughnutChartLabels: Label[] = [];
  @Input() doughnutChartData: MultiDataSet = [];
  doughnutChartType: ChartType = 'doughnut';
  constructor() { }

  ngOnInit(): void {
  }

}

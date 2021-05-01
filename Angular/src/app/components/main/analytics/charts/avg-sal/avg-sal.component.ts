import { Component, Input, OnInit } from '@angular/core';
import { ChartType } from 'chart.js';
import { Label, MultiDataSet } from 'ng2-charts';

@Component({
  selector: 'app-avg-sal',
  templateUrl: './avg-sal.component.html',
  styleUrls: ['./avg-sal.component.scss']
})
export class AvgSalComponent implements OnInit {

  @Input() doughnutChartLabels: Label[] = [];
  @Input() doughnutChartData: MultiDataSet = [];
  doughnutChartType: ChartType = 'doughnut';

  constructor() { }

  ngOnInit(): void {
  }

}

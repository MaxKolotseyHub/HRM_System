import { Component, Input, OnInit } from '@angular/core';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';

@Component({
  selector: 'app-eff',
  templateUrl: './eff.component.html',
  styleUrls: ['./eff.component.scss']
})
export class EffComponent implements OnInit {

  barChartOptions: ChartOptions = {
    responsive: true,
  };
  barChartType: ChartType = 'bar';
  barChartLegend = true;
  barChartPlugins = [];

  @Input() barChartLabels: Label[] = [];
  @Input() barChartData: ChartDataSets[] = [
    { data: [45, 37, 60, 70, 46, 33], label: 'Best Fruits' }
  ];

  constructor() { }

  ngOnInit(): void {
  }

}

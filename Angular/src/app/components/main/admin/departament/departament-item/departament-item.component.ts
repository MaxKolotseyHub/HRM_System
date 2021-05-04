import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DepartamentDto } from 'src/app/models/departaments/departamentDto';
import { DepartamentService } from 'src/app/services/departament.service';

@Component({
  selector: 'app-departament-item',
  templateUrl: './departament-item.component.html',
  styleUrls: ['./departament-item.component.scss']
})
export class DepartamentItemComponent implements OnInit {

  @Input() departament: DepartamentDto;

  constructor(private departamentService: DepartamentService, private route: Router) { }

  ngOnInit(): void {
  }

  delete() {
    this.departamentService.delete(this.departament.Id).subscribe(_ => this.departamentService.deleted());
  }

}

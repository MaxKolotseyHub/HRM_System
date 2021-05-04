import { Component, OnInit } from '@angular/core';
import { DepartamentDto } from 'src/app/models/departaments/departamentDto';
import { DepartamentService } from 'src/app/services/departament.service';

@Component({
  selector: 'app-departaments',
  templateUrl: './departaments.component.html',
  styleUrls: ['./departaments.component.scss']
})
export class DepartamentsComponent implements OnInit {

  departaments: DepartamentDto[] = [];

  constructor(private departamentService: DepartamentService) { }

  ngOnInit(): void {
    this.departamentService.getAll().subscribe(data => this.departaments = data);

    this.departamentService.deleted$.subscribe(v => {
      if (v)
        this.departamentService.getAll().subscribe(data => this.departaments = data);
    });
  }

}

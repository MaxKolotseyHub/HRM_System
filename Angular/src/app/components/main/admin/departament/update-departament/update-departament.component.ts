import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DepartamentDto } from 'src/app/models/departaments/departamentDto';
import { DepartamentService } from 'src/app/services/departament.service';

@Component({
  selector: 'app-update-departament',
  templateUrl: './update-departament.component.html',
  styleUrls: ['./update-departament.component.scss']
})
export class UpdateDepartamentComponent implements OnInit {

  depGroup: FormGroup;
  id: number;
  departament: DepartamentDto;

  constructor(private fb: FormBuilder, private departamentService: DepartamentService, private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.departamentService.getById(+this.id).subscribe(res => this.departament = res);

      this.depGroup = this.fb.group({
        Title: ['', [Validators.required]]
      });
    });

  }

  update() {
    this.departament.Title = this.depGroup.value.Title;
    this.departamentService.update(this.departament).subscribe(_ => this.router.navigate(["departaments"]));
  }

}

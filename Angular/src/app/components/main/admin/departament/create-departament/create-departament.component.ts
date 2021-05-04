import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DepartamentService } from 'src/app/services/departament.service';

@Component({
  selector: 'app-create-departament',
  templateUrl: './create-departament.component.html',
  styleUrls: ['./create-departament.component.scss']
})
export class CreateDepartamentComponent implements OnInit {

  depGroup: FormGroup;

  constructor(private fb: FormBuilder, private departamentService: DepartamentService, private router: Router) { }

  ngOnInit(): void {
    this.depGroup = this.fb.group({
      Title: ['', [Validators.required]]
    });
  }

  create() {
    this.departamentService.create(this.depGroup.getRawValue()).subscribe(_ => this.router.navigate(["departaments"]));
  }

}

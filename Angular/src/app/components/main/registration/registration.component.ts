import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  loginGroup: FormGroup;

  constructor(private loginService: LoginService, private router: Router, private fb: FormBuilder) {
    this.loginGroup = this.fb.group({
      Email: ['', [Validators.required]],
      Password: ['', [Validators.required]],
      ConfirmPassword: ['', [Validators.required]]
    });

  }
  ngOnInit(): void {
  }

  register() {
    this.loginService.register(this.loginGroup.getRawValue()).subscribe(v => this.router.navigate(['login']));
  }

}

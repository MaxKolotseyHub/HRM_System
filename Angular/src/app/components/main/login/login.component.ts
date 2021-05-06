import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginGroup: FormGroup;

  constructor(private loginService: LoginService, private router: Router, private fb: FormBuilder) {
    this.loginGroup = this.fb.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });

  }

  ngOnInit(): void {
    this.loginService.LoggedOn$.pipe(filter(_ => _)).subscribe(_ => {
      this.loginService.getClaims();
      this.router.navigate(['home']);
    });
  }

  login() {
    this.loginService.login(this.loginGroup.value.email, this.loginGroup.value.password);
  }

  register() {
    this.router.navigate(['registration']);
  }
}

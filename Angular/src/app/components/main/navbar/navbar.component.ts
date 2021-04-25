import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  loggedIn: boolean;
  constructor(private loginSrvice: LoginService) { }

  ngOnInit(): void {
    this.loginSrvice.LoggedOn$.subscribe(loggedIn => {
      this.loggedIn = loggedIn;
    });
  }

  logout() {
    this.loginSrvice.logout();
  }
}

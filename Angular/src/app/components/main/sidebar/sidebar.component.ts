import { Component, OnInit } from '@angular/core';
import { filter } from 'rxjs/operators';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  showAdminTools: boolean;

  constructor(private loginSrv: LoginService) { }

  ngOnInit(): void {
    this.loginSrv.IsAdmin$.subscribe(res => this.showAdminTools = res);
  }

}

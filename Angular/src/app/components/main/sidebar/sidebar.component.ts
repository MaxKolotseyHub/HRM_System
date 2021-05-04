import { Component, OnInit } from '@angular/core';
import { filter } from 'rxjs/operators';
import { LoginService } from 'src/app/services/login.service';
import { SidebarService } from 'src/app/services/sidebar.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  showAdminTools: boolean;
  collapseSubMenu = false;


  constructor(private loginSrv: LoginService, private sidebarService: SidebarService) { }

  ngOnInit(): void {
    this.loginSrv.IsAdmin$.subscribe(res => this.showAdminTools = res);
  }

  collapse() {
    this.collapseSubMenu = !this.collapseSubMenu;
  }

  changeChart(id: number) {
    this.sidebarService.changeChart(id);
  }
}

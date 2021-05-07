import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthConfig, OAuthService } from 'angular-oauth2-oidc';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ClaimDto } from '../models/claimsDto';
import { UserDto } from '../models/userDto';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private loggedOnSubject = new BehaviorSubject<boolean>(false);
  private isAdminSubject = new BehaviorSubject<boolean>(false);
  private user: UserDto;
  isAdmin = false;
  constructor(private http: HttpClient) { }

  get LoggedOn$() {
    return this.loggedOnSubject.asObservable();
  }

  get IsAdmin$() {
    return this.isAdminSubject.asObservable();
  }

  login(userName?: string, password?: string) {

    this.http.post<UserDto>(environment.backendUrl + '/Token',
      "userName=" + encodeURIComponent(userName) +
      "&password=" + encodeURIComponent(password) +
      "&grant_type=password",
      { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).subscribe(res => {
        this.user = res;
        this.loggedOnSubject.next(true)
      });
  }

  getClaims() {
    this.http.get<ClaimDto[]>(environment.backendUrl + '/api/claims', {
      headers: {
        'Authorization': 'Bearer ' + this.user.access_token
      }
    }).subscribe(res => {
      this.isAdmin = res.some((item) => item.value == 'admin');
      this.isAdminSubject.next(this.isAdmin);
    });
  }

  logout() {
    this.user = null;
    this.loggedOnSubject.next(false);
  }

  get LoggedOn() {
    return this.loggedOnSubject.value;
  }

  register(model: string) {
    return this.http.post(`${environment.backendUrl}/api/Account/Register`, model);
  }
}

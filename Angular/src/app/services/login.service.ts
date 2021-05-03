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

  private loggedOnSubject = new BehaviorSubject<boolean>(true);
  private isAdminSubject = new BehaviorSubject<boolean>(true);
  private user: UserDto;
  isAdmin: boolean;
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
        console.log(res);
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
      if (res.find((item) => item.value == 'admin'))
        this.isAdmin = true;
      else this.isAdmin = false;
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
}
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserDto } from '../models/userDto';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private loggedOnSubject = new BehaviorSubject<boolean>(true);
  private user: UserDto;
  constructor() { }

  get LoggedOn$() {
    return this.loggedOnSubject.asObservable();
  }

  login(userName?: string, password?: string) {
    setTimeout(() => {
      this.user = { fullName: 'test user', id: 1 };
      this.loggedOnSubject.next(true);
    }, 1000)
  }

  logout() {
    this.user = null;
    this.loggedOnSubject.next(false);
  }

  get LoggedOn() {
    return this.loggedOnSubject.value;
  }
}

import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SidebarService {

  analitycsSubj = new BehaviorSubject<number>(1);

  constructor() { }

  get analitycs$() {
    return this.analitycsSubj.asObservable();
  }

  changeChart(id: number) {
    this.analitycsSubj.next(id);
  }
}

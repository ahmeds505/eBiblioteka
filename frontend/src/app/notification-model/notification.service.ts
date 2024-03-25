import { Injectable } from '@angular/core';
import {BehaviorSubject} from "rxjs";
import {NotificationModel} from "./notification-model";

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  notifications$: BehaviorSubject<NotificationModel> = new BehaviorSubject<NotificationModel>(null);
  constructor() { }

  setNotification(notification: NotificationModel){
    this.notifications$.next(notification);
  }

  getNotification(){
    return this.notifications$.asObservable();
  }
}

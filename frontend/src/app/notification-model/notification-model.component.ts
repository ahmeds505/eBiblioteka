import { Component, OnInit } from '@angular/core';
import {NotificationModel} from "./notification-model";
import {Subscription} from "rxjs";
import {NotificationService} from "./notification.service";

@Component({
  selector: 'app-notification-model',
  templateUrl: './notification-model.component.html',
  styleUrls: ['./notification-model.component.css']
})
export class NotificationModelComponent implements OnInit {

  showPanel: boolean;
  notification: NotificationModel;
  notificationSub: Subscription;

  constructor(private notificationService: NotificationService) { }

  ngOnInit(): void {
    this.notificationSub =
      this.notificationService.getNotification().subscribe(
        (notification) => {
          this.notification = notification;
          this.showPanel = notification !== null;
        }
      )
  }

  dismissNotification(){
    this.showPanel = false;
  }

  ngOnDestroy() {
    this.notificationSub.unsubscribe();
  }

}

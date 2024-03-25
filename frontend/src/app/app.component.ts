import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {LoginComponent} from "./login/login.component";
import {MojConfig} from "./moj-config";
import {Router} from "@angular/router";
import {AngularFireMessaging} from "@angular/fire/compat/messaging";
import {NotificationService} from "./notification-model/notification.service";
import {AutorizacijaAdminService} from "./_guards/autorizacija-admin.service";
import {canActivate} from "@angular/fire/auth-guard";
import {LoginInformacije} from "./_login-help/login-informacije";
import {AutentifikacijaHelper} from "./_login-help/autentifikacija-helper";
import { TranslateService } from '@ngx-translate/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  tokenBaza:any;

  lang = '';

  constructor
  (
    private translateService: TranslateService,
    private http: HttpClient,
    private router: Router,
    private afMessaging: AngularFireMessaging,
    private notificationService: NotificationService
  ) 
  {
    this.translateService.setDefaultLang('bs');
    this.translateService.use(localStorage.getItem('lang') || 'bs');

  }

  ngOnInit(): void{
    this.requestPermission();
    this.listen();

    this.lang = localStorage.getItem('lang') || 'bs';
  }
  title = 'e-Biblioteka';

  provjeraKorisnik(): LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }


  odjava() {
    this.http.post(MojConfig.adresa_servera_localhost + "/AutentifikacijaTokens/Logout", MojConfig.http_opcije()).subscribe();
    localStorage.removeItem("autentifikacija-token");
    this.router.navigateByUrl("/pocetna");

  }

  requestPermission(){
    this.afMessaging.requestToken.subscribe(
      (token:string)=>{
        console.log("permission granted");
        console.log(token);
      },
      (error:any) => {console.log(error);}
    )
  }

  listen(){
    this.afMessaging.messages.subscribe((messages: any) => {
      console.log(messages);

      this.notificationService.setNotification({
        body: messages.notification.body,
        title: messages.notification.title,
        isVisible: true
      })
    });
  }

  changeLang(lang:any){
    const selectedLang = lang.target.value;

    localStorage.setItem('lang', selectedLang);

    this.translateService.use(selectedLang);

  }
}


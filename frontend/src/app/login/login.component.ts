import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import {AppComponent} from "../app.component";
import {AutentifikacijaHelper} from "../_login-help/autentifikacija-helper";
import {LoginInformacije} from "../_login-help/login-informacije";


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  txtKorisnickoIme: any;
  txtLozinka: any;
  token:any;
  static loginInformacije: LoginInformacije;

  korisnikPodaci: any;
  loginInfo: LoginInformacije;


  constructor(private http:HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  Login() {
    let objekat={
      korisnickoIme:this.txtKorisnickoIme,
      lozinka:this.txtLozinka
    };

    this.http.post<LoginInformacije>(MojConfig.adresa_servera_localhost + "/AutentifikacijaTokens/Login", objekat)
      .subscribe((x:any) =>{
        if(x!=null) {
          LoginComponent.loginInformacije = x;
          AutentifikacijaHelper.setLoginInfo(x);
          //localStorage.setItem("autentifikacija-token", x.vrijednost);
          //this.token = localStorage.getItem("autentifikacija-token");


          this.router.navigateByUrl('/pocetna');

        }
        else {
          localStorage.setItem("autentifikacija-token", "");
          alert("Neispravan login ili račun nije aktiviran");
        }
      });


  }




}

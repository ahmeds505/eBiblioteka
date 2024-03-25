import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {AutentifikacijaHelper} from "../_login-help/autentifikacija-helper";
import {reload} from "@angular/fire/auth";
import {waitForAsync} from "@angular/core/testing";
import {observeOn} from "rxjs";

@Component({
  selector: 'app-biblioteka',
  templateUrl: './biblioteka.component.html',
  styleUrls: ['./biblioteka.component.css']
})
export class BibliotekaComponent implements OnInit {

  bibliotekaPodaci:any;
  loginInfo = AutentifikacijaHelper.getLoginInfo();
  response: any;
  alert = false;
  info = false;
  obavijest= false;


  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.preuzmiPodatke();
  }

  preuzmiPodatke(){
    this.httpKlijent.get(MojConfig.adresa_servera_localhost + "/Knjiga/GetAllBySekcija/" + "Biblioteka", MojConfig.http_opcije())
      .subscribe((x:any) => {
        this.bibliotekaPodaci = x;
      });
  }

  iznajmi(x:any) {
    let mojConfig = MojConfig.http_opcije();

    this.httpKlijent.post(MojConfig.adresa_servera_localhost + "/Knjiga/IznajmiKnjigu/" + x.id + "," + this.loginInfo.korisnikId, x, MojConfig.http_opcije())
      .subscribe(()=>{},
          (error)  => {
          console.log(error);
          if(error.status == 400)
          {
            this.obavijest = true;
            if(error.error == "2")
            {
              this.response = "maksimalan broj knjiga iznajmljen";
            }
            else if(error.error == "1")
            {
              this.response = "nema knjiga na stanju";
            }
          }
          else if(error.status == 200)
          {
            this.obavijest = true;
            this.response = "knjiga uspjesno iznajmljena";

          }

        }
      );

     //
  }

  zatvoriModal()
  {
    this.obavijest = false;

  }
  alertClose()
  {
    this.alert = false;
    this.info = false;
  }

}

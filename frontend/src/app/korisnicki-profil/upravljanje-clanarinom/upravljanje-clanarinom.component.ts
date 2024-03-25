import { Component, OnInit } from '@angular/core';
import {AutentifikacijaHelper} from "../../_login-help/autentifikacija-helper";
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-upravljanje-clanarinom',
  templateUrl: './upravljanje-clanarinom.component.html',
  styleUrls: ['./upravljanje-clanarinom.component.css']
})
export class UpravljanjeClanarinomComponent implements OnInit {

  loginInfo = AutentifikacijaHelper.getLoginInfo();
  korisnikPodaci: any;
  date : Date;

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    this.getPodaci();
  }

  getPodaci(){
    this.http.get(MojConfig.adresa_servera_localhost + "/EndUser/GetById/" + this.loginInfo.korisnikId, MojConfig.http_opcije()).subscribe((vrijednost:any)=> {
      this.korisnikPodaci = vrijednost;
    });

  }

  getDatum(x:any)
  {
    this.date = new Date(x);

    return this.date.toLocaleDateString();
  }

}

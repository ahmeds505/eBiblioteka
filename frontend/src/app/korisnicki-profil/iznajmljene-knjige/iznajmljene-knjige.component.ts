import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";
import {AutentifikacijaHelper} from "../../_login-help/autentifikacija-helper";

@Component({
  selector: 'app-iznajmljene-knjige',
  templateUrl: './iznajmljene-knjige.component.html',
  styleUrls: ['./iznajmljene-knjige.component.css']
})
export class IznajmljeneKnjigeComponent implements OnInit {

  loginInfo= AutentifikacijaHelper.getLoginInfo();
  podaci:any;
  date: Date;
  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.getPodaci();
  }

  getPodaci(){
    this.httpKlijent.get(MojConfig.adresa_servera_localhost + "/Knjiga/GetIznajmljeneById/" + this.loginInfo.korisnikId, MojConfig.http_opcije())
        .subscribe((result:any)=>{
          this.podaci = result;
        });


  }

getDatum(x:any)
{
  this.date = new Date(x);

  return this.date.toLocaleDateString();
}
}

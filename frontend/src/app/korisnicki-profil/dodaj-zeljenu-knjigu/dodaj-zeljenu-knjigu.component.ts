import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MojConfig } from 'src/app/moj-config';
import {AutentifikacijaHelper} from "../../_login-help/autentifikacija-helper";
import {Router} from "@angular/router";

@Component({
  selector: 'app-dodaj-zeljenu-knjigu',
  templateUrl: './dodaj-zeljenu-knjigu.component.html',
  styleUrls: ['./dodaj-zeljenu-knjigu.component.css']
})
export class DodajZeljenuKnjiguComponent implements OnInit {

  nazivKnjige:string="";
  imePisca:string="";
  prezimePisca:string="";


  loginInfo = AutentifikacijaHelper.getLoginInfo();

  constructor(private http:HttpClient, private router: Router) { }

  ngOnInit(): void {


  }
  dodajKnjigu(){
    let knjiga={
      nazivKnjige: this.nazivKnjige,
      imePisca: this.imePisca,
      prezimePisca: this.prezimePisca
    }

    if(knjiga.nazivKnjige != "" && knjiga.imePisca != "" && knjiga.prezimePisca != "")
    {
        this.http.post(MojConfig.adresa_servera_localhost + "/EndUser/AddKnjigaListaZelja/" + this.loginInfo.korisnikId, knjiga, MojConfig.http_opcije()).subscribe();

        this.router.navigateByUrl('/korisnicki-profil');

    }
    // else
    // {
    //   alert("popunite sva polja!")
    // }


  }

}

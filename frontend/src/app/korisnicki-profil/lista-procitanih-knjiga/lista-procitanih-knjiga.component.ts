import { Component, OnInit } from '@angular/core';
import { HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";
import {AutentifikacijaHelper} from "../../_login-help/autentifikacija-helper";

@Component({
  selector: 'app-lista-procitanih-knjiga',
  templateUrl: './lista-procitanih-knjiga.component.html',
  styleUrls: ['./lista-procitanih-knjiga.component.css']
})
export class ListaProcitanihKnjigaComponent implements OnInit {

  procitaneKnjige: any;
  searchKnjige:string = "";
  loginInfo = AutentifikacijaHelper.getLoginInfo();

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    this.getKnjige();
  }

  getKnjige(){
    this.http.get(MojConfig.adresa_servera_localhost + "/Knjiga/GetProcitane/" + this.loginInfo.korisnikId, MojConfig.http_opcije()).subscribe((x:any)=>{
      this.procitaneKnjige = x;
    })
  }
  filterKnjige(){
    return this.procitaneKnjige.filter((x:any) =>
    x.knjiga.naslov.toLowerCase().startsWith(this.searchKnjige.toLowerCase())
    || x.knjiga.imePisca.toLowerCase().startsWith(this.searchKnjige.toLowerCase())
    || x.knjiga.prezimePisca.toLowerCase().startsWith(this.searchKnjige.toLowerCase())
    );

  }

}

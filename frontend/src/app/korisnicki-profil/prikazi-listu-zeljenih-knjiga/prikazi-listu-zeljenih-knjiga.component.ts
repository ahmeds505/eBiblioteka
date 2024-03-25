import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";
import {AutentifikacijaHelper} from "../../_login-help/autentifikacija-helper";

@Component({
  selector: 'app-prikazi-listu-zeljenih-knjiga',
  templateUrl: './prikazi-listu-zeljenih-knjiga.component.html',
  styleUrls: ['./prikazi-listu-zeljenih-knjiga.component.css']
})
export class PrikaziListuZeljenihKnjigaComponent implements OnInit {

  searchLista:string = "";
  lista:any;
  loginInfo = AutentifikacijaHelper.getLoginInfo();

  constructor(private http: HttpClient) { }

  ngOnInit(): void {

    this.http.get(MojConfig.adresa_servera_localhost + "/EndUser/GetListaZelja/" + this.loginInfo.korisnikId, MojConfig.http_opcije()).subscribe((x:any)=>{
      this.lista = x;
    });
  }

  getLista() {
    return this.lista.filter((x:any) =>
      x.nazivKnjige.toLowerCase().startsWith(this.searchLista.toLowerCase()) ||
        x.imePisca.toLowerCase().startsWith(this.searchLista.toLowerCase()) ||
      x.prezimePisca.toLowerCase().startsWith(this.searchLista.toLowerCase())
    );


  }
}

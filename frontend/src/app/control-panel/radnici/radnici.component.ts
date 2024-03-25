import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";

@Component({
  selector: 'app-radnici',
  templateUrl: './radnici.component.html',
  styleUrls: ['./radnici.component.css']
})
export class RadniciComponent implements OnInit {
  radniciPodaci: any;
  odjeljenjaPodaci: any;
  radnoMjestoPodaci: any;
  odabraniRadnik = {
    prikazi: false
  }

  txtIme: any;
  txtPrezime: any;
  txtEmail: any;
  txtAdresa: any;
  txtGrad: any;
  txtPbroj: any;
  txtOdjeljenje: any;
  txtPozicija: any;
  OdjeljenjeSelected: any;
  PozicijaSelected: any;
  txtLozinka: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getRadnici();
    this.getOdjeljenja();
    this.getRadnoMjesto();
  }

  getRadniciSearch() {

  }

  getRadnici() {
    return this.http.get(MojConfig.adresa_servera_localhost + "/Radnik/GetAll", MojConfig.http_opcije())
      .subscribe( x=> {
      this.radniciPodaci = x;
    });
  }

  getOdjeljenja(){
    return this.http.get(MojConfig.adresa_servera_localhost + "/Odjeljenje/GetAll", MojConfig.http_opcije())
      .subscribe(x=> {
      this.odjeljenjaPodaci = x
    });
  }
  getRadnoMjesto(){
    return this.http.get(MojConfig.adresa_servera_localhost + "/Radnik/GetRadnoMjesto", MojConfig.http_opcije())
      .subscribe(x=>{
        this.radnoMjestoPodaci = x
      });
  }

  selectChangeOdjeljenje(event:any){
    this.OdjeljenjeSelected = event.target.value;
  }

  sacuvaj() {
    let uposlenik = {
      Ime: this.txtIme,
      Prezime: this.txtPrezime,
      Email: this.txtEmail,
      Adresa: this.txtAdresa,
      Grad: this.txtGrad,
      PostanskiBroj: this.txtPbroj,
      lozinka: this.txtLozinka,
      OdjeljenjeID: this.OdjeljenjeSelected,
      PozicijaID: this.PozicijaSelected
    };

    this.http.post(MojConfig.adresa_servera_localhost + "/Radnik/Add", uposlenik, MojConfig.http_opcije())
      .subscribe();
  }

  selectChangePozicija(event:any) {
    this.PozicijaSelected = event.target.value;
  }

  odaberiUposlenika(x: any) {
    this.odabraniRadnik = x;
    this.odabraniRadnik.prikazi = true;
  }

  izbrisi(x:any) {
    this.http.post(MojConfig.adresa_servera_localhost + "/Radnik/Delete/" + x.id, x, MojConfig.http_opcije()).subscribe();
  }
}

import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";
import {RouterModule, Routes, Router} from "@angular/router";

@Component({
  selector: 'app-dodaj-knjigu',
  templateUrl: './dodaj-knjigu.component.html',
  styleUrls: ['./dodaj-knjigu.component.css']
})
export class DodajKnjiguComponent implements OnInit {
  txtNaslov: any;
  txtImePisca: any;
  txtPrezimePisca: any;
  txtGodinaIzdanja: any;
  txtStampa: any;
  txtKolicina: any;
  txtOdjeljenje: any;
  txtIzdavac: any;
  OdjeljenjeAll:any;
  OdjeljenjeSelected: any;
  AddKnjiga:any;
  knjiga: any;

  constructor(private http:HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.getOdjeljenja();
  }

  getOdjeljenja(){
    this.http.get(MojConfig.adresa_servera_localhost + "/Odjeljenje/GetAll", MojConfig.http_opcije()).subscribe(x=>{
      this.OdjeljenjeAll=x;
    });
  }

  selectChangeOdjeljenje(event:any){
    this.OdjeljenjeSelected = event.target.value;
  }

  Potvrdi() {
    this.knjiga={
      Naslov: this.txtNaslov,
      ImePisca: this.txtImePisca,
      PrezimePisca: this.txtPrezimePisca,
      Izdavac: this.txtIzdavac,
      GodinaIzdavanja: this.txtGodinaIzdanja,
      Stampa: this.txtStampa,
      Kolicina:  this.txtKolicina,
      OdjeljenjeID: this.OdjeljenjeSelected
    };

    this.http.post(MojConfig.adresa_servera_localhost + "/Knjiga/" + this.AddKnjiga, this.knjiga, MojConfig.http_opcije())
    .subscribe((x:any) => {
    });

    window.location.reload();


  }

  selectChangeSekcija(event: any) {
    if(event.target.value == 1){
      this.AddKnjiga = "AddKnjigaTrgovina";
    } else {
      this.AddKnjiga = "AddKnjigaBiblioteka";
    }
  }
}

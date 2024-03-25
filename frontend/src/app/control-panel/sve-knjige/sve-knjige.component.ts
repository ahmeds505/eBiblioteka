import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";
import {NavigationEnd, Router} from "@angular/router";
import {BehaviorSubject, Observable, switchMap} from "rxjs";


@Component({
  selector: 'app-sve-knjige',
  templateUrl: './sve-knjige.component.html',
  styleUrls: ['./sve-knjige.component.css']
})

export class SveKnjigeComponent implements OnInit {
  KnjigePodaci:any;
  KnjigeDetalji: any;
  knjigeProvjera: any = false;
  search: string='';
  OdjeljenjeAll: any;
  odjeljenjeSelect: any;
  sekcijaSelect: string = "Sve";
  KnjigeFilterAll:any;
  txtNaslov: any;
  txtImePisca: any;
  txtPrezimePisca: any;
  txtIzdavac: any;
  txtGodinaIzdanja: any;
  txtStampa: any;
  txtOdjeljenje: any;
  txtKolicina: any;
  selectSekcija: any;

  constructor(private http: HttpClient, private router: Router) {


  }
  ngOnDestroy(){

  }

  ngOnInit(): void {
    this.getKnjigeAll();
    this.getOdjeljenjeAll();
  }

  getKnjigeAll(): void{
    this.http.get(MojConfig.adresa_servera_localhost + "/Knjiga/GetAll", MojConfig.http_opcije()).subscribe(x=>{
      this.KnjigePodaci=x;
    });

  }
  getOdjeljenjeAll(): void{
    this.http.get(MojConfig.adresa_servera_localhost + "/Odjeljenje/GetAll", MojConfig.http_opcije()).subscribe(x=> {
      this.OdjeljenjeAll = x;
    });
  }


  getKnjigeFilterSearch(){
    if(this.KnjigePodaci==null)
      return [];

    return this.KnjigePodaci.filter((x:any)=>
        x.naslov.length == 0 ||
        x.naslov.toLowerCase().startsWith(this.search.toLowerCase()) ||
        (x.imePisca + " " + x.prezimePisca).toLowerCase().startsWith(this.search.toLowerCase()) ||
        (x.prezimePisca + " " + x.imePisca).toLowerCase().startsWith(this.search.toLowerCase())
      );
  }


  odaberiKnjigu(knjiga:any) {
    this.KnjigeDetalji = knjiga;
    this.knjigeProvjera = true;
  }

  izbrisiKnjigu(x:any) {
    this.http.delete(MojConfig.adresa_servera_localhost +"/Knjiga/Delete/" + x.id, MojConfig.http_opcije()).subscribe();
    location.reload();
  }

  selectChangeSekcija($event: any) {
    if($event.target.value == 1)
      this.sekcijaSelect="Sve"
    else if ($event.target.value == 2)
      this.sekcijaSelect = "Trgovina";
    else if($event.target.value == 3)
      this.sekcijaSelect="Biblioteka";
      }



  selectChangeOdjeljenjeUpdate($event: any) {
    this.KnjigeDetalji.odjeljenje.id = $event.target.value;
  }

  Potvrdi() {
    this.http.post(MojConfig.adresa_servera_localhost + "/Knjiga/Update/" + this.KnjigeDetalji.id, this.KnjigeDetalji, MojConfig.http_opcije()).subscribe();
    this.knjigeProvjera = false;
  }

  selectChangeOdjeljenje($event: Event) {

  }



}

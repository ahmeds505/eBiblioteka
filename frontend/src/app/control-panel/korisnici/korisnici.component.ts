import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";

@Component({
  selector: 'app-korisnici',
  templateUrl: './korisnici.component.html',
  styleUrls: ['./korisnici.component.css']
})
export class KorisniciComponent implements OnInit {
  korisniciPodaci: any;
  odabraniKorisnik = {
    noviKorisnik:false,
    prikazi: false,
    ime:'',
    prezime:'',
    postanskiBroj:'',
    grad:'',
    adresa:''
  }
  search: any;


  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getUclanjeniKorisnici();
    this.pretragaKorisnika();
  }

  getUclanjeniKorisnici(){
   this.http.get(MojConfig.adresa_servera_localhost + "/Radnik/GetAllUclanjeniKorisnici", MojConfig.http_opcije())
      .subscribe( x => {
        this.korisniciPodaci = x;
      });
  }

  izbrisi(x: any) {

  }

  pretragaKorisnika(){
    if(this.korisniciPodaci==null)
      return [];
    if(this.search == null)
      return this.korisniciPodaci;

    return this.korisniciPodaci.filter((x:any)=>
      (x.ime + " " + x.prezime).toLowerCase().startsWith(this.search.toLowerCase()) ||
      (x.prezime + " " + x.ime).toLowerCase().startsWith(this.search.toLowerCase())
    );
  }

  odaberiKorisnika(x: any) {
    this.odabraniKorisnik = x;
    this.odabraniKorisnik.prikazi = true;

  }

  dodajNovog() {
    this.odabraniKorisnik = {
      noviKorisnik: true,
      prikazi: true,
      ime:'',
      prezime:'',
      postanskiBroj:'',
      grad:'',
      adresa:''
    }
  }
}

import {Component, Input, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../../moj-config";

@Component({
  selector: 'app-korisnici-edit',
  templateUrl: './korisnici-edit.component.html',
  styleUrls: ['./korisnici-edit.component.css']
})
export class KorisniciEditComponent implements OnInit {
    @Input()
    urediKorisnik: any;
    funkcija: string;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  sacuvaj() {
    this.urediKorisnik = {
      Id: this.urediKorisnik.id,
      Ime: this.urediKorisnik.ime,
      Prezime: this.urediKorisnik.prezime,
      Email: this.urediKorisnik.email,
      Adresa: this.urediKorisnik.adresa,
      Grad: this.urediKorisnik.grad,
      PostanskiBroj: this.urediKorisnik.postanskiBroj
    }
    this.funkcija = "/Radnik/AddKorisnikUclanjen";

    if(!this.urediKorisnik.noviKorisnik)
      this.funkcija = "/Radnik/UpdateUclanjenKorisnik/" + this.urediKorisnik.Id;

    this.http.post(MojConfig.adresa_servera_localhost + this.funkcija, this.urediKorisnik, MojConfig.http_opcije())
      .subscribe(x => {
        this.urediKorisnik.noviKorisnik = false;
      });
  }

  close() {
    this.urediKorisnik.prikazi = false;
  }
}

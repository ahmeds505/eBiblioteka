import {Component, Input, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../../moj-config";

@Component({
  selector: 'app-radnici-edit',
  templateUrl: './radnici-edit.component.html',
  styleUrls: ['./radnici-edit.component.css']
})
export class RadniciEditComponent implements OnInit {

  @Input()
  urediUposlenik: any;

  odjeljenjaPodaci: any;
  radnoMjestoPodaci: any;
  odjeljenjeSelected: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getOdjeljenja();
    this.getRadnoMjesto();
  }

  sacuvaj() {
    this.http.post(MojConfig.adresa_servera_localhost + "/Radnik/Update/" + this.urediUposlenik.id, this.urediUposlenik, MojConfig.http_opcije()).subscribe();
  }

  getOdjeljenja() {
    return this.http.get(MojConfig.adresa_servera_localhost + "/Odjeljenje/GetAll", MojConfig.http_opcije())
      .subscribe(x => {
        this.odjeljenjaPodaci = x
      });
  }

  getRadnoMjesto(){
    return this.http.get(MojConfig.adresa_servera_localhost + "/Radnik/GetRadnoMjesto", MojConfig.http_opcije())
      .subscribe(x=>{
        this.radnoMjestoPodaci = x
      });
  }

  selectChangeOdjeljenje(event:any) {
    this.urediUposlenik.odjeljenjeID = event.target.value;
  }

  selectChangePozicija(event: any) {
    this.urediUposlenik.pozicijaID = event.target.value;
  }
}

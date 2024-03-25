import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-trgovina',
  templateUrl: './trgovina.component.html',
  styleUrls: ['./trgovina.component.css']
})
export class TrgovinaComponent implements OnInit {
  bibliotekaPodaci:any;

  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.preuzmiPodatke();
  }
  preuzmiPodatke(){
    this.httpKlijent.get(MojConfig.adresa_servera_localhost + "/Knjiga/GetAllBySekcija/" + "Trgovina", MojConfig.http_opcije())
      .subscribe((x:any) => {
        this.bibliotekaPodaci = x;
      });
  }

  dodajUKorpu(x:any) {
    this.httpKlijent.post(MojConfig.adresa_servera_localhost + "/ShoppingCart/New/" + x.id, x, MojConfig.http_opcije())
      .subscribe();
  }
}

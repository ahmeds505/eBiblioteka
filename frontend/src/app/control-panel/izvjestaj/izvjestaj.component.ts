import { Component, OnInit } from '@angular/core';
import {formatDate} from "@angular/common";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";

@Component({
  selector: 'app-izvjestaj',
  templateUrl: './izvjestaj.component.html',
  styleUrls: ['./izvjestaj.component.css']
})
export class IzvjestajComponent implements OnInit {
  DatumOD: string;
  DatumDO: string;
  datumOD: string;
  datumDO: string;
  link: string = MojConfig.adresa_servera_localhost;
  txtOdjeljenje: any;
  OdjeljenjeAll: any;

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    this.getOdjeljenje();
  }

  formatiraj(): void {
      this.datumOD = formatDate(this.DatumOD, 'YYYY-MM-dd', 'en-US'),
      this.datumDO = formatDate(this.DatumDO, 'YYYY-MM-dd', 'en-US')
    //this.http.get(MojConfig.adresa_servera_localhost + "/Report/Report/"+ this.datumOD +", "+ this.datumDO).subscribe();
      window.open(MojConfig.adresa_servera_localhost+ "/ReportTrgovina/TrgovinaReport/"+ this.datumOD +", "+ this.datumDO + ", " + this.txtOdjeljenje, "_blank");
  }

  getOdjeljenje() {
    this.http.get(MojConfig.adresa_servera_localhost + "/Odjeljenje/GetAll", MojConfig.http_opcije()).subscribe((x: any) => {
      this.OdjeljenjeAll = x;
    });
  }
}

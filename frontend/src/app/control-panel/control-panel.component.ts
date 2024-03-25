import {Component, NgModule, OnInit} from '@angular/core';
import {MatTreeModule} from '@angular/material/tree';
import {Routes, RouterModule } from '@angular/router';
import {DodajKnjiguComponent} from "./dodaj-knjigu/dodaj-knjigu.component";
import {BrowserModule} from "@angular/platform-browser";
import {AppComponent} from "../app.component";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {AutentifikacijaHelper} from "../_login-help/autentifikacija-helper";


@Component({
  selector: 'app-control-panel',
  templateUrl: './control-panel.component.html',
  styleUrls: ['./control-panel.component.css']
})


export class ControlPanelComponent implements OnInit {
  showFiller: boolean = false;
  ime: string;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getKorisnik();
  }

  getKorisnik() {
    this.ime = AutentifikacijaHelper.getLoginInfo().korisnickoIme;
    console.log(this.ime);
    return this.ime;
  }

}

import { Component, OnInit } from '@angular/core';
import {AutentifikacijaHelper} from "../_login-help/autentifikacija-helper";

@Component({
  selector: 'app-korisnicki-profil',
  templateUrl: './korisnicki-profil.component.html',
  styleUrls: ['./korisnicki-profil.component.css']
})
export class KorisnickiProfilComponent implements OnInit {
loginInfo = AutentifikacijaHelper.getLoginInfo();


  constructor() { }

  ngOnInit(): void {

  };

}

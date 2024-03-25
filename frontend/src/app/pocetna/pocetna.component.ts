import { Component, OnInit } from '@angular/core';
import {LoginInformacije} from "../_login-help/login-informacije";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";


@Component({
  selector: 'app-pocetna',
  templateUrl: './pocetna.component.html',
  styleUrls: ['./pocetna.component.css']
})
export class PocetnaComponent implements OnInit {
  jeLogiran:boolean = false;


  constructor() { }

  ngOnInit(): void {

  }



}

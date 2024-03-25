import { Component, Input, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {LoginComponent} from "../login/login.component";
import {RouterModule, Routes, Router} from "@angular/router";


@Component({
  selector: 'app-registracija',
  templateUrl: './registracija.component.html',
  styleUrls: ['./registracija.component.css']
})



export class RegistracijaComponent implements OnInit {
  txtime: any;
  txtprezime: any;
  txtemail: any;
  txtadresa: any;
  txtgrad: any;
  txtpostanskiBroj: any;
  txtpassword1: any;
  txtpassword2: any;
  isDisabled = 1;



  constructor(private HttpKlijent: HttpClient, private router: Router) {
  }

  ngOnInit(): void {
  }

  onSubmit() {
  }

  Potvrdi() {
      let endUser = {
      ime:this.txtime,
      prezime:this.txtprezime,
      email:this.txtemail,
      adresa:this.txtadresa,
      grad:this.txtgrad,
      postanskiBroj:this.txtpostanskiBroj,
      lozinka: this.txtpassword2
    };

     this.HttpKlijent.post(MojConfig.adresa_servera_localhost + "/EndUser/Add", endUser)
      .subscribe((x:any) => {
        if(x.isRegistrovan) {
          this.router.navigate(['/zavrsena-registracija']);
        }
      });
  }

  pwProvjera():boolean
  {

    if(this.txtpassword1!=this.txtpassword2) {
      this.isDisabled=1;
      return false;
    }
    else{
      this.isDisabled=0;
      return true;
    }
  }
}



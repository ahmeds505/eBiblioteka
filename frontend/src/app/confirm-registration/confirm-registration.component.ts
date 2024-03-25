import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MojConfig } from '../moj-config';

@Component({
  selector: 'app-confirm-registration',
  templateUrl: './confirm-registration.component.html',
  styleUrls: ['./confirm-registration.component.css']
})
export class ConfirmRegistrationComponent implements OnInit {

  private email: any;
  private sub: any;

  constructor(private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe((x:any) => {
      this.email = x.email;

      this.PotvrdiRegistraciju();
    });
  }

PotvrdiRegistraciju(){
  this.http.post(MojConfig.adresa_servera_localhost + "/AutentifikacijaTokens/AktivirajRacun?email=" + this.email, null)
  .subscribe();
}

ngOnDestroy(){
  this.sub.unsubscribe();
}

}

import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";

@Component({
  selector: 'app-sve-iznajmljene-knjige',
  templateUrl: './sve-iznajmljene-knjige.component.html',
  styleUrls: ['./sve-iznajmljene-knjige.component.css']
})
export class SveIznajmljeneKnjigeComponent implements OnInit {

  iznajmljene:any;
  response:any;
  info = false;
  date:Date;
  obavijest = false;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getPodaci();
  }

  getPodaci(){
    this.http.get(MojConfig.adresa_servera_localhost + "/Knjiga/GetIznajmljene", MojConfig.http_opcije())
      .subscribe((response:any) => {
        this.iznajmljene = response;
      });
  }

  getDatum(x:any)
  {
    this.date = new Date(x);

    return this.date.toLocaleDateString();
  }
  vratiKnjigu(x:any)
  {
   this.http.post(MojConfig.adresa_servera_localhost + "/Knjiga/VratiKnjigu/" + x.knjiga.id + "," + x.clan.id, MojConfig.http_opcije())
     .subscribe(()=>
       {

         },
       (error) =>
       {
         // console.log(error);
         if(error.status == 200)
         {
          //  this.response = "Knjiga je uspješno vraćena.";
           this.obavijest = true;
         }
       });
  }

  zatvoriModal()
  {
    this.obavijest = false;
    location.reload();
  }

}

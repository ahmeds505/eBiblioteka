import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {HttpClient, HttpEventType} from "@angular/common/http";
import {MojConfig} from "../../moj-config";
import {Router} from "@angular/router";
import {AutentifikacijaHelper} from "../../_login-help/autentifikacija-helper";
import {AngularFireStorage} from "@angular/fire/compat/storage";

@Component({
  selector: 'app-osnovne-informacije',
  templateUrl: './osnovne-informacije.component.html',
  styleUrls: ['./osnovne-informacije.component.css']
})
export class OsnovneInformacijeComponent implements OnInit {

  korisnikPodaci: any;
  korisnikPodaciProvjera: any;
  slikaIzvor: string;
  loginInfo = AutentifikacijaHelper.getLoginInfo();


  public file: File;

  constructor(private http:HttpClient, private router: Router, private fireStorage: AngularFireStorage) { }

  ngOnInit(): void {
    this.getPodaci();
  }

  getPodaci(){
    this.http.get(MojConfig.adresa_servera_localhost + "/EndUser/GetById/" + this.loginInfo.korisnikId, MojConfig.http_opcije()).subscribe((vrijednost:any)=>
      {
        this.korisnikPodaci = vrijednost;
        this.korisnikPodaciProvjera = vrijednost;
        // this.getSlikaKorisnika();
      }
    );
  }

  spremiPodatke() {

    this.http.post(MojConfig.adresa_servera_localhost + "/EndUser/UpdatePodaci/" + this.loginInfo.korisnikId, this.korisnikPodaci, MojConfig.http_opcije()).subscribe();

    if(this.file != null){
      this.spremiSliku();
    }

    this.router.navigateByUrl('/korisnicki-profil');

  }

  onChange(event) {
        this.file = event.target.files[0];
  }

  // getSlikaKorisnika(){
  //   this.slikaIzvor= MojConfig.adresa_servera_localhost + "/uploads/" + this.korisnikPodaci.slika_korisnika;
  // }

  async spremiSliku(){
    // const formData = new FormData();
    // formData.append("file", this.file, this.file.name);
    //
    // this.http.post(MojConfig.adresa_servera_localhost + '/EndUser/UpdateSlika/' + this.loginInfo.korisnikId, formData, MojConfig.http_opcije()).subscribe();
    //
    // this.getSlikaKorisnika();

    if(this.file)
    {
      const path = `${this.korisnikPodaci.id}/${this.file.name}`
      const uploadTask = await this.fireStorage.upload(path, this.file)
      const url = await uploadTask.ref.getDownloadURL()
      this.korisnikPodaci.slika_korisnika = url
      console.log(url)
    }

    await this.http.post(MojConfig.adresa_servera_localhost + '/EndUser/UpdateSlika/' + this.loginInfo.korisnikId, this.korisnikPodaci, MojConfig.http_opcije()).subscribe();

  }
}

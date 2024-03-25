import {Component, OnInit, EventEmitter, Output} from '@angular/core';
import {HttpClient, HttpEventType} from "@angular/common/http";
import {MojConfig} from "../../moj-config";
import {Router} from "@angular/router";
import {AutentifikacijaHelper} from "../../_login-help/autentifikacija-helper";



@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  public message: string;
  public progress: number;
  @Output() public onUploadFinished = new EventEmitter();


  slika:any;
  file:any;
  slikaIzvor:any;
  loginInfo = AutentifikacijaHelper.getLoginInfo();

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.http.get(MojConfig.adresa_servera_localhost + '/EndUser/GetSlika/' + this.loginInfo.korisnikId, {responseType: "blob"})
      .subscribe((response) =>{
      this.slika = response;
    });
    this.file = new File(this.slika, this.slika.name);
    this.slikaIzvor = URL.createObjectURL(this.file);
  }

  public uploadFile = (files) => {
    if(files.length === 0)
      return;

    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.http.post(MojConfig.adresa_servera_localhost + '/EndUser/UpdateSlika/' + this.loginInfo.korisnikId, formData, {reportProgress:true, observe:"events"}).subscribe(
      event=>{
        if(event.type === HttpEventType.UploadProgress){
          this.progress = Math.round(100*event.loaded / event.total);
        }
        else if(event.type === HttpEventType.Response){
          this.message = "Upload success."
          this.onUploadFinished.emit(event.body);
        }
      });

    this.router.navigateByUrl('/korisnicki-profil');


  }

}

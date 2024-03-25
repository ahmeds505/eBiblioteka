import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClient, HttpClientModule} from "@angular/common/http";
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegistracijaComponent } from './registracija/registracija.component';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import {ControlContainer, FormsModule} from "@angular/forms";
import { BibliotekaComponent } from './biblioteka/biblioteka.component';
import { TrgovinaComponent } from './trgovina/trgovina.component';
import { RegistracijaEmailPWComponent } from './registracija/registracija-email-pw/registracija-email-pw.component';
import { PocetnaComponent } from './pocetna/pocetna.component';
import { ControlPanelComponent } from './control-panel/control-panel.component';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {MaterialModule} from "./material/material.module";
import { DodajKnjiguComponent } from './control-panel/dodaj-knjigu/dodaj-knjigu.component';
import {SveKnjigeComponent} from "./control-panel/sve-knjige/sve-knjige.component";
import {RadniciComponent} from "./control-panel/radnici/radnici.component";
import {RadniciEditComponent} from "./control-panel/radnici/radnici-edit/radnici-edit.component";
import { KorisnickiProfilComponent } from './korisnicki-profil/korisnicki-profil.component';
import { OsnovneInformacijeComponent } from './korisnicki-profil/osnovne-informacije/osnovne-informacije.component';
import { ListaProcitanihKnjigaComponent } from './korisnicki-profil/lista-procitanih-knjiga/lista-procitanih-knjiga.component';
import { PrikaziListuZeljenihKnjigaComponent } from './korisnicki-profil/prikazi-listu-zeljenih-knjiga/prikazi-listu-zeljenih-knjiga.component';
import { DodajZeljenuKnjiguComponent } from './korisnicki-profil/dodaj-zeljenu-knjigu/dodaj-zeljenu-knjigu.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { IzvjestajComponent } from './control-panel/izvjestaj/izvjestaj.component';
import { DocumentComponent } from './document/document.component';
import { UploadComponent } from './korisnicki-profil/upload/upload.component';
import {MatInputModule} from "@angular/material/input";
// import { initializeApp,provideFirebaseApp } from '@angular/fire/app';
 //import { environment } from '../environments/environment';
// import { provideDatabase,getDatabase } from '@angular/fire/database';
// import { provideFirestore,getFirestore } from '@angular/fire/firestore';
import {AngularFireMessagingModule} from "@angular/fire/compat/messaging";
//import { AngularFireModule } from '@angular/fire';
import {AngularFireStorageModule} from "@angular/fire/compat/storage";
import {AngularFirestore} from "@angular/fire/compat/firestore";
import {AngularFireModule} from "@angular/fire/compat";
import {AngularFireDatabaseModule} from "@angular/fire/compat/database";
import { NotificationModelComponent } from './notification-model/notification-model.component';
import { UploadFormComponent } from './upload-form/upload-form.component';
import { UploadListComponent } from './upload-list/upload-list.component';
import { UploadDetailsComponent } from './upload-details/upload-details.component';
import {KorisniciComponent} from "./control-panel/korisnici/korisnici.component";
import {KorisniciEditComponent} from "./control-panel/korisnici/korisnici-edit/korisnici-edit.component";
import {AutorizacijaAdminService} from "./_guards/autorizacija-admin.service";
import {AutorizacijaUposlenikService} from "./_guards/autorizacija-uposlenik.service";
import { ForbiddenComponent } from './forbidden/forbidden.component';
import {AutorizacijaKorisnikService} from "./_guards/autorizacija-korisnik.service";
import {canActivate} from "@angular/fire/auth-guard";
import {AutorizacijaAdminUposlenikService} from "./_guards/autorizacija-admin-uposlenik.service";
import {AutorizacijaLogiranService} from "./_guards/autorizacija-logiran.service";
import { ConfirmRegistrationComponent } from './confirm-registration/confirm-registration.component';
//import {environment} from "../environments/environment";
import {Environment} from "@angular/cli/lib/config/workspace-schema";
import {
  UpravljanjeClanarinomComponent
} from "./korisnicki-profil/upravljanje-clanarinom/upravljanje-clanarinom.component";
import { IznajmljeneKnjigeComponent } from './korisnicki-profil/iznajmljene-knjige/iznajmljene-knjige.component';
import {SveIznajmljeneKnjigeComponent} from "./control-panel/sve-iznajmljene-knjige/sve-iznajmljene-knjige.component";
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

//import { MessagingServiceComponent } from './messaging-service/messaging-service.component';



export const environment = {
  firebase: {
    apiKey: "AIzaSyAYMQHfx9NOOnjTyEiFmbfEzAk3DOmiXlw",
    authDomain: "images-ebiblioteka.firebaseapp.com",
    databaseURL: "https://images-ebiblioteka-default-rtdb.europe-west1.firebasedatabase.app",
    projectId: "images-ebiblioteka",
    storageBucket: "images-ebiblioteka.appspot.com",
    messagingSenderId: "74850336358",
    appId: "1:74850336358:web:20c72855019470c04c37a7"
  },
  production: false
};

export function HttpLoaderFactory(http:HttpClient){
  return new TranslateHttpLoader(http);
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistracijaComponent,
    BibliotekaComponent,
    TrgovinaComponent,
    RegistracijaEmailPWComponent,
    PocetnaComponent,
    DodajKnjiguComponent,
    ControlPanelComponent,
    SveKnjigeComponent,
    RadniciComponent,
    RadniciEditComponent,
    KorisnickiProfilComponent,
    OsnovneInformacijeComponent,
    ListaProcitanihKnjigaComponent,
    PrikaziListuZeljenihKnjigaComponent,
    DodajZeljenuKnjiguComponent,
    ShoppingCartComponent,
    IzvjestajComponent,
    DocumentComponent,
    UploadComponent,
    NotificationModelComponent,
    UploadFormComponent,
    UploadListComponent,
    UploadDetailsComponent,
    KorisniciComponent,
    KorisniciEditComponent,
    ForbiddenComponent,
    ConfirmRegistrationComponent,
    UpravljanjeClanarinomComponent,
    IznajmljeneKnjigeComponent,
    SveIznajmljeneKnjigeComponent
  ],
  imports: [
    AngularFireModule.initializeApp(environment.firebase),
    BrowserModule,
    RouterModule.forRoot([
      {path: 'registracija', component: RegistracijaComponent},
      {path: 'shopping-cart', component: ShoppingCartComponent, canActivate: [AutorizacijaUposlenikService || AutorizacijaAdminService || AutorizacijaKorisnikService]},
      {path: 'zavrsena-registracija', component: RegistracijaEmailPWComponent},
      {path: 'trgovina', component: TrgovinaComponent},
      {path: 'biblioteka', component: BibliotekaComponent},
      {path: 'pocetna', component: PocetnaComponent},
      {path: 'login', component: LoginComponent},
      {path: 'confirm-registration/:email', component: ConfirmRegistrationComponent},
      //{path: 'forbidden', component: ForbiddenComponent},
      {
        path: 'control-panel', component: ControlPanelComponent,
        children: [
          {path: 'dodaj-knjigu', component: DodajKnjiguComponent, canActivate: [AutorizacijaAdminUposlenikService]},
          {path: 'sve-knjige', component: SveKnjigeComponent, canActivate: [AutorizacijaAdminUposlenikService]},
          {path: 'radnici', component: RadniciComponent, canActivate: [AutorizacijaAdminService]},
          {path: 'radnici-edit', component: RadniciEditComponent, canActivate: [AutorizacijaAdminService]},
          {path: 'izvjestaj', component: IzvjestajComponent, canActivate: [AutorizacijaAdminUposlenikService]},
          {path: 'korisnici', component: KorisniciComponent, canActivate: [AutorizacijaAdminUposlenikService]},
          {path: 'sve-iznajmljene-knjige', component: SveIznajmljeneKnjigeComponent, canActivate: [AutorizacijaAdminUposlenikService]}

        ]
      },
      {
        path: 'korisnicki-profil', component: KorisnickiProfilComponent, canActivate: [AutorizacijaLogiranService],
        children: [
          {path: 'osnovne-informacije', component: OsnovneInformacijeComponent, canActivate: [AutorizacijaLogiranService]},
          {path: 'procitane-knjige', component: ListaProcitanihKnjigaComponent, canActivate: [AutorizacijaLogiranService]},
          {path: 'prikazi-listu-zeljenih-knjiga', component: PrikaziListuZeljenihKnjigaComponent, canActivate: [AutorizacijaLogiranService]},
          {path: 'prikazi-listu-zeljenih-knjiga/dodaj-zeljenu-knjigu', component: DodajZeljenuKnjiguComponent, canActivate: [AutorizacijaLogiranService]},
          {path: 'upravljanje-clanarinom', component: UpravljanjeClanarinomComponent, canActivate: [AutorizacijaLogiranService]},
          {path: 'iznajmljene-knjige', component: IznajmljeneKnjigeComponent, canActivate: [AutorizacijaLogiranService]}


        ]
      }
    ]),

    AppRoutingModule,
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    MatInputModule,
    AngularFireMessagingModule,
    AngularFireStorageModule,
    AngularFireDatabaseModule,
    HttpClientModule,
    TranslateModule.forRoot(
      {
      loader: {
        provide: TranslateLoader,
        useFactory:HttpLoaderFactory,
        deps:[HttpClient]
      }
    }
    )
  ],
  providers:
    [
      HttpClient,
      AngularFirestore,
      AutorizacijaAdminService,
      AutorizacijaKorisnikService,
      AutorizacijaUposlenikService,
      {
        provide: 'APP_CONFIG',
        useValue: environment
      },
    ],
  bootstrap: [AppComponent],
  exports: [RouterModule]
})
export class AppModule {
}


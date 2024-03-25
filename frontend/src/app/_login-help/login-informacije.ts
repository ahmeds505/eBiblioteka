export class LoginInformacije {
  vrijednost: string=null;
  isAdministrator: boolean = false;
  isKorisnik: boolean = false;
  isRadnik: boolean = false;
  isLogiran: boolean = false;
  korisnickoIme: string = null;
  korisnikId: number;
}

export interface AutentifikacijaToken{
  id:number;
  vrijednost:string;
  korisnickiNalogId:number;
  korisnickiNalog: KorisnickiNalog;
}

export interface KorisnickiNalog {
  id: number;
  korisnickoIme: string;
  isAdministrator: boolean;
  isKorisnik: boolean;
  isRadnik: boolean;
}

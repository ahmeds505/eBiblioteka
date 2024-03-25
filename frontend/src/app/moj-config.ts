import {HttpHeaders} from "@angular/common/http";
import {AutentifikacijaHelper} from "./_login-help/autentifikacija-helper";

export class MojConfig {
  static adresa_servera = "https://e-biblioteka.p2118.app.fit.ba";
  static adresa_servera_localhost = "https://localhost:44304";

  static http_opcije = function() {
    let mojToken = '';
    let token = AutentifikacijaHelper.getLoginInfo().vrijednost;

    if(token != null)
      mojToken = token;

    return {
      headers:{
        'autentifikacija-token': mojToken,
      }
    };
  }
}



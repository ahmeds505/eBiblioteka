import {LoginInformacije} from "./login-informacije";

export class AutentifikacijaHelper {
  static setLoginInfo(x: LoginInformacije): void{
    if(x == null)
      x = new LoginInformacije();
    localStorage.setItem("autentifikacija-token", JSON.stringify(x));
  }

  static getLoginInfo(): LoginInformacije {
    let x = localStorage.getItem("autentifikacija-token");
    if(x == null)
      return new LoginInformacije();

    try {
      let loginInformacije: LoginInformacije = JSON.parse(x);
      return loginInformacije;
    }
    catch(e){
      return new LoginInformacije();
    }
  }
}

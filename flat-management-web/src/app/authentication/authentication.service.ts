import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { IFlat } from "../shared/entities/flat";
import { IFlatmate } from "../shared/entities/flatmate";
import { CorsHttpClient } from "../shared/services/cors-http-client.service";
import { CryptoService } from "../shared/services/crypto.service";
import { IAuthenticationResult } from "./authentication-result";

@Injectable()
export class AuthenticationService {
  constructor(private cryptoService: CryptoService,
    private http: CorsHttpClient) { }

  authenticate(login: string, password: string): Observable<IAuthenticationResult> {
    let cypheredPassword = this.cryptoService.preparePassword(password);

    return this.http.post<IAuthenticationResult>('Auth', { "login": login, "passwordHash": cypheredPassword });
  }

  createNewUserAndFlat(flat: IFlat, flatmate: IFlatmate): Observable<Object> {
    let cypheredPassword = this.cryptoService.preparePassword(flatmate.password);

    let flatmateCloned: IFlatmate = {
      birthDate: flatmate.birthDate,
      flatId: flatmate.flatId,
      flatmateId: flatmate.flatmateId,
      flatTenant: flatmate.flatTenant,
      fullName: flatmate.fullName,
      login: flatmate.login,
      nickName: flatmate.nickName,
      password: undefined
    };

    return this.http.put('Auth', {
      flat: flat,
      flatmate: flatmateCloned,
      password: cypheredPassword
    });
  }
}

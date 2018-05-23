import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { CorsHttpClient } from "../shared/services/cors-http-client.service";
import { CryptoService } from "../shared/services/crypto.service";
import { IAuthenticationResult } from "./authentication-result";
import { IFlat } from "../shared/entities/flat";
import { IFlatmate } from "../shared/entities/flatmate";
import { IPassword } from "../shared/entities/password";


@Injectable()
export class AuthenticationService {
    constructor(private cryptoService: CryptoService,
        private http: CorsHttpClient) { }

    authenticate(login: string, password: string): Observable<IAuthenticationResult> {
        let cypheredPassword: IPassword = this.cryptoService.preparePassword(password);

        return this.http.post<IAuthenticationResult>('Auth', { "login": login, "passwordHash": cypheredPassword.hash, "salt": cypheredPassword.salt });
    }
    
    createNewUserAndFlat(flat: IFlat, flatmate: IFlatmate): Observable<Object> {
        let cypheredPassword: IPassword = this.cryptoService.preparePassword(flatmate.password);

        return this.http.put('Auth', { flat, flatmate });
    }
}

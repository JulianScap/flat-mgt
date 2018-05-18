import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { CorsHttpClient } from "../shared/services/cors-http-client.service";
import { CryptoService } from "../shared/services/crypto.service";
import { IAuthenticationResult } from "./authentication-result";


@Injectable()
export class AuthenticationService {
    constructor(private cryptoService: CryptoService,
        private http: CorsHttpClient) { }

    authenticate(login: string, password: string): Observable<IAuthenticationResult> {
        let cypheredPassword: string = this.cryptoService.preparePassword(password);

        return this.http.post<IAuthenticationResult>('Auth', { "login": login, "passwordHash": cypheredPassword });
    }
}

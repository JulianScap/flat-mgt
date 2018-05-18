import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";

import { CryptoService } from "../shared/services/crypto.service";
import { IValidationResult } from "../shared/entities/validation-result";
import { CorsHttpClient } from "../shared/services/corshttpclient.service";

@Injectable()
export class AuthenticationService {
    constructor(private cryptoService: CryptoService,
        private http: CorsHttpClient) { }

    authenticate(login: string, password: string): Observable<IValidationResult> {
        let cypheredPassword: string = this.cryptoService.preparePassword(password);

        return this.http.post<IValidationResult>('Auth', { "login": login, "passwordHash": cypheredPassword });
    }
}

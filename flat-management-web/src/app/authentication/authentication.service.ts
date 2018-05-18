import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";

import { CryptoService } from "../shared/services/crypto.service";
import { IResult } from "../shared/entities/result";
import { CorsHttpClient } from "../shared/services/corshttpclient.service";

@Injectable()
export class AuthenticationService {
    constructor(private cryptoService: CryptoService,
        private http: CorsHttpClient) { }

    authenticate(login: string, password: string): Observable<IResult> {
        let cypheredPassword: string = this.cryptoService.preparePassword(password);

        return this.http.post<IResult>('Auth', { "login": login, "passwordHash": cypheredPassword });
    }
}

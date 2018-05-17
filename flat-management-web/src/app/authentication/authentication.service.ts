import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/catch";
import "rxjs/add/operator/do";
import "rxjs/add/observable/throw";

import { CryptoService } from "../shared/crypto.service";
import { IResult } from "../shared/result";
import { CorsHttpClient } from "../shared/corshttpclient.service";

@Injectable()
export class AuthenticationService {
    constructor(private cryptoService: CryptoService,
        private http: CorsHttpClient) { }

    Authenticate(login: string, password: string): Observable<IResult> {
        let now: Date = new Date();
        let cypheredPassword: string = this.cryptoService.preparePassword(password, now);

        return this.http.post<IResult>('Auth', { "login": login, "passwordHash": cypheredPassword })
            .do(data => console.log(data))
            .catch(this.handleError);
    }

    private handleError(err: HttpErrorResponse) {
        console.log(err.message);
        return Observable.throw(err.message);
    }
}

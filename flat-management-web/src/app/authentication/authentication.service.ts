import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/catch";
import "rxjs/add/operator/do";
import "rxjs/add/observable/throw";

import { CryptoService } from "../shared/crypto.service";

@Injectable()
export class AuthenticationService {
    constructor(private cryptoService: CryptoService,
        private http: HttpClient) { }

    Authenticate(login: string, password: string): string {
        let now: Date = new Date();
        let cypheredPassword: string = this.cryptoService.preparePassword(password, now);
        this.http.post('http://fm.api.local/api/Auth', { "login": login, "password": cypheredPassword })
        .do(data => console.log(data))
        .catch(this.handleError);
        return null;
    }

    private handleError(err: HttpErrorResponse){
        console.log(err.message);
        return Observable.throw(err.message);
    }
}

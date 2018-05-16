import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";

import { CryptoService } from "../shared/crypto.service";

@Injectable()
export class AuthenticationService {
    constructor(private cryptoService: CryptoService,
        private _http: HttpClient) { }

    Authenticate(login: string, password: string): string {
        let now: Date = new Date();
        let cypheredPassword: string = this.cryptoService.preparePassword(password, now);
        console.log(cypheredPassword);
        
        return null;
    }
}

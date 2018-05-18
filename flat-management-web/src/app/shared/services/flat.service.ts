import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";

import { AuthenticatedCorsHttpClient } from "./authenticated-cors-http-client.service";
import { SessionManager } from "./session-manager.service";
import { IFlat } from "../entities/flat";

@Injectable()
export class FlatService {
    constructor(private http: AuthenticatedCorsHttpClient,
        private sessionManager: SessionManager) { }

    getFlatsForAccount(): Observable<IFlat[]> {
        return null;
    }
}

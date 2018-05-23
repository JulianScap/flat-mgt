import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { IFlatmate } from "../entities/flatmate";
import { AuthenticatedCorsHttpClient } from "./authenticated-cors-http-client.service";
import { SessionManager } from "./session-manager.service";

@Injectable()
export class FlatmateService {
    constructor(private http: AuthenticatedCorsHttpClient,
        private sessionManager: SessionManager) { }

    get(flatmateId?: number): Observable<IFlatmate[]> {
        if (flatmateId) {
            return this.http.get(`Flatmate/${flatmateId}`);
        } else {
            return this.http.get('Flatmate');
        }
    }

    getByFlatId(flatId?: number): Observable<IFlatmate[]> {
        if (flatId) {
            return this.http.get(`Flatmate/byFlat/${flatId}`);
        } else {
            return this.http.get('Flatmate');
        }
    }

    delete(flatmates: IFlatmate[]): Observable<Object> {
        return this.http.delete('Flatmate', JSON.stringify(flatmates));
    }

    save(flatmates: IFlatmate[]): Observable<Object> {
        return this.http.post('Flatmate', JSON.stringify(flatmates));
    }
}

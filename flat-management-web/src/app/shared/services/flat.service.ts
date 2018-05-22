import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { IFlat } from "../entities/flat";
import { AuthenticatedCorsHttpClient } from "./authenticated-cors-http-client.service";
import { SessionManager } from "./session-manager.service";

@Injectable()
export class FlatService {
    constructor(private http: AuthenticatedCorsHttpClient,
        private sessionManager: SessionManager) { }

    get(flatId?: number): Observable<IFlat[]> {
        if (flatId) {
            return this.http.get(`Flat/${flatId}`);
        } else {
            return this.http.get('Flat');
        }
    }

    delete(flats: IFlat[]): Observable<Object> {
        return this.http.delete('Flat', JSON.stringify(flats));
    }

    save(flats: IFlat[]): Observable<Object> {
        return this.http.post('Flat', JSON.stringify(flats));
    }
}

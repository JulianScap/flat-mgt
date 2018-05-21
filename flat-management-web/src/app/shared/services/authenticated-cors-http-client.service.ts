import { Injectable } from "@angular/core";
import { CorsHttpClient } from "./cors-http-client.service";
import { HttpHeaders, HttpClient } from "@angular/common/http";
import { SessionManager } from "./session-manager.service";

@Injectable()
export class AuthenticatedCorsHttpClient extends CorsHttpClient {
    constructor(private sessionManager: SessionManager,
        http: HttpClient) {
        super(http);
    }

    getOptions(): { headers?: HttpHeaders; withCredentials?: boolean; } {
        let result = super.getOptions();

        let token: string = this.sessionManager.getToken();
        result.headers = new HttpHeaders({ 'token': token });

        return result;
    }
}
import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs/Observable";

@Injectable()
export class CorsHttpClient {
    constructor(private http: HttpClient) { }

    private baseUrl: string = 'http://fm.api.local/api/';

    post<T>(controller: string, body: any | null): Observable<T> {
        let url: string = this.baseUrl + controller;
        return this.http.post<T>(url, body, { withCredentials: true });
    }
}

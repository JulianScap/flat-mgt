import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams, HttpErrorResponse } from "@angular/common/http";
import { Observable } from "rxjs/Observable";

import "rxjs/add/operator/catch";
import "rxjs/add/operator/do";
import "rxjs/add/observable/throw";

@Injectable()
export class CorsHttpClient {
    constructor(private http: HttpClient) { }

    private baseUrl: string = 'http://fm.api.local/api/';

    post<T>(controller: string, body: any | null): Observable<T> {
        let url: string = this.baseUrl + controller;
        return this.http.post<T>(url, body, { withCredentials: true })
            .do(data => console.log(JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(err: HttpErrorResponse) {
        console.log(err.message);
        return Observable.throw(err.message);
    }
}

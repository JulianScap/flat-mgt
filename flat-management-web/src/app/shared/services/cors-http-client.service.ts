import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/add/observable/throw";
import "rxjs/add/operator/catch";
import "rxjs/add/operator/do";


@Injectable()
export class CorsHttpClient {
    private baseUrl: string = 'http://fm.api.local/api/';

    constructor(private http: HttpClient) { }

    getOptions(): { headers?: HttpHeaders; withCredentials?: boolean; } {
        return { withCredentials: true };
    }

    get<T>(controller: string): Observable<T> {
        let url: string = this.baseUrl + controller;
        return this.http.get<T>(url, this.getOptions())
            .do(data => console.log(JSON.stringify(data)))
            .catch(this.handleError);
    }

    post<T>(controller: string, body?: any): Observable<T> {
        let url: string = this.baseUrl + controller;
        return this.http.post<T>(url, body, this.getOptions())
            .do(data => console.log(JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(err: HttpErrorResponse) {
        console.log(err.message);
        return Observable.throw(err.message);
    }
}

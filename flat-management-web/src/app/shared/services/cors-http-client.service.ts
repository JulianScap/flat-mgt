import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/add/observable/throw";
import "rxjs/add/operator/catch";
import "rxjs/add/operator/do";


@Injectable()
export class CorsHttpClient {
  logReponse(data: any): void {
    console.log("Reponse: " + JSON.stringify(data));
  }

  logBody(body: any): void {
    console.log("Body: " + JSON.stringify(body));
  }
  private baseUrl: string = 'http://fm.api.local/api/';

  constructor(private http: HttpClient) { }

  getOptions(): { headers?: HttpHeaders; withCredentials?: boolean; body?: any; } {
    return { withCredentials: true };
  }

  get<T>(controller: string): Observable<T> {
    let url: string = this.baseUrl + controller;
    return this.http.get<T>(url, this.getOptions())
      .do(data => this.logReponse(data))
      .catch(this.handleError);
  }

  post<T>(controller: string, body?: any): Observable<T> {
    let url: string = this.baseUrl + controller;
    this.logBody(body);
    return this.http.post<T>(url, body, this.getOptions())
      .do(data => this.logReponse(data))
      .catch(this.handleError);
  }

  put<T>(controller: string, body?: any): Observable<T> {
    let url: string = this.baseUrl + controller;
    this.logBody(body);
    return this.http.put<T>(url, body, this.getOptions())
      .do(data => this.logReponse(data))
      .catch(this.handleError);
  }

  delete(controller: string, body?: any): Observable<Object> {
    let url: string = this.baseUrl + controller;
    let options = this.getOptions();
    options.body = body;
    this.logBody(body);
    return this.http.request('DELETE', url, options)
      .do(data => this.logReponse(data))
      .catch(this.handleError);
  }

  private handleError(err: HttpErrorResponse) {
    console.log(err.message);
    return Observable.throw(err.message);
  }
}

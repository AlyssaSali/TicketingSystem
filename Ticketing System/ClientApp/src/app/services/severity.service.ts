import { Injectable, Inject } from '@angular/core';
import { MyResponse } from '../models/myresponse.model';
import { Observable } from 'rxjs';
import { Severity } from '../models/severity.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class SeverityService {
  severityApi: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseURL:string
  ) {
    this.severityApi=baseURL + 'api/Severity/';
   }
   getAll(): Observable<Severity[]> {
     return this.http.get<Severity[]>(this.severityApi +'GetAll')
   }
   getSingleBy(severityid): Observable<Severity> {
    return this.http.get<Severity>(this.severityApi + 'GetSingleBy/' + String(severityid));
  }
  create(severity:Severity): Observable<MyResponse> {
    return this.http.post<MyResponse>(this.severityApi + 'Create', severity);
  }
    update(severity:Severity): Observable<MyResponse> {
    return this.http.put<MyResponse>(this.severityApi + 'Update', severity);
  }
  delete(severityid): Observable<MyResponse> {
    return this.http.delete<MyResponse>(this.severityApi + 'Delete/'+ String(severityid));
  }
}


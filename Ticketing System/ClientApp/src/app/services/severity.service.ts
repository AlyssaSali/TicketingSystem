import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { inject } from '@angular/core/testing';
import { Observable } from 'rxjs';
import { MyResponse } from '../models/MyResponse.model';
import { Severity } from '../models/severity.model';

@Injectable({
  providedIn: 'root'
})
export class SeverityService {
  severityApi: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl:string
  ) { 
    this.severityApi = baseUrl + 'api/Severity/';
  }

  getAll(): Observable<Severity[]> {
    return this.http.get<Severity[]>(this.severityApi + 'GetAll');
  }

  getSingleBy(id): Observable<Severity> {
    return this.http.get<Severity>(this.severityApi + 'GetSingleby/' + String(id));
  }

  create(severity: Severity) : Observable<MyResponse>{
    return this.http.post<MyResponse>(this.severityApi + 'Create', severity);
  }

  update(severity: Severity) : Observable<MyResponse>{
    return this.http.put<MyResponse>(this.severityApi + 'Update', severity);
  }

  delete(id) : Observable<MyResponse>{
    return this.http.delete<MyResponse>(this.severityApi + 'Delete/' + String(id));
  }

}

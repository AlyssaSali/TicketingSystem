import { Injectable, Inject } from '@angular/core';
import { MyResponse } from '../models/myresponse.model';
import { Observable } from 'rxjs';
import { Office } from '../models/office.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class OfficeService {
  officeApi: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseURL:string
  ) {
    this.officeApi=baseURL + 'api/Office/';
   }
   getAll(): Observable<Office[]> {
     return this.http.get<Office[]>(this.officeApi +'GetAll')
   }
   getSingleBy(officeid): Observable<Office> {
    return this.http.get<Office>(this.officeApi + 'GetSingleBy/' + String(officeid));
  }
  create(office:Office): Observable<MyResponse> {
    return this.http.post<MyResponse>(this.officeApi + 'Create', office);
  }
    update(office:Office): Observable<MyResponse> {
    return this.http.put<MyResponse>(this.officeApi + 'Update', office);
  }
  delete(officeid): Observable<MyResponse> {
    return this.http.delete<MyResponse>(this.officeApi + 'Delete/'+ String(officeid));
  }
}


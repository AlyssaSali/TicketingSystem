import { Injectable, Inject } from '@angular/core';
import { MyResponse } from '../models/myresponse.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Itgroup } from '../models/itgroup.model';

@Injectable({
  providedIn: 'root'
})

export class ItgroupService {
  itgroupApi: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseURL:string
  ) {
    this.itgroupApi=baseURL + 'api/Itgroup/';
   }
   getAll(): Observable<Itgroup[]> {
     return this.http.get<Itgroup[]>(this.itgroupApi +'GetAll')
   }
   getSingleBy(itGroupid): Observable<Itgroup> {
    return this.http.get<Itgroup>(this.itgroupApi + 'GetSingleBy/' + String(itGroupid));
  }
  create(itgroup:Itgroup): Observable<MyResponse> {
    return this.http.post<MyResponse>(this.itgroupApi + 'Create', itgroup);
  }
    update(itgroup:Itgroup): Observable<MyResponse> {
    return this.http.put<MyResponse>(this.itgroupApi + 'Update', itgroup);
  }
  delete(itGroupid): Observable<MyResponse> {
    return this.http.delete<MyResponse>(this.itgroupApi + 'Delete/'+ String(itGroupid));
  }
}


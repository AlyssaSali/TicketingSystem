import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { inject } from '@angular/core/testing';
import { Observable } from 'rxjs';
import { MyResponse } from '../models/MyResponse.model';
import { TicketMinor } from '../models/ticketMinor.model';

@Injectable({
  providedIn: 'root'
})
export class TicketMinorService {
  ticketMinorApi: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl:string
  ) { 
    this.ticketMinorApi = baseUrl + 'api/TicketMinor/';
  }

  getAll(): Observable<TicketMinor[]> {
    return this.http.get<TicketMinor[]>(this.ticketMinorApi + 'GetAll');
  }

  getSingleBy(ticketMinorid): Observable<TicketMinor> {
    return this.http.get<TicketMinor>(this.ticketMinorApi + 'GetSingleby/' + String(ticketMinorid));
  }

  create(ticketMinor: TicketMinor) : Observable<MyResponse>{
    return this.http.post<MyResponse>(this.ticketMinorApi + 'Create', ticketMinor);
  }

  update(ticketMinor: TicketMinor) : Observable<MyResponse>{
    return this.http.put<MyResponse>(this.ticketMinorApi + 'Update', ticketMinor);
  }

  delete(ticketMinorid) : Observable<MyResponse>{
    return this.http.delete<MyResponse>(this.ticketMinorApi + 'Delete/' + String(ticketMinorid));
  }

}

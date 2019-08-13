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
  ticketApi: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl:string
  ) { 
    this.ticketApi = baseUrl + 'api/TicketMinor/';
  }

  getAll(): Observable<TicketMinor[]> {
    return this.http.get<TicketMinor[]>(this.ticketApi + 'GetAll');
  }

  getSingleBy(ticketid): Observable<TicketMinor> {
    return this.http.get<TicketMinor>(this.ticketApi + 'GetSingleby/' + String(ticketid));
  }

  create(ticket: TicketMinor) : Observable<MyResponse>{
    return this.http.post<MyResponse>(this.ticketApi + 'Create', ticket);
  }

  update(ticket: TicketMinor) : Observable<MyResponse>{
    return this.http.put<MyResponse>(this.ticketApi + 'Update', ticket);
  }

  delete(ticketid) : Observable<MyResponse>{
    return this.http.delete<MyResponse>(this.ticketApi + 'Delete/' + String(ticketid));
  }

}

import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { inject } from '@angular/core/testing';
import { Observable } from 'rxjs';
import { MyResponse } from '../models/MyResponse.model';
import { Ticket } from '../models/ticket.model';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  ticketApi: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl:string
  ) { 
    this.ticketApi = baseUrl + 'api/Ticket/';
  }

  getAll(): Observable<Ticket[]> {
    return this.http.get<Ticket[]>(this.ticketApi + 'GetAll');
  }

  getSingleBy(ticketid): Observable<Ticket> {
    return this.http.get<Ticket>(this.ticketApi + 'GetSingleby/' + String(ticketid));
  }

  create(ticket: Ticket) : Observable<MyResponse>{
    return this.http.post<MyResponse>(this.ticketApi + 'Create', ticket);
  }

  update(ticket: Ticket) : Observable<MyResponse>{
    return this.http.put<MyResponse>(this.ticketApi + 'Update', ticket);
  }

  delete(ticketid) : Observable<MyResponse>{
    return this.http.delete<MyResponse>(this.ticketApi + 'Delete/' + String(ticketid));
  }

}

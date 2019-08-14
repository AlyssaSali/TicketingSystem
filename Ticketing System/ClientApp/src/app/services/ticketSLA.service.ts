import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { inject } from '@angular/core/testing';
import { Observable } from 'rxjs';
import { MyResponse } from '../models/MyResponse.model';
import { TicketSLA } from '../models/ticketSLA.model';

@Injectable({
  providedIn: 'root'
})
export class TicketSLAService {
  ticketSLAApi: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl:string
  ) { 
    this.ticketSLAApi = baseUrl + 'api/Sla/';
  }

  getAll(): Observable<TicketSLA[]> {
    return this.http.get<TicketSLA[]>(this.ticketSLAApi + 'GetAll');
  }

  getSingleBy(ticketSLAid): Observable<TicketSLA> {
    return this.http.get<TicketSLA>(this.ticketSLAApi + 'GetSingleby/' + String(ticketSLAid));
  }

  create(ticketSLA: TicketSLA) : Observable<MyResponse>{
    return this.http.post<MyResponse>(this.ticketSLAApi + 'Create', ticketSLA);
  }

  update(ticketSLA: TicketSLA) : Observable<MyResponse>{
    return this.http.put<MyResponse>(this.ticketSLAApi + 'Update', ticketSLA);
  }

  delete(ticketSLAid) : Observable<MyResponse>{
    return this.http.delete<MyResponse>(this.ticketSLAApi + 'Delete/' + String(ticketSLAid));
  }

}

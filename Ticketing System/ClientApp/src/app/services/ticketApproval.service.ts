import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { inject } from '@angular/core/testing';
import { Observable } from 'rxjs';
import { MyResponse } from '../models/MyResponse.model';
import { TicketApproval } from '../models/ticketApproval.model';

@Injectable({
  providedIn: 'root'
})
export class TicketApprovalService {
  ticketApprovalApi: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl:string
  ) { 
    this.ticketApprovalApi = baseUrl + 'api/TicketApproval/';
  }

  getAll(): Observable<TicketApproval[]> {
    return this.http.get<TicketApproval[]>(this.ticketApprovalApi + 'GetAll');
  }

  getSingleBy(ticketApprovalid): Observable<TicketApproval> {
    return this.http.get<TicketApproval>(this.ticketApprovalApi + 'GetSingleby/' + String(ticketApprovalid));
  }

  create(ticketApproval: TicketApproval) : Observable<MyResponse>{
    return this.http.post<MyResponse>(this.ticketApprovalApi + 'Create', ticketApproval);
  }

  update(ticketApproval: TicketApproval) : Observable<MyResponse>{
    return this.http.put<MyResponse>(this.ticketApprovalApi + 'Update', ticketApproval);
  }

  delete(ticketApprovalid) : Observable<MyResponse>{
    return this.http.delete<MyResponse>(this.ticketApprovalApi + 'Delete/' + String(ticketApprovalid));
  }

}

import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { TicketApproval } from '../models/ticketApproval.model';

@Injectable({
    providedIn:'root'
})
export class TicketApprovalDataService implements
OnDestroy{
    
    ticketApprovalSource=new BehaviorSubject<TicketApproval[]>([]);
    ticketApprovals =this.ticketApprovalSource.asObservable();
    
    constructor(){
    }
        refreshTicketApprovals(){
            this.ticketApprovalSource.next(null);
        }
        ngOnDestroy(){
            this.ticketApprovalSource.unsubscribe();
        }
   
}

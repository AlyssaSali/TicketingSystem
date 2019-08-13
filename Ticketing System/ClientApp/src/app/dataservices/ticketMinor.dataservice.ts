import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { TicketMinor } from '../models/ticketMinor.model';

@Injectable({
    providedIn:'root'
})
export class TicketMinorDataService implements
OnDestroy{
    
    ticketSource=new BehaviorSubject<TicketMinor[]>([]);
    tickets =this.ticketSource.asObservable();
    
    constructor(){
    }
        refreshTicketMinors(){
            this.ticketSource.next(null);
        }
        ngOnDestroy(){
            this.ticketSource.unsubscribe();
        }
   
}

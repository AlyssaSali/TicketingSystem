import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { TicketMinor } from '../models/ticketMinor.model';

@Injectable({
    providedIn:'root'
})
export class TicketMinorDataService implements
OnDestroy{
    
    ticketMinorSource=new BehaviorSubject<TicketMinor[]>([]);
    ticketMinors =this.ticketMinorSource.asObservable();
    
    constructor(){
    }
        refreshTicketMinors(){
            this.ticketMinorSource.next(null);
        }
        ngOnDestroy(){
            this.ticketMinorSource.unsubscribe();
        }
   
}

import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { TicketSLA } from '../models/ticketSLA.model';

@Injectable({
    providedIn:'root'
})
export class TicketSLADataService implements
OnDestroy{
    
    ticketSLASource=new BehaviorSubject<TicketSLA[]>([]);
    ticketSLAs =this.ticketSLASource.asObservable();
    
    constructor(){
    }
        refreshTicketSLAs(){
            this.ticketSLASource.next(null);
        }
        ngOnDestroy(){
            this.ticketSLASource.unsubscribe();
        }
   
}

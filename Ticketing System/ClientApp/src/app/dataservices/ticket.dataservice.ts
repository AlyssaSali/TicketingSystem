import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Ticket } from '../models/ticket.model';


@Injectable({
    providedIn: 'root'
})

export class TicketDataservice implements 
    OnDestroy {

    ticketSource = new BehaviorSubject<Ticket[]>([]);
    tickets = this.ticketSource.asObservable();

    /**
     *
     */
    constructor() {
    }

    refreshBooks() {
        this.ticketSource.next(null);
    }
    
    ngOnDestroy() {
        this.ticketSource.unsubscribe();
    }

    }

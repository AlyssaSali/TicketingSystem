import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Office } from '../models/office.model';

@Injectable({
    providedIn:'root'
})
export class OfficeDataService implements
OnDestroy{
    
    officeSource=new BehaviorSubject<Office[]>([]);
    offices =this.officeSource.asObservable();
    
    constructor(){
    }
        refreshOffices(){
            this.officeSource.next(null);
        }
        ngOnDestroy(){
            this.officeSource.unsubscribe();
        }
   
}

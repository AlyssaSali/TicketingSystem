import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Itgroup } from '../models/itgroup.model';


@Injectable({
    providedIn:'root'
})
export class ItgroupDataService implements
OnDestroy{
    
    itgroupSource=new BehaviorSubject<Itgroup[]>([]);
    itgroups =this.itgroupSource.asObservable();
    
    constructor(){
    }
        refreshItgroups(){
            this.itgroupSource.next(null);
        }
        ngOnDestroy(){
            this.itgroupSource.unsubscribe();
        }
   
}

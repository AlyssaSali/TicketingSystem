import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Itgroupmember } from '../models/itgroupmember.model';



@Injectable({
    providedIn:'root'
})
export class ItgroupmemberDataService implements
OnDestroy{
    
    itgroupmemberSource=new BehaviorSubject<Itgroupmember[]>([]);
    itgroupmembers =this.itgroupmemberSource.asObservable();
    
    constructor(){
    }
        refreshItgroupmembers(){
            this.itgroupmemberSource.next(null);
        }
        ngOnDestroy(){
            this.itgroupmemberSource.unsubscribe();
        }
   
}


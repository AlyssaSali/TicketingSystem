import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Severity } from '../models/severity.model';

@Injectable({
    providedIn:'root'
})
export class SeverityDataService implements
OnDestroy{
    
    severitySource=new BehaviorSubject<Severity[]>([]);
    severities =this.severitySource.asObservable();
    
    constructor(){
    }
        refreshSeverities(){
            this.severitySource.next(null);
        }
        ngOnDestroy(){
            this.severitySource.unsubscribe();
        }
   
}

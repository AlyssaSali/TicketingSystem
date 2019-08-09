import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Severity } from '../models/severity.model';


@Injectable({
    providedIn: 'root'
})

export class SeverityDataservice implements 
    OnDestroy {

    severitySource = new BehaviorSubject<Severity[]>([]);
    severitys = this.severitySource.asObservable();

    /**
     *
     */
    constructor() {
    }

    refreshBooks() {
        this.severitySource.next(null);
    }
    
    ngOnDestroy() {
        this.severitySource.unsubscribe();
    }

    }

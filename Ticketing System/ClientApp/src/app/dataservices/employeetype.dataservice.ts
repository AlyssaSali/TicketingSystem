import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { EmployeeType } from '../models/employeetype.model';

@Injectable({
    providedIn:'root'
})
export class EmployeeTypeDataService implements
OnDestroy{
    
    employeeTypeSource=new BehaviorSubject<EmployeeType[]>([]);
    employeeTypes =this.employeeTypeSource.asObservable();
    
    constructor(){
    }
        refreshEmployeeTypes(){
            this.employeeTypeSource.next(null);
        }
        ngOnDestroy(){
            this.employeeTypeSource.unsubscribe();
        }
   
}

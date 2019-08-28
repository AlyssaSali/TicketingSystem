import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { EmployeeEmployeeType } from '../models/employee-employee-type.model';



@Injectable({
    providedIn:'root'
})
export class EmployeeEmployeeTypeDataService implements
OnDestroy{
    
    employeeEmployeeTypeSource=new BehaviorSubject<EmployeeEmployeeType[]>([]);
    employeeEmployeeTypes =this.employeeEmployeeTypeSource.asObservable();
    
    constructor(){
    }
        refreshEmployeeEmployeeTypes(){
            this.employeeEmployeeTypeSource.next(null);
        }
        ngOnDestroy(){
            this.employeeEmployeeTypeSource.unsubscribe();
        }
   
}


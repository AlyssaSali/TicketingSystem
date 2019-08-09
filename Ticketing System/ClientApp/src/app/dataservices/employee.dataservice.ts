import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Employee } from '../models/employee.model';

@Injectable({
    providedIn: 'root'
})
export class EmployeeDataService {
    employeeSource = new BehaviorSubject<Employee[]>([]);
    employees = this.employeeSource.asObservable();

    //refresh other component that subcribes to it
    refreshEmployees(){
        this.employeeSource.next(null);
    }
    ngOnDestroy(){
        //Called once, before the instance is destroyed.
        //Add 'implements OnDestroy' to the class.
        this.employeeSource.unsubscribe();
    }
}

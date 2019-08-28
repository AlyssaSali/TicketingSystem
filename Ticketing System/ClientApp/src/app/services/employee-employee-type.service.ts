import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EmployeeEmployeeType } from '../models/employee-employee-type.model';
import { Observable } from 'rxjs';
import { MyResponse } from '../models/myresponse.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeEmployeeTypeService {

  employeeEmployeeTypeApi: string;
  
    constructor(
      private http: HttpClient,
      @Inject('BASE_URL') baseURL:string
    ) {
      this.employeeEmployeeTypeApi=baseURL + 'api/EmployeeEmployeeType/';
     }
     getAll(): Observable<EmployeeEmployeeType[]> {
       return this.http.get<EmployeeEmployeeType[]>(this.employeeEmployeeTypeApi +'GetAll')
     }
     getSingleBy(employeeEmployeeTypeid): Observable<EmployeeEmployeeType> {
      return this.http.get<EmployeeEmployeeType>(this.employeeEmployeeTypeApi + 'GetSingleBy/' + String(employeeEmployeeTypeid));
    }
    create(employeeEmployeeType:EmployeeEmployeeType): Observable<MyResponse> {
      console.log("error----------------------------");
      
      return this.http.post<MyResponse>(this.employeeEmployeeTypeApi + 'Create', employeeEmployeeType);
    }
      update(employeeEmployeeType:EmployeeEmployeeType): Observable<MyResponse> {
      return this.http.put<MyResponse>(this.employeeEmployeeTypeApi + 'Update', employeeEmployeeType);
    }
    delete(employeeEmployeeTypeid): Observable<MyResponse> {
      return this.http.delete<MyResponse>(this.employeeEmployeeTypeApi + 'Delete/'+ String(employeeEmployeeTypeid));
    }
    getDataServerSide(dtParams: any): Observable<any> {  
      return this.http.post(`${this.employeeEmployeeTypeApi}GetDataServerSide`, dtParams);          
    }
  }


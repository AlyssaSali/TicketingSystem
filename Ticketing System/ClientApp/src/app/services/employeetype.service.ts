import { Injectable, Inject } from '@angular/core';
import { MyResponse } from '../models/myresponse.model';
import { Observable } from 'rxjs';
import { EmployeeType } from '../models/employeetype.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class EmployeeTypeService {
  employeetypeApi: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseURL:string
  ) {
    this.employeetypeApi=baseURL + 'api/EmployeeType/';
   }
   getAll(): Observable<EmployeeType[]> {
     return this.http.get<EmployeeType[]>(this.employeetypeApi +'GetAll')
   }
   getSingleBy(employeeTypeid): Observable<EmployeeType> {
    return this.http.get<EmployeeType>(this.employeetypeApi + 'GetSingleBy/' + String(employeeTypeid));
  }
  create(employeetype:EmployeeType): Observable<MyResponse> {
    return this.http.post<MyResponse>(this.employeetypeApi + 'Create', employeetype);
  }
    update(employeetype:EmployeeType): Observable<MyResponse> {
    return this.http.put<MyResponse>(this.employeetypeApi + 'Update', employeetype);
  }
  delete(employeeTypeid): Observable<MyResponse> {
    return this.http.delete<MyResponse>(this.employeetypeApi + 'Delete/'+ String(employeeTypeid));
  }
}


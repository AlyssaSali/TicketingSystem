import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee.model';
import { MyResponse } from '../models/myresponse.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  employeeApi: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) { 
    this.employeeApi = baseUrl + 'api/Employee/'; //sets default url for front end
  }

  //getall
  ListEmployees() : Observable<Employee[]> {
    return this.http.get<Employee[]>(this.employeeApi + 'ListEmployees');
  }

  //getSingleBy
  FindEmployee(id) : Observable<Employee> {
    return this.http.get<Employee>(this.employeeApi + 'FindEmployee/' + String(id));
  }

  //create
  CreateEmployee(employee: Employee) : Observable<MyResponse> {
    return this.http.post<MyResponse>(this.employeeApi + 'CreateEmployee', employee);
  }

  //edit
  UpdateEmployee(employee: Employee) : Observable<MyResponse> {
    return this.http.put<MyResponse>(this.employeeApi + 'UpdateEmployee', employee);
  }

  //delete
  DeleteEmployee(id) : Observable<MyResponse> {
    return this.http.delete<MyResponse>(this.employeeApi + 'DeleteEmployee/' + String(id));
  }
}

import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Itgroupmember } from '../models/itgroupmember.model';
import { MyResponse } from '../models/myresponse.model';

@Injectable({
  providedIn: 'root'
})
export class ItgroupmemberService {
    itgroupmemberApi: string;
  
    constructor(
      private http: HttpClient,
      @Inject('BASE_URL') baseURL:string
    ) {
      this.itgroupmemberApi=baseURL + 'api/Itgroupmember/';
     }
     getAll(): Observable<Itgroupmember[]> {
       return this.http.get<Itgroupmember[]>(this.itgroupmemberApi +'GetAll')
     }
     getSingleBy(itGroupMemberid): Observable<Itgroupmember> {
      return this.http.get<Itgroupmember>(this.itgroupmemberApi + 'GetSingleBy/' + String(itGroupMemberid));
    }
    create(itgroupmember:Itgroupmember): Observable<MyResponse> {
      console.log("error----------------------------");
      
      return this.http.post<MyResponse>(this.itgroupmemberApi + 'Create', itgroupmember);
    }
      update(itgroupmember:Itgroupmember): Observable<MyResponse> {
      return this.http.put<MyResponse>(this.itgroupmemberApi + 'Update', itgroupmember);
    }
    delete(itGroupMemberid): Observable<MyResponse> {
      return this.http.delete<MyResponse>(this.itgroupmemberApi + 'Delete/'+ String(itGroupMemberid));
    }
    getDataServerSide(dtParams: any): Observable<any> {  
      return this.http.post(`${this.itgroupmemberApi}GetDataServerSide`, dtParams);          
    }
  }

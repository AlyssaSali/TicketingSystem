import { Injectable, Inject } from '@angular/core';
import { MyResponse } from '../models/myresponse.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { CategoryList } from '../models/categoryList.model';

@Injectable({
  providedIn: 'root'
})

export class CategoryListService {
  categoryListApi: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseURL:string
  ) {
    this.categoryListApi=baseURL + 'api/CategoryList/';
   }
   getAll(): Observable<CategoryList[]> {
     return this.http.get<CategoryList[]>(this.categoryListApi +'GetAll')
   }
   getSingleBy(categoryListid): Observable<CategoryList> {
    return this.http.get<CategoryList>(this.categoryListApi + 'GetSingleBy/' + String(categoryListid));
  }
  create(categoryList:CategoryList): Observable<MyResponse> {
    return this.http.post<MyResponse>(this.categoryListApi + 'Create', categoryList);
  }
    update(categoryList:CategoryList): Observable<MyResponse> {
    return this.http.put<MyResponse>(this.categoryListApi + 'Update', categoryList);
  }
  delete(categoryListid): Observable<MyResponse> {
    return this.http.delete<MyResponse>(this.categoryListApi + 'Delete/'+ String(categoryListid));
  }
}


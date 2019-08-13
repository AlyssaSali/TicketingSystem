import { Injectable, Inject } from '@angular/core';
import { MyResponse } from '../models/myresponse.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root'
})

export class CategoryService {
  categoryApi: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseURL:string
  ) {
    this.categoryApi=baseURL + 'api/Category/';
   }
   getAll(): Observable<Category[]> {
     return this.http.get<Category[]>(this.categoryApi +'GetAll')
   }
   getSingleBy(categoryid): Observable<Category> {
    return this.http.get<Category>(this.categoryApi + 'GetSingleBy/' + String(categoryid));
  }
  create(category:Category): Observable<MyResponse> {
    return this.http.post<MyResponse>(this.categoryApi + 'Create', category);
  }
    update(category:Category): Observable<MyResponse> {
    return this.http.put<MyResponse>(this.categoryApi + 'Update', category);
  }
  delete(categoryid): Observable<MyResponse> {
    return this.http.delete<MyResponse>(this.categoryApi + 'Delete/'+ String(categoryid));
  }
}


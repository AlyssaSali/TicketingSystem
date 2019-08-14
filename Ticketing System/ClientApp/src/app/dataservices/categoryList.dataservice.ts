import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { CategoryList } from '../models/categoryList.model';

@Injectable({
    providedIn:'root'
})
export class CategoryListDataService implements
OnDestroy{
    
    categoryListSource=new BehaviorSubject<CategoryList[]>([]);
    categoryLists =this.categoryListSource.asObservable();
    
    constructor(){
    }
        refreshCategorylists(){
            this.categoryListSource.next(null);
        }
        ngOnDestroy(){
            this.categoryListSource.unsubscribe();
        }
   
}

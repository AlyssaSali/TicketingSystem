import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Category } from '../models/category.model';

@Injectable({
    providedIn:'root'
})
export class CategoryDataService implements
OnDestroy{
    
    categorySource=new BehaviorSubject<Category[]>([]);
    categories =this.categorySource.asObservable();
    
    constructor(){
    }
        refreshCategorys(){
            this.categorySource.next(null);
        }
        ngOnDestroy(){
            this.categorySource.unsubscribe();
        }
   
}

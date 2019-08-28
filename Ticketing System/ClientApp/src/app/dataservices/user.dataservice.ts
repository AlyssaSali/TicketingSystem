import { Injectable, OnDestroy } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
    providedIn:'root'
})
export class UserDataService implements OnDestroy{
    userSource = new BehaviorSubject<User[]>([]);
    users = this.userSource.asObservable();

    constructor(){

    }
    refreshUsers(){
        this.userSource.next(null);
    }
    ngOnDestroy(){
        this.userSource.unsubscribe();
    }
}



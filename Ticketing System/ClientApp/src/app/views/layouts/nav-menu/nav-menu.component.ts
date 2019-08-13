import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit{
  isExpanded = false;
  isLogin: boolean;
  
  options: FormGroup;

  constructor(fb: FormBuilder) {
    this.options = fb.group({
      'fixed': false,
      'top': 0,
      'bottom': 0,
    });
  }

  shouldRun = [/(^|\.)plnkr\.co$/, /(^|\.)stackblitz\.io$/].some(h => h.test(window.location.host));


  ngOnInit(){
    this.checkLogin();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  checkLogin(){
    let token = localStorage.getItem("token")
    if(token){
      this.isLogin = true
    } else
      this.isLogin = false
  }

  logout(){
    let answer = confirm('Are you sure you want to logout')
    if(answer){
      localStorage.removeItem('token')
      this.isLogin = false;
      window.location.replace('/')
    }
  }
}

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit {
  isExpanded = false;
  isLogin: boolean;
  role: string;
  dropdown = document.getElementsByClassName("dropdown-btn");

  constructor() { }

  ngOnInit() {
    this.checkLogin();
  }
  //* Loop through all dropdown buttons to toggle between hiding and showing its dropdown content - This allows the user to have multiple dropdowns without any conflict */

 
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  checkLogin(){
    let token = localStorage.getItem('token')
    if(token){
      var payLoad = JSON.parse(window.atob(token.split('.')[1]));
      // takes the role from the token data
      var userRole = payLoad.role;
      this.role = userRole;
      this.isLogin = true;
    } else {
      this.isLogin = false;
    }
  }
  dropdownlist()
  {
    var i;
    for (i = 0; i < this.dropdown.length; i++) {
      this.dropdown[i].addEventListener("click", function() {
      this.classList.toggle("active");
      var dropdownContent = this.nextElementSibling;
      if (dropdownContent.style.display === "block") {
        dropdownContent.style.display = "none";
      } else {
        dropdownContent.style.display = "block";
      }
    });
    }
  }
 

}

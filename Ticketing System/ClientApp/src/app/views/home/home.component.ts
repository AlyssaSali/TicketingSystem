import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  isLogin: boolean;
  userName: string;

  constructor(
<<<<<<< HEAD
    private userService: UserService,
    private toastrService: ToastrService
  ){  }

  ngOnInit(){
    this.checkLogin();
  }
  
  checkLogin(){
    let token = localStorage.getItem('token')
    if(token){
      this.isLogin = true;
      this.getUserInfo();
    } else {
      this.isLogin = false;
    }
=======
<<<<<<< HEAD
    //private toastServcie: ToastrService
=======
   // private toastServcie: ToastrService
>>>>>>> 2fb85b2afa0a42a16fcb96d7ab04b103ede54f15
  ) {
>>>>>>> 89bb63c04e1ad5424f19b0fd116240805a791ee4
  }

  async getUserInfo(){
    try {
      let userInfo = await this.userService.userProfile().toPromise();
      this.userName = userInfo.userName;
    } catch (error) {
      this.toastrService.error('Something went wrong');
    }
  }
}

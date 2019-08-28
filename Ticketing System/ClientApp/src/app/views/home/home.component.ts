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
=======
<<<<<<< HEAD
=======
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
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
>>>>>>> b91f36f85f748ef16088c8249afe1aa938eb57c2
   // private toastServcie: ToastrService
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

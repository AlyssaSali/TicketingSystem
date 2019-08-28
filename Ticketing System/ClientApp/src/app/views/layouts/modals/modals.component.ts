import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { Router } from '@angular/router';

@Component({
  selector: 'app-modals',
  templateUrl: './modals.component.html',
  styleUrls: ['./modals.component.css']
})
export class ModalsComponent implements OnInit {

  constructor(
<<<<<<< HEAD
    public dialogRef: MatDialogRef<ModalsComponent>,
=======
    // public dialogRef: MatDialogRef<ModalsComponent>,
>>>>>>> 00d9a0867d956b23e7a3c0e36fce9ae308d939f7
    private router: Router
  ) { }

  ngOnInit() {
  }

  // close(){
  //   this.dialogRef.close();
  // }

  loadEmployeeType(){
    this.router.navigate(["/employeeType"]);
  }

  loadEmployeeType(){
    this.router.navigate(["/employeeType"]);
  }

}

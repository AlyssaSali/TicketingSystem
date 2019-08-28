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
    // public dialogRef: MatDialogRef<ModalsComponent>,
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

}

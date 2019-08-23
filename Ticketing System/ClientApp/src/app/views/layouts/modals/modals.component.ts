import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-modals',
  templateUrl: './modals.component.html',
  styleUrls: ['./modals.component.css']
})
export class ModalsComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<ModalsComponent>
  ) { }

  ngOnInit() {
  }

  close(){
    this.dialogRef.close();
  }

}

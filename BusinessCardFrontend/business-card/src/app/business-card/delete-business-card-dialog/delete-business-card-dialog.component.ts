import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-delete-business-card-dialog',
  templateUrl: './delete-business-card-dialog.component.html',
  styleUrls: ['./delete-business-card-dialog.component.scss']
})
export class DeleteBusinessCardDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<DeleteBusinessCardDialogComponent>) {}

  ngOnInit(): void {
  }


  onConfirm(): void {
    this.dialogRef.close(true); // Pass true if confirmed
  }

  onCancel(): void {
    this.dialogRef.close(false); // Pass false if canceled
  }
}

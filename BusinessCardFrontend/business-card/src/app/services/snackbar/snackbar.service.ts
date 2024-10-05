import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

  constructor(private snackBar: MatSnackBar) {}

  showError(message: string) {
    this.snackBar.open(message, 'Close', {
      duration: 5000, // Duration in milliseconds
      panelClass: ['error-snackbar'], // Optional: Custom CSS class
    });
  }

  showSuccess(message: string) {
    this.snackBar.open(message, 'Close', {
      duration: 5000,
      panelClass: ['success-snackbar'], // Custom CSS class for success
    });
  }
}

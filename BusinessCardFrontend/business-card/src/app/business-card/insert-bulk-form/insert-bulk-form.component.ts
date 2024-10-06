import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BusinessCardService } from 'src/app/services/business-card/business-card.service';
import { SnackbarService } from 'src/app/services/snackbar/snackbar.service';
import { FileType } from '../models/fileType';
import { Router } from '@angular/router';

@Component({
  selector: 'app-insert-bulk-form',
  templateUrl: './insert-bulk-form.component.html',
  styleUrls: ['./insert-bulk-form.component.scss']
})
export class InsertBulkFormComponent implements OnInit {
  businessCardForm!: FormGroup;
  file: File | undefined; // Keep track of the selected file
  filePreview: string | undefined; // Preview for image files
  fileType: FileType | undefined; // To store the file type for validation
  isLoading = false;

  constructor(
    private businessCardService: BusinessCardService,
    private snackbarService: SnackbarService,
    private fb: FormBuilder,
    private router: Router) {
    this.businessCardForm = this.fb.group({
      file: [null], // Changed 'image' to 'file'
    });
  }

  ngOnInit(): void { }

  getFile(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length) {
      const file = input.files[0];
      this.updateFile(file);
    }
  }

  onDrop(event: DragEvent): void {
    event.preventDefault(); // Prevent default behavior
    event.stopPropagation();

    if (event.dataTransfer?.files) {
      this.updateFile(event.dataTransfer.files[0]); // Update the file on drop
    }
  }

  updateFile(file: File): void {
    debugger;
    const validFileTypes = ['text/csv', 'application/xml', 'text/xml', 'image/png', 'image/jpeg', 'image/gif'];
    if (validFileTypes.includes(file.type)) {
      this.businessCardForm.patchValue({ file }); // Update the form control with the file
      if (file.type == 'text/csv') {
        this.fileType = FileType.csv;
      } else if (file.type == 'application/xml' || file.type == 'text/xml') {
        this.fileType = FileType.xml;
      } else {
        this.fileType = FileType.qrCode;
      }
      this.previewFile(file); // Preview the file
    } else {
      this.snackbarService.showError('Invalid file type. Please upload a CSV, XML, or an image file.');
    }
  }

  previewFile(file: File): void {
    // Preview only if the file is an image
    if (this.fileType == FileType.qrCode) {
      const reader = new FileReader();
      reader.onload = (e) => {
        this.filePreview = e.target?.result as string; // Convert result to string for image preview
      };
      reader.readAsDataURL(file); // Read file as data URL for preview
    } else {
      this.filePreview = undefined; // Clear preview for non-image files
    }
  }

  onDragOver(event: DragEvent): void {
    event.preventDefault(); // Prevent default behavior
    event.stopPropagation();
    const dropArea = event.currentTarget as HTMLElement;
    dropArea.classList.add('drag-over'); // Add the drag-over class for styling
  }

  onDragLeave(event: DragEvent): void {
    event.preventDefault(); // Prevent default behavior
    event.stopPropagation();
    const dropArea = event.currentTarget as HTMLElement;
    dropArea.classList.remove('drag-over'); // Remove the drag-over class
  }

  clearFile(): void {
    this.businessCardForm.patchValue({ file: null }); // Clear the form control value
    this.filePreview = undefined; // Clear the file preview
    this.fileType = undefined; // Clear the file type
  }

  uploadFile() {
    this.isLoading = true;
    this.businessCardService.import(this.businessCardForm.get("file")?.value, this.fileType!).subscribe(
      res => {
        this.snackbarService.showSuccess("Inserted successfully");
        this.isLoading = false;
        this.router.navigate(["../"])
      }, err => {
        this.snackbarService.showError("Can't insert");
        this.isLoading = false;
      }
    )
  }
}

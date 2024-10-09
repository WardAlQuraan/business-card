import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SnackbarService } from 'src/app/services/snackbar/snackbar.service';
import { FileType } from '../models/fileType';

@Component({
  selector: 'app-insert-bulk-form',
  templateUrl: './insert-bulk-form.component.html',
  styleUrls: ['./insert-bulk-form.component.scss']
})
export class InsertBulkFormComponent implements OnInit {
  businessCardForm!: FormGroup;
  selectedFile?: File; // To store the selected file
  filePreviewUrl?: string; // URL for image preview
  fileType?: FileType; // File type for validation
  isLoading = false;

  constructor(
    private formBuilder: FormBuilder,
    private snackbarService: SnackbarService
  ) {
    this.businessCardForm = this.formBuilder.group({
      file: [null], // 'file' field in the form
    });
  }

  ngOnInit(): void { }

  handleFileInput(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      const file = input.files[0];
      this.processFile(file);
    }
  }

  handleFileDrop(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();

    if (event.dataTransfer?.files && event.dataTransfer.files.length > 0) {
      this.processFile(event.dataTransfer.files[0]); // Process the dropped file
    }
  }

  processFile(file: File): void {
    const allowedFileTypes = ['text/csv', 'application/xml', 'text/xml', 'image/png', 'image/jpeg', 'image/gif'];

    if (allowedFileTypes.includes(file.type)) {
      this.businessCardForm.patchValue({ file }); // Update form with selected file

      if (file.type === 'text/csv') {
        this.fileType = FileType.csv;
      } else if (file.type === 'application/xml' || file.type === 'text/xml') {
        this.fileType = FileType.xml;
      } else {
        this.fileType = FileType.qrCode;
      }

      this.generateFilePreview(file); // Generate preview for the selected file
    } else {
      this.snackbarService.showError('Invalid file type. Please upload a CSV, XML, or image file.');
    }
  }

  generateFilePreview(file: File): void {
    this.selectedFile = file;

    if (this.fileType === FileType.qrCode) {
      const reader = new FileReader();
      reader.onload = (e) => {
        this.filePreviewUrl = e.target?.result as string; // Store image preview URL
      };
      reader.readAsDataURL(file); // Read file as a data URL for image preview
    } else {
      this.filePreviewUrl = undefined; // No preview for non-image files
    }
  }

  handleDragOver(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
    const dropArea = event.currentTarget as HTMLElement;
    dropArea.classList.add('drag-over'); // Add styling for drag over effect
  }

  handleDragLeave(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
    const dropArea = event.currentTarget as HTMLElement;
    dropArea.classList.remove('drag-over'); // Remove drag over styling
  }

  clearFileSelection(): void {
    this.businessCardForm.patchValue({ file: null }); // Clear the form control
    this.filePreviewUrl = undefined; // Clear the file preview
    this.fileType = undefined; // Reset the file type
    this.selectedFile = undefined;
  }
}

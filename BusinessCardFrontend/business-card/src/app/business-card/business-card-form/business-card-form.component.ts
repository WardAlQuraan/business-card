import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IBusinessCard } from '../models/business-card';
import { BusinessCardService } from 'src/app/services/business-card/business-card.service';
import { SnackbarService } from 'src/app/services/snackbar/snackbar.service';

@Component({
  selector: 'app-business-card-form',
  templateUrl: './business-card-form.component.html',
  styleUrls: ['./business-card-form.component.scss']
})
export class BusinessCardFormComponent implements OnInit {

  businessCardForm!: FormGroup;
  file: File | undefined;
  imagePreview: string | undefined;

  constructor(private fb: FormBuilder, private businessCardService: BusinessCardService, private snackbarService: SnackbarService) {
    this.businessCardForm = this.fb.group({
      name: ['', Validators.required], // Required
      gender: ['', Validators.required], // Required
      dob: ['', Validators.required], // Required
      email: ['', [Validators.required, Validators.email]], // Required and email format
      phone: ['', Validators.required],
      image: [''],
    });
  }

  ngOnInit(): void {}

  getFile(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length) {
      this.updateFile(input.files[0]);
    }
  }

  onDrop(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();

    if (event.dataTransfer?.files) {
      this.updateFile(event.dataTransfer.files[0]); // Update the file on drop
    }
  }

  updateFile(image: File): void {
    this.businessCardForm.patchValue({ image }); // Update the file control
    this.previewImage(image);
  }

  previewImage(file: File): void {
    const reader = new FileReader();
    reader.onload = (e) => {
      this.imagePreview = e.target?.result as string; // Convert result to string
    };
    reader.readAsDataURL(file); // Read file as data URL
  }

  onDragOver(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
    const dropArea = document.querySelector('.drag-drop-area');
    if (dropArea) {
      dropArea.classList.add('drag-over'); // Add the drag-over class
    }
  }

  onDragLeave(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
    const dropArea = document.querySelector('.drag-drop-area');
    if (dropArea) {
      dropArea.classList.remove('drag-over'); // Remove the drag-over class
    }
  }

 onSubmit() {
    if (this.businessCardForm.valid) {
        const formData = new FormData();
        formData.append('name', this.businessCardForm.get('name')?.value);
        formData.append('gender', this.businessCardForm.get('gender')?.value);
        formData.append('dob', this.businessCardForm.get('dob')?.value.toISOString());
        formData.append('email', this.businessCardForm.get('email')?.value);
        formData.append('phone', this.businessCardForm.get('phone')?.value);
        formData.append('image', this.businessCardForm.get('image')?.value); // Use 'file' control to get the uploaded image

        this.businessCardService.insert(formData).subscribe(
            (response) => {
                this.snackbarService.showSuccess('Business card added successfully!');
                this.businessCardForm.reset(); // Reset form after successful submission
                this.file = undefined;
            },
            (error) => {
                console.error('Error inserting business card:', error);
                this.snackbarService.showError('Failed to add business card.');
            }
        );
    } else {
        console.log('Form is invalid', this.businessCardForm);
    }
}

}

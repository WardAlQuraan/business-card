import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BusinessCardService } from 'src/app/services/business-card/business-card.service';
import { SnackbarService } from 'src/app/services/snackbar/snackbar.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-business-card-form',
  templateUrl: './business-card-form.component.html',
  styleUrls: ['./business-card-form.component.scss'],
})
export class BusinessCardFormComponent implements OnInit {
  isLoading = false;
  businessCardForm: FormGroup;
  imagePreview: string | undefined;

  constructor(
    private fb: FormBuilder,
    private businessCardService: BusinessCardService,
    private snackbarService: SnackbarService,
    private router: Router
  ) {
    this.businessCardForm = this.fb.group({
      name: ['', Validators.required],
      gender: ['', Validators.required],
      dob: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required],
      image: [''],
    });
  }

  ngOnInit(): void {}

  getFile(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files?.length) {
      this.updateFile(input.files[0]);
    }
  }
  isFieldInvalid(fieldName: string): boolean {
    const control = this.businessCardForm.get(fieldName)!;
    return control?.hasError('required') && control?.touched;
  }


  onDrop(event: DragEvent): void {
    event.preventDefault();
    if (event.dataTransfer?.files) {
      this.updateFile(event.dataTransfer.files[0]);
    }
  }

  updateFile(image: File): void {
    this.businessCardForm.patchValue({ image });
    this.previewImage(image);
  }

  previewImage(file: File): void {
    const reader = new FileReader();
    reader.onload = (e) => (this.imagePreview = e.target?.result as string);
    reader.readAsDataURL(file);
  }

  onDragOver(event: DragEvent): void {
    event.preventDefault();
    document.querySelector('.drag-drop-area')?.classList.add('drag-over');
  }

  onDragLeave(event: DragEvent): void {
    event.preventDefault();
    document.querySelector('.drag-drop-area')?.classList.remove('drag-over');
  }

  onSubmit(): void {
    if (this.businessCardForm.valid) {
      const formData = this.createFormData();
      this.isLoading = true;
      this.businessCardService.insert(formData).subscribe(
        () => {
          this.snackbarService.showSuccess('Business card added successfully!');
          this.resetForm();
          this.router.navigate(['../']);
        },
        (error) => {
          this.isLoading = false;
          console.error('Error inserting business card:', error);
          this.snackbarService.showError('Failed to add business card.');
        }
      );
    } else {
      console.log('Form is invalid', this.businessCardForm);
    }
  }

  private createFormData(): FormData {
    const formData = new FormData();
    Object.keys(this.businessCardForm.value).forEach((key) => {
      const value = this.businessCardForm.get(key)?.value;
      formData.append(key, key === 'dob' ? value.toISOString() : value);
    });
    return formData;
  }

  private resetForm(): void {
    this.businessCardForm.reset();
    this.imagePreview = undefined;
    this.isLoading = false;
  }
}

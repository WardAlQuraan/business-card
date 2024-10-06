import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BusinessCardRoutingModule } from './business-card-routing.module';
import { SharedModuleModule } from '../shared-module/shared-module.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ImageDialougComponent } from './image-dialoug/image-dialoug.component';
import { DeleteBusinessCardDialogComponent } from './delete-business-card-dialog/delete-business-card-dialog.component';
import { InsertBulkFormComponent } from './insert-bulk-form/insert-bulk-form.component';


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    BusinessCardRoutingModule,
    SharedModuleModule  ,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class BusinessCardModule { }

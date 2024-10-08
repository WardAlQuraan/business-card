import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutsRoutingModule } from './layouts-routing.module';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { SharedComponentsModule } from '../shared-components/shared-components.module';
import { SharedModuleModule } from '../shared-module/shared-module.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BusinessCardFormComponent } from '../business-card/business-card-form/business-card-form.component';
import { ImageDialougComponent } from '../business-card/image-dialoug/image-dialoug.component';
import { DeleteBusinessCardDialogComponent } from '../business-card/delete-business-card-dialog/delete-business-card-dialog.component';
import { InsertBulkFormComponent } from '../business-card/insert-bulk-form/insert-bulk-form.component';
import { BusinessCardFileComponent } from '../business-card/insert-bulk-form/business-card-file/business-card-file.component';



@NgModule({
  declarations: [
    MainLayoutComponent,
    BusinessCardFormComponent,
    ImageDialougComponent,
    DeleteBusinessCardDialogComponent,
    InsertBulkFormComponent,
    BusinessCardFileComponent
  ],
  imports: [
    CommonModule,
    LayoutsRoutingModule,
    SharedComponentsModule,
    SharedModuleModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class LayoutsModule { }

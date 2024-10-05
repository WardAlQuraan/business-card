import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutsRoutingModule } from './layouts-routing.module';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { SharedComponentsModule } from '../shared-components/shared-components.module';
import { SharedModuleModule } from '../shared-module/shared-module.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BusinessCardFormComponent } from '../business-card/business-card-form/business-card-form.component';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { DndModule } from 'ngx-drag-drop'; // Import the DndModule



@NgModule({
  declarations: [
    MainLayoutComponent,
    BusinessCardFormComponent
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

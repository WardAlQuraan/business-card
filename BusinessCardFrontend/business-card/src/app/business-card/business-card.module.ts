import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BusinessCardRoutingModule } from './business-card-routing.module';
import { SharedModuleModule } from '../shared-module/shared-module.module';
import { BusinessCardFormComponent } from './business-card-form/business-card-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    BusinessCardFormComponent,
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

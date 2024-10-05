import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { BusinessCardDetailsComponent } from '../business-card/business-card-details/business-card-details.component';
import { BusinessCardFormComponent } from '../business-card/business-card-form/business-card-form.component';

const routes: Routes = [
  { path: 'business-cards',  component: BusinessCardDetailsComponent },
  { path: 'business-card-form',  component: BusinessCardFormComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutsRoutingModule { }

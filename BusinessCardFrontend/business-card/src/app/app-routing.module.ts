import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from './layouts/main-layout/main-layout.component';

const routes: Routes = [

  {
    path: '',
    redirectTo: 'business-cards',
    pathMatch: 'full',
  }, 
  {
    path: '',
    component: MainLayoutComponent,
    children: [{
      path: '',
      loadChildren: () => import('./layouts/layouts.module').then(m => m.LayoutsModule)
    }]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SalesComponent } from './sales/sales.component';

const routes: Routes = [
  {
    path: 'sales',
    component: SalesComponent
  },
  // Outras rotas aqui
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

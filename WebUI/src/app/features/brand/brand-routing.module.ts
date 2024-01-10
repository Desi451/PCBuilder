import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { BrandFormComponent } from "./brand-form/brand-form.component";
import { BrandListComponent } from "./brand-list/brand-list.component";
import { BrandViewComponent } from "./brand-view/brand-view.component";

const routes: Routes = [
  {
    path: '',
    component: BrandListComponent
  },
  {
    path: 'form',
    component: BrandFormComponent
  },
  {
    path: 'form/:id',
    component: BrandFormComponent
  },
  {
    path: 'view/:id',
    component: BrandViewComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BrandRoutingModule { }

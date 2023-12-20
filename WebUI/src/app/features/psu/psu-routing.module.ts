import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { PsuFormComponent } from "./psu-form/psu-form.component";
import { PsuListComponent } from "./psu-list/psu-list.component";
import { PsuViewComponent } from "./psu-view/psu-view.component";



const routes: Routes = [
  {
    path: '',
    component: PsuListComponent
  },
  {
    path: 'form',
    component: PsuFormComponent
  },
  {
    path: 'form/:id',
    component: PsuFormComponent
  },
  {
    path: 'view/:id',
    component: PsuViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PsuRoutingModule { }

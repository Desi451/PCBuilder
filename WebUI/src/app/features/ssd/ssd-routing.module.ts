import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { SsdFormComponent } from "./ssd-form/ssd-form.component";
import { SsdListComponent } from "./ssd-list/ssd-list.component";
import { SsdViewComponent } from "./ssd-view/ssd-view.component";

const routes: Routes = [
  {
    path: '',
    component: SsdListComponent
  },
  {
    path: 'form',
    component: SsdFormComponent
  },
  {
    path: 'form/:id',
    component: SsdFormComponent
  },
  {
    path: 'view/:id',
    component: SsdViewComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SsdRoutingModule { }

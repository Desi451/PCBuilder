import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { SsdFormComponent } from "./ssd-form/ssd-form.component";
import { SsdListComponent } from "./ssd-list/ssd-list.component";

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
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SsdRoutingModule { }

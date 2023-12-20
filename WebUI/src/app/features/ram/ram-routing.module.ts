import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { RamFormComponent } from "./ram-form/ram-form.component";
import { RamListComponent } from "./ram-list/ram-list.component";
import { RamViewComponent } from "./ram-view/ram-view.component";


const routes: Routes = [
  {
    path: '',
    component: RamListComponent
  },
  {
    path: 'form',
    component: RamFormComponent
  },
  {
    path: 'form/:id',
    component: RamFormComponent
  },
  {
    path: 'view/:id',
    component: RamViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RamRoutingModule { }

import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { ComputerFormComponent } from "./computer-form/computer-form.component";
import { ComputerListComponent } from "./computer-list/computer-list.component";
import { ComputerViewComponent } from "./computer-view/computer-view.component";


const routes: Routes = [
  {
      path: 'computer',
      component: ComputerListComponent
  },
  {
    path: 'computer/form',
    component: ComputerFormComponent
  },
  {
    path: 'computer/form/:id',
    component: ComputerFormComponent
  },
  {
    path: 'computer/view/:id',
    component: ComputerViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComputerRoutingModule { }

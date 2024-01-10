import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { GpuFormComponent } from "./gpu-form/gpu-form.component";
import { GpuListComponent } from "./gpu-list/gpu-list.component";
import { GpuViewComponent } from "./gpu-view/gpu-view.component";


const routes: Routes = [
  {
    path: '',
    component: GpuListComponent
  },
  {
    path: 'form',
    component: GpuFormComponent
  },
  {
    path: 'form/:id',
    component: GpuFormComponent
  },
  {
    path: 'view/:id',
    component: GpuViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GpuRoutingModule { }

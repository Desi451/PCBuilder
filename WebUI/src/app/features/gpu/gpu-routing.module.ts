import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { adminGuard } from "src/app/core/auth/auth.guards";

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
    canActivate: [adminGuard],
    component: GpuFormComponent
  },
  {
    path: 'form/:id',
    canActivate: [adminGuard],
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

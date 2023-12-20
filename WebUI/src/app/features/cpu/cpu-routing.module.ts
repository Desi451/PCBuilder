import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { CpuFormComponent } from "./cpu-form/cpu-form.component";
import { CpuListComponent } from "./cpu-list/cpu-list.component";
import { CpuViewComponent } from "./cpu-view/cpu-view.component";


const routes: Routes = [
  {
    path: '',
    component: CpuListComponent
  },
  {
    path: 'form',
    component: CpuFormComponent
  },
  {
    path: 'form/:id',
    component: CpuFormComponent
  },
  {
    path: 'view/:id',
    component: CpuViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CpuRoutingModule { }

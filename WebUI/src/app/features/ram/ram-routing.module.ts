import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { adminGuard } from "src/app/core/auth/auth.guards";

import { RamFormComponent } from "./ram-form/ram-form.component";
import { RamListComponent } from "./ram-list/ram-list.component";
import { RamSpeedFormComponent } from "./ram-speed-form/ram-speed-form.component";
import { RamViewComponent } from "./ram-view/ram-view.component";


const routes: Routes = [
  {
    path: '',
    component: RamListComponent
  },
  {
    path: 'form',
    canActivate: [adminGuard],
    component: RamFormComponent
  },
  {
    path: 'form/:id',
    canActivate: [adminGuard],
    component: RamFormComponent
  },
  {
    path: 'view/:id',
    component: RamViewComponent
  },
  {
    path: 'speedform',
    canActivate: [adminGuard],
    component: RamSpeedFormComponent
  },
  {
    path: 'speedform/:id',
    canActivate: [adminGuard],
    component: RamSpeedFormComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RamRoutingModule { }

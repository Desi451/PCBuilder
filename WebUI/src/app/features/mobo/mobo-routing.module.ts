import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { adminGuard } from "src/app/core/auth/auth.guards";

import { MoboFormComponent } from "./mobo-form/mobo-form.component";
import { MoboListComponent } from "./mobo-list/mobo-list.component";
import { MoboViewComponent } from "./mobo-view/mobo-view.component";


const routes: Routes = [
  {
    path: '',
    component: MoboListComponent
  },
  {
    path: 'form',
    canActivate: [adminGuard],
    component: MoboFormComponent
  },
  {
    path: 'form/:id',
    canActivate: [adminGuard],
    component: MoboFormComponent
  },
  {
    path: 'view/:id',
    component: MoboViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MoboRoutingModule { }

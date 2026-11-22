import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { adminGuard } from "src/app/core/auth/auth.guards";

import { CpuFormComponent } from "./cpu-form/cpu-form.component";
import { CpuListComponent } from "./cpu-list/cpu-list.component";
import { CpuViewComponent } from "./cpu-view/cpu-view.component";
import { SocketFormComponent } from "./socket-form/socket-form.component";


const routes: Routes = [
  {
    path: '',
    component: CpuListComponent
  },
  {
    path: 'form',
    canActivate: [adminGuard],
    component: CpuFormComponent
  },
  {
    path: 'form/:id',
    canActivate: [adminGuard],
    component: CpuFormComponent
  },
  {
    path: 'view/:id',
    component: CpuViewComponent
  },
  {
    path: 'formsocket',
    canActivate: [adminGuard],
    component: SocketFormComponent
  },
  {
    path: 'formsocket/:id',
    canActivate: [adminGuard],
    component: SocketFormComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CpuRoutingModule { }

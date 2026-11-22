import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { adminGuard } from "src/app/core/auth/auth.guards";

import { DriveFromComponent } from "./drive-form/drive-form.component";
import { DriveListComponent } from "./drive-list/drive-list.component";
import { DriveViewComponent } from "./drive-view/drive-view.component";


const routes: Routes = [
  {
    path: '',
    component: DriveListComponent
  },
  {
    path: 'form',
    canActivate: [adminGuard],
    component: DriveFromComponent
  },
  {
    path: 'form/:id',
    canActivate: [adminGuard],
    component: DriveFromComponent
  },
  {
    path: 'view/:id',
    component: DriveViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DriveRoutingModule { }

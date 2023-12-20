import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

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
    component: DriveFromComponent
  },
  {
    path: 'form/:id',
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

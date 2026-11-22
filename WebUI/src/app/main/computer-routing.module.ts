import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { authGuard } from "src/app/core/auth/auth.guards";

import { ComputerFormComponent } from "./computer-form/computer-form.component";
import { ComputerListComponent } from "./computer-list/computer-list.component";
import { ComputerViewComponent } from "./computer-view/computer-view.component";


const routes: Routes = [
  {
    path: 'computer',
    canActivate: [authGuard],
    children: [
      {
        path: '',
        component: ComputerListComponent
      },
      {
        path: 'form',
        component: ComputerFormComponent
      },
      {
        path: 'form/:id',
        component: ComputerFormComponent
      },
      {
        path: 'view/:id',
        component: ComputerViewComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComputerRoutingModule { }

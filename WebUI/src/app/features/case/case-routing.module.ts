import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { CaseFormComponent } from "./case-form/case-form.component";
import { CaseListComponent } from "./case-list/case-list.component";
import { CaseViewComponent } from "./case-view/case-view.component";


const routes: Routes = [
  {
    path: '',
    component: CaseListComponent
  },
  {
    path: 'form',
    component: CaseFormComponent
  },
  {
    path: 'form/:id',
    component: CaseFormComponent
  },
  {
    path: 'view/:id',
    component: CaseViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CaseRoutingModule { }

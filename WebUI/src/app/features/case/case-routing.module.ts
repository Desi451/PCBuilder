import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { CaseFormComponent } from "./case-form/case-form.component";
import { CaseListComponent } from "./case-list/case-list.component";


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
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CaseRoutingModule { }

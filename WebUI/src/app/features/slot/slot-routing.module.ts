import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { SlotFormComponent } from "./slot-form/slot-form.component";
import { SlotListComponent } from "./slot-list/slot-list.component";


const routes: Routes = [
  {
    path: '',
    component: SlotListComponent
  },
  {
    path: 'form',
    component: SlotFormComponent
  },
  {
    path: 'form/:id',
    component: SlotFormComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SlotRoutingModule { }

import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbDropdownModule } from "@ng-bootstrap/ng-bootstrap";
import { SharedModule } from "src/app/shared/shared.module";

import { SlotFormComponent } from "./slot-form/slot-form.component";
import { SlotListComponent } from "./slot-list/slot-list.component";
import { SlotRoutingModule } from "./slot-routing.module";


@NgModule({
  declarations: [
    SlotFormComponent,
    SlotListComponent
  ],
  imports: [
    CommonModule,
    SlotRoutingModule,
    SharedModule,
    FormsModule,
    NgbDropdownModule,
    ReactiveFormsModule
  ]
})
export class SlotModule { }

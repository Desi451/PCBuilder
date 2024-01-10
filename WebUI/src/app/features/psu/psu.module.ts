import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbDropdownModule } from "@ng-bootstrap/ng-bootstrap";
import { SharedModule } from "src/app/shared/shared.module";

import { PsuFormComponent } from "./psu-form/psu-form.component";
import { PsuListComponent } from "./psu-list/psu-list.component";
import { PsuRoutingModule } from "./psu-routing.module";
import { PsuViewComponent } from "./psu-view/psu-view.component";


@NgModule({
  declarations: [
    PsuFormComponent,
    PsuListComponent,
    PsuViewComponent
  ],
  imports: [
    CommonModule,
    PsuRoutingModule,
    SharedModule,
    FormsModule,
    NgbDropdownModule,
    ReactiveFormsModule
  ]
})
export class PsuModule { }

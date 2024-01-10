import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbDropdownModule } from "@ng-bootstrap/ng-bootstrap";
import { SharedModule } from "src/app/shared/shared.module";

import { SsdFormComponent } from "./ssd-form/ssd-form.component";
import { SsdListComponent } from "./ssd-list/ssd-list.component";
import { SsdRoutingModule } from "./ssd-routing.module";
import { SsdViewComponent } from "./ssd-view/ssd-view.component";


@NgModule({
  declarations: [
  SsdListComponent,
  SsdFormComponent,
  SsdViewComponent
  ],
  imports: [
    CommonModule,
    SsdRoutingModule,
    SharedModule,
    FormsModule,
    NgbDropdownModule,
    ReactiveFormsModule
  ]
})
export class SsdModule { }

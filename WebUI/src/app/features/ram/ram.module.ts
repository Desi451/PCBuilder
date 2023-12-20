import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbDropdownModule } from "@ng-bootstrap/ng-bootstrap";
import { SharedModule } from "src/app/shared/shared.module";

import { RamFormComponent } from "./ram-form/ram-form.component";
import { RamListComponent } from "./ram-list/ram-list.component";
import { RamRoutingModule } from "./ram-routing.module";
import { RamViewComponent } from "./ram-view/ram-view.component";


@NgModule({
  declarations: [
    RamListComponent,
    RamFormComponent,
    RamViewComponent
  ],
  imports: [
    CommonModule,
    RamRoutingModule,
    SharedModule,
    FormsModule,
    NgbDropdownModule,
    ReactiveFormsModule
  ]
})
export class RamModule { }

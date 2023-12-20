import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbDropdownModule } from "@ng-bootstrap/ng-bootstrap";
import { SharedModule } from "src/app/shared/shared.module";

import { MoboFormComponent } from "./mobo-form/mobo-form.component";
import { MoboListComponent } from "./mobo-list/mobo-list.component";
import { MoboRoutingModule } from "./mobo-routing.module";
import { MoboViewComponent } from "./mobo-view/mobo-view.component";


@NgModule({
  declarations: [
    MoboListComponent,
    MoboFormComponent,
    MoboViewComponent
  ],
  imports: [
    CommonModule,
    MoboRoutingModule,
    SharedModule,
    FormsModule,
    NgbDropdownModule,
    ReactiveFormsModule
  ]
})
export class MoboModule { }

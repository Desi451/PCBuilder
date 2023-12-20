import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbDropdownModule } from "@ng-bootstrap/ng-bootstrap";
import { SharedModule } from "src/app/shared/shared.module";

import { DriveFromComponent } from "./drive-form/drive-form.component";
import { DriveListComponent } from "./drive-list/drive-list.component";
import { DriveRoutingModule } from "./drive-routing.module";
import { DriveViewComponent } from "./drive-view/drive-view.component";


@NgModule({
  declarations: [
    DriveFromComponent,
    DriveListComponent,
    DriveViewComponent
  ],
  imports: [
    CommonModule,
    DriveRoutingModule,
    SharedModule,
    FormsModule,
    NgbDropdownModule,
    ReactiveFormsModule
  ]
})
export class DriveModule { }

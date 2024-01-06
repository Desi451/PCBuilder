import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbCollapseModule, NgbDropdownModule } from "@ng-bootstrap/ng-bootstrap";

import { SharedModule } from "../shared/shared.module";
import { ComputerFormComponent } from "./computer-form/computer-form.component";
import { ComputerListComponent } from "./computer-list/computer-list.component";
import { ComputerRoutingModule } from "./computer-routing.module";
import { ComputerViewComponent } from "./computer-view/computer-view.component";


@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ComputerRoutingModule,
    NgbCollapseModule,
    NgbDropdownModule,
    ReactiveFormsModule,
    FormsModule
  ],
  declarations: [
    ComputerListComponent,
    ComputerViewComponent,
    ComputerFormComponent
  ]
})
export class ComputerModule { }

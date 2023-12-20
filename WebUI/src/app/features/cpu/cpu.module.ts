import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbDropdownModule } from "@ng-bootstrap/ng-bootstrap";
import { SharedModule } from "src/app/shared/shared.module";

import { CpuFormComponent } from "./cpu-form/cpu-form.component";
import { CpuListComponent } from "./cpu-list/cpu-list.component";
import { CpuRoutingModule } from "./cpu-routing.module";
import { CpuViewComponent } from "./cpu-view/cpu-view.component";


@NgModule({
  declarations: [
    CpuFormComponent,
    CpuListComponent,
    CpuViewComponent
  ],
  imports: [
    CommonModule,
    CpuRoutingModule,
    SharedModule,
    FormsModule,
    NgbDropdownModule,
    ReactiveFormsModule
  ]
})
export class CpuModule { }

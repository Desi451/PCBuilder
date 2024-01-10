import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbDropdownModule } from "@ng-bootstrap/ng-bootstrap";
import { SharedModule } from "src/app/shared/shared.module";

import { GpuFormComponent } from "./gpu-form/gpu-form.component";
import { GpuListComponent } from "./gpu-list/gpu-list.component";
import { GpuRoutingModule } from "./gpu-routing.module";
import { GpuViewComponent } from "./gpu-view/gpu-view.component";



@NgModule({
  declarations: [
    GpuFormComponent,
    GpuListComponent,
    GpuViewComponent
  ],
  imports: [
    CommonModule,
    GpuRoutingModule,
    SharedModule,
    FormsModule,
    NgbDropdownModule,
    ReactiveFormsModule
  ]
})
export class GpuModule { }

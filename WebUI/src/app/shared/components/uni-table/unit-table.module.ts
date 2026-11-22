import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbPaginationModule } from "@ng-bootstrap/ng-bootstrap";

import { UniTableComponent } from "./uni-table.component";

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbPaginationModule
  ],
  declarations: [
    UniTableComponent
  ],
  exports: [
    UniTableComponent
  ]
})
export class UniTableModule { }

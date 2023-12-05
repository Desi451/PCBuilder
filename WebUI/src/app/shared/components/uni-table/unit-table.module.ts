import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";

import { UniTableComponent } from "./uni-table.component";

@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [
    UniTableComponent
  ],
  exports: [
    UniTableComponent
  ]
})
export class UniTableModule { }

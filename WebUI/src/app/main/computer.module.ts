import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";

import { SharedModule } from "../shared/shared.module";
import { ComputerRoutingModule } from "./computer-routing.module";


@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ComputerRoutingModule
  ],
  declarations: [

  ]
})
export class ComputerModule { }

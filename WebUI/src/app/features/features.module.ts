import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";

import { SharedModule } from "../shared/shared.module";
import { BrandModule } from "./brand/brand.module";
import { CaseModule } from "./case/case.module";
import { FeaturesRoutingModule } from "./features-routing.module";
import { SeriesModule } from "./series/series.module";


@NgModule({
  imports: [
    CommonModule,
    FeaturesRoutingModule,
    SharedModule,
    CaseModule,
    BrandModule,
    SeriesModule
  ],
  declarations: [

  ]
})
export class FeaturesModule { }

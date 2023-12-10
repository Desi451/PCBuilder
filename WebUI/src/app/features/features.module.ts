import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";

import { SharedModule } from "../shared/shared.module";
import { BrandModule } from "./brand/brand.module";
import { FeaturesRoutingModule } from "./features-routing.module";
import { SeriesModule } from "./series/series.module";


@NgModule({
    imports: [
        CommonModule,
        FeaturesRoutingModule,
        SharedModule,

        BrandModule,
        SeriesModule
    ]
})
export class FeaturesModule { }

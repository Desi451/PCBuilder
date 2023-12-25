import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";

import { SharedModule } from "../shared/shared.module";
import { BrandModule } from "./brand/brand.module";
import { CaseModule } from "./case/case.module";
import { CpuModule } from "./cpu/cpu.module";
import { DriveModule } from "./drive/drive.module";
import { FeaturesRoutingModule } from "./features-routing.module";
import { GpuModule } from "./gpu/gpu.module";
import { MoboModule } from "./mobo/mobo.module";
import { PsuModule } from "./psu/psu.module";
import { RamModule } from "./ram/ram.module";
import { SeriesModule } from "./series/series.module";
import { SlotModule } from "./slot/slot.module";
import { SsdModule } from "./ssd/ssd.module";


@NgModule({
  imports: [
    CommonModule,
    FeaturesRoutingModule,
    SharedModule,
    CaseModule,
    BrandModule,
    SeriesModule,
    CpuModule,
    DriveModule,
    GpuModule,
    SlotModule,
    MoboModule,
    PsuModule,
    RamModule,
    SsdModule
  ],
  declarations: [

  ]
})
export class FeaturesModule { }

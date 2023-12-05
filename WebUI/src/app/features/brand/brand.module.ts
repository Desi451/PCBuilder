import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { SharedModule } from "src/app/shared/shared.module";

import { BrandFormComponent } from "./brand-form/brand-form.component";
import { BrandListComponent } from "./brand-list/brand-list.component";
import { BrandRoutingModule } from "./brand-routing.module";

@NgModule({
    declarations: [
      BrandListComponent,
      BrandFormComponent
    ],
    imports: [
        CommonModule,
        BrandRoutingModule,
        SharedModule
    ]
})
export class BrandModule { }

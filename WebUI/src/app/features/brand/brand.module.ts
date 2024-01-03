import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { SharedModule } from "src/app/shared/shared.module";

import { BrandFormComponent } from "./brand-form/brand-form.component";
import { BrandListComponent } from "./brand-list/brand-list.component";
import { BrandRoutingModule } from "./brand-routing.module";
import { BrandViewComponent } from "./brand-view/brand-view.component";

@NgModule({
    declarations: [
      BrandListComponent,
      BrandFormComponent,
      BrandViewComponent
    ],
    imports: [
        CommonModule,
        BrandRoutingModule,
        SharedModule,
        FormsModule,
        
    ]
})
export class BrandModule { }

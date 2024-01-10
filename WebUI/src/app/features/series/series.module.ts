import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";

import { SeriesListComponent } from "./seires-list/series-list.component";
import { SeriesFormComponent } from "./series-form/series-form.component";
import { SeriesRoutingModule } from "./series-routing.module";

@NgModule({
    declarations: [
      SeriesListComponent,
      SeriesFormComponent
    ],
    imports: [
        CommonModule,
        SeriesRoutingModule,
        FormsModule
    ]
})
export class SeriesModule { }

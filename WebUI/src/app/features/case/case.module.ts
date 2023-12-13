import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { SharedModule } from "src/app/shared/shared.module";

import { CaseFormComponent } from "./case-form/case-form.component";
import { CaseListComponent } from "./case-list/case-list.component";
import { CaseRoutingModule } from "./case-routing.module";

@NgModule({
  declarations: [
    CaseListComponent,
    CaseFormComponent
  ],
  imports: [
    CommonModule,
    CaseRoutingModule,
    SharedModule,
    FormsModule
  ]
})
export class CaseModule { }

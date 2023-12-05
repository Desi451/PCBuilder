import { NgModule } from "@angular/core";

import { UniTableModule } from "./components/uni-table/unit-table.module";

const modules = [
  UniTableModule
];

@NgModule({
  imports: modules,
  exports: modules
})
export class SharedModule { }

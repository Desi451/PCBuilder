import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { SeriesListComponent } from "./seires-list/series-list.component";
import { SeriesFormComponent } from "./series-form/series-form.component";

const routes: Routes = [
    {
        path: '',
        component: SeriesListComponent
    },
    {
      path: 'form',
      component: SeriesFormComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class SeriesRoutingModule { }

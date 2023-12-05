import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

const routes: Routes = [
    {
        path: '',
        children: [
            {
                path: 'brand',
                loadChildren: () => import('./brand/brand.module').then(m => m.BrandModule)
            },
            {
                path: 'seires',
                loadChildren: () => import('./series/series.module').then(m => m.SeriesModule)
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FeaturesRoutingModule { }

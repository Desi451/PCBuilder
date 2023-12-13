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
        path: 'series',
        loadChildren: () => import('./series/series.module').then(m => m.SeriesModule)
      },
      {
        path: 'case',
        loadChildren: () => import('./case/case.module').then(m => m.CaseModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeaturesRoutingModule { }

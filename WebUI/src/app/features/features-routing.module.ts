import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { adminGuard, authGuard } from "src/app/core/auth/auth.guards";

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'brand',
        canMatch: [adminGuard],
        loadChildren: () => import('./brand/brand.module').then(m => m.BrandModule)
      },
      {
        path: 'series',
        canMatch: [adminGuard],
        loadChildren: () => import('./series/series.module').then(m => m.SeriesModule)
      },
      {
        path: 'case',
        canMatch: [authGuard],
        loadChildren: () => import('./case/case.module').then(m => m.CaseModule)
      },
      {
        path: 'cpu',
        canMatch: [authGuard],
        loadChildren: () => import('./cpu/cpu.module').then(m => m.CpuModule)
      },
      {
        path: 'drive',
        canMatch: [authGuard],
        loadChildren: () => import('./drive/drive.module').then(m => m.DriveModule)
      },
      {
        path: 'ssd',
        canMatch: [authGuard],
        loadChildren: () => import('./ssd/ssd.module').then(m => m.SsdModule)
      },
      {
        path: 'gpu',
        canMatch: [authGuard],
        loadChildren: () => import('./gpu/gpu.module').then(m => m.GpuModule)
      },
      {
        path: 'slot',
        canMatch: [adminGuard],
        loadChildren: () => import('./slot/slot.module').then(m => m.SlotModule)
      },
      {
        path: 'mobo',
        canMatch: [authGuard],
        loadChildren: () => import('./mobo/mobo.module').then(m => m.MoboModule)
      },
      {
        path: 'psu',
        canMatch: [authGuard],
        loadChildren: () => import('./psu/psu.module').then(m => m.PsuModule)
      },
      {
        path: 'ram',
        canMatch: [authGuard],
        loadChildren: () => import('./ram/ram.module').then(m => m.RamModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeaturesRoutingModule { }

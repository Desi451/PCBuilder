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
      },
      {
        path: 'cpu',
        loadChildren: () => import('./cpu/cpu.module').then(m => m.CpuModule)
      },
      {
        path: 'drive',
        loadChildren: () => import('./drive/drive.module').then(m => m.DriveModule)
      },
      {
        path: 'ssd',
        loadChildren: () => import('./ssd/ssd.module').then(m => m.SsdModule)
      },
      {
        path: 'gpu',
        loadChildren: () => import('./gpu/gpu.module').then(m => m.GpuModule)
      },
      {
        path: 'slot',
        loadChildren: () => import('./slot/slot.module').then(m => m.SlotModule)
      },
      {
        path: 'mobo',
        loadChildren: () => import('./mobo/mobo.module').then(m => m.MoboModule)
      },
      {
        path: 'psu',
        loadChildren: () => import('./psu/psu.module').then(m => m.PsuModule)
      },
      {
        path: 'ram',
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

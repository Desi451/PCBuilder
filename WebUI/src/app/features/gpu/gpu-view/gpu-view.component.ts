import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { BrandService } from "src/app/core/service/brand.service";
import { GpuService } from "src/app/core/service/gpu.service";
import { SeriesService } from "src/app/core/service/series.service";
import { brand } from "src/app/shared/models/brand.model";
import { gpu } from "src/app/shared/models/gpu.model";
import { series } from "src/app/shared/models/series.model";

@Component({
  selector: 'app-gpu-view',
  templateUrl: './gpu-view.component.html',
  styleUrls: ['./gpu-view.component.scss']
})
export class GpuViewComponent implements OnInit {
  id: number;
  res: gpu = new gpu();
  brnd: brand = new brand();
  chipsetBrnd: brand = new brand();
  srs: series = new series();
  chipsetSrs: series = new series();

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _brandService: BrandService,
    private toastr: ToastrService,
    private _seriesService: SeriesService,
    private _gpuService: GpuService,
  ) {
    this.id = this._route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this._gpuService.getGpu(this.id).subscribe(
      (res: gpu) => {
        this.res = res;
        this.res.id = res.id;
        this._seriesService.getSeriesById(res.seriesId).subscribe(
          (resSeries: series) => {
            this.srs = res;

            if (resSeries.brandId) {
              this._brandService.getBrand(resSeries.brandId).subscribe(
                (resBrand: brand) => {
                  this.brnd = resBrand;
                }
              )
            }
          }
        );

        this._seriesService.getSeriesById(res.chipsetSeriesId).subscribe(
          (resSeries: series) => {
            this.chipsetSrs = res;

            if (resSeries.brandId) {
              this._brandService.getBrand(resSeries.brandId).subscribe(
                (resBrand: brand) => {
                  this.chipsetBrnd = resBrand;
                }
              )
            }
          }
        );
      },
      (error) => {
        this.toastr.error('Error fetching GPU', 'Server Error');
      }
    );
  }

}

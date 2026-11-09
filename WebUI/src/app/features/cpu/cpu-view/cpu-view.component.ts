import { Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { BrandService } from "src/app/core/service/brand.service";
import { CpuService } from "src/app/core/service/cpu.service";
import { SeriesService } from "src/app/core/service/series.service";
import { brand } from "src/app/shared/models/brand.model";
import { cpu, socketCpu } from "src/app/shared/models/cpu.model";
import { series } from "src/app/shared/models/series.model";

@Component({
  selector: 'app-cpu-view',
  templateUrl: './cpu-view.component.html',
  styleUrls: ['./cpu-view.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class CpuViewComponent implements OnInit {

  id: number;
  res: cpu = new cpu();
  brnd: brand = new brand();
  srs: series = new series();
  socket: socketCpu = new socketCpu();

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _brandService: BrandService,
    private _seriesService: SeriesService,
    private _cpuService: CpuService,
    private toastr: ToastrService
  ) {
    this.id = this._route.snapshot.params['id'];
  }

    ngOnInit(): void {
            this._cpuService.getCpu(this.id).subscribe(
        (res: cpu) => {
          this.res = res;
          this.res.id = res.id;
          this._seriesService.getSeriesById(res.seriesId).subscribe(
            (resSeries: series) => {
              this.srs = resSeries;

              if (resSeries.brandId) {
                this._brandService.getBrand(resSeries.brandId).subscribe(
                  (resBrand: brand) => {
                    this.brnd = resBrand;
                  }
                )
              }

              if(res.socketCpuId){
                this._cpuService.getCpuSocket(res.socketCpuId).subscribe(
                  (resSocket: socketCpu) => {
                    this.socket = resSocket;
                  }
                )
              }

            }
          );
        },
        (error) => {
          this.toastr.error('Error fetching CPU', 'Server Error');
        }
      );
    }

}

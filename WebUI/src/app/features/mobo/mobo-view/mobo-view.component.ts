import { Component, OnInit } from "@angular/core";
import { FormBuilder } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { BrandService } from "src/app/core/service/brand.service";
import { CpuService } from "src/app/core/service/cpu.service";
import { MoboService } from "src/app/core/service/mobo.service";
import { RamService } from "src/app/core/service/ram.service";
import { SeriesService } from "src/app/core/service/series.service";
import { brand } from "src/app/shared/models/brand.model";
import { CaseSize, CaseSizes } from "src/app/shared/models/case.model";
import { socketCpu } from "src/app/shared/models/cpu.model";
import { mobo } from "src/app/shared/models/mobo.model";
import { ramSpeed } from "src/app/shared/models/ram.model";
import { series } from "src/app/shared/models/series.model";

@Component({
  selector: 'app-mobo-view',
  templateUrl: './mobo-view.component.html',
  styleUrls: ['./mobo-view.component.scss']
})
export class MoboViewComponent implements OnInit {
  id: number;
  res: mobo = new mobo();
  brnd: brand = new brand();
  socketBrnd: brand = new brand();
  srs: series = new series();
  socket: socketCpu = new socketCpu();
  brandList: brand[] = [];
  socketBrandList: brand[] = [];
  seriesList: series[] = [];
  socketList: socketCpu[] = [];
  caseSizesList: CaseSize[] = [];
  caseSizeData: CaseSize = {
    name: '',
    value: -1
  };
  enableSeries = true;
  ramMemoryList: ramSpeed[] = [];
  ramMemoryListUserData: ramSpeed[] = [];

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _brandService: BrandService,
    private _seriesService: SeriesService,
    private formBuilder: FormBuilder,
    private _cpuService: CpuService,
    private _moboService: MoboService,
    private toastr: ToastrService,
    private _ramService: RamService
  ) {
    this.id = this._route.snapshot.params['id'];
    for (const key in CaseSizes) {
      if (!isNaN(Number(CaseSizes[key]))) {
        this.caseSizesList.push({ name: key, value: CaseSizes[key] as unknown as number });
      }
    }
  }

  ngOnInit(): void {
    this._moboService.getMobo(this.id).subscribe(
      (res: mobo) => {
        this.res.id = res.id;
        this.res = res;
        this.ramMemoryListUserData = res.memories;

        this.caseSizeData.name = getCaseSizeName(this.res.caseSizeId);
        this.caseSizeData.value = this.res.caseSizeId;

        this._seriesService.getSeriesById(res.seriesId).subscribe(
          (resSeries: series) => {
            this.srs = res;

            if (resSeries.brandId) {
              this._brandService.getBrand(resSeries.brandId).subscribe(
                (resBrand: brand) => {
                  this.brnd = resBrand;
                });
            }
          }
        );

        this._cpuService.getCpuSocket(res.socketCpuId).subscribe(
          (sockt: socketCpu) => {
            this.socket = sockt;

            if (sockt.brandId) {
              this._brandService.getBrand(sockt.brandId).subscribe(
                (resBrand: brand) => {
                  this.socketBrnd = resBrand;
                });
            }
          }
        );
      },
      (error) => {
        this.toastr.error('Error fetching sockets', 'Server Error');
      }
    );
      this.ramMemoryListUserData = this.res.memories;
  }
}

function getCaseSizeName(enumValue: number): string {
  const keys = Object.keys(CaseSizes).filter((x) => CaseSizes[x as keyof typeof CaseSizes] === enumValue);
  return keys[0];
}

import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { BrandService } from "src/app/core/service/brand.service";
import { SeriesService } from "src/app/core/service/series.service";
import { SlotService } from "src/app/core/service/slot.service";
import { SsdService } from "src/app/core/service/ssd.service";
import { brand } from "src/app/shared/models/brand.model";
import { series } from "src/app/shared/models/series.model";
import { slot } from "src/app/shared/models/slot.model";
import { ssd } from "src/app/shared/models/ssd.model";

@Component({
  selector: 'app-ssd-view',
  templateUrl: './ssd-view.component.html',
  styleUrls: ['./ssd-view.component.scss']
})
export class SsdViewComponent implements OnInit {
  id: number;
  res: ssd = new ssd();
  brnd: brand = new brand();
  srs: series = new series();
  slot: slot = new slot();

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _brandService: BrandService,
    private _seriesService: SeriesService,
    private _slotService: SlotService,
    private _ssdService: SsdService,
    private toastr: ToastrService
  ) {
    this.id = this._route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this._ssdService.getSsd(this.id).subscribe(
      (res: ssd) => {
        this.res.id = res.id;
        this.res = res;

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

            if (res.slotInterfaceId) {
              this._slotService.getSlot(res.slotInterfaceId).subscribe(
                (resSlot: slot) => {
                  this.slot = resSlot;
                }
              )
            }

          }
        );
      },
      (error) => {
        this.toastr.error('Error fetching SSD', 'Server Error');
      }
    );
  }

}

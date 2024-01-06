import { Component, OnInit } from "@angular/core";
import { FormBuilder } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { BrandService } from "src/app/core/service/brand.service";
import { HddService } from "src/app/core/service/hdd.service";
import { SeriesService } from "src/app/core/service/series.service";
import { SlotService } from "src/app/core/service/slot.service";
import { brand } from "src/app/shared/models/brand.model";
import { hdd } from "src/app/shared/models/hdd.model";
import { series } from "src/app/shared/models/series.model";
import { slot } from "src/app/shared/models/slot.model";

@Component({
  selector: 'app-drive-view',
  templateUrl: './drive-view.component.html',
  styleUrls: ['./drive-view.component.scss']
})
export class DriveViewComponent implements OnInit {
  id: number;
  res: hdd = new hdd();
  brnd: brand = new brand();
  srs: series = new series();
  slot: slot = new slot();

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _brandService: BrandService,
    private toastr: ToastrService,
    private _seriesService: SeriesService,
    private _hddService: HddService,
    private _slotService: SlotService,
    private formBuilder: FormBuilder
  ) {
    this.id = this._route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this._hddService.getHdd(this.id).subscribe(
      (res: hdd) => {
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
        this.toastr.error('Error fetching drive', 'Server Error');
      }
    );
  }


}

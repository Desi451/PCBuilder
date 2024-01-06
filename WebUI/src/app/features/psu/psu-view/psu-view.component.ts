import { Component, OnInit } from "@angular/core";
import { FormBuilder } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { BrandService } from "src/app/core/service/brand.service";
import { PsuService } from "src/app/core/service/psu.service";
import { SeriesService } from "src/app/core/service/series.service";
import { SlotService } from "src/app/core/service/slot.service";
import { brand } from "src/app/shared/models/brand.model";
import { psu } from "src/app/shared/models/psu.model";
import { series } from "src/app/shared/models/series.model";

@Component({
  selector: 'app-psu-view',
  templateUrl: './psu-view.component.html',
  styleUrls: ['./psu-view.component.scss']
})
export class PsuViewComponent implements OnInit {
  id: number;
  res: psu = new psu();
  brnd: brand = new brand();
  srs: series = new series();
  brandList: brand[] = [];
  seriesList: series[] = [];
  enableSeries = true;
  pfc: boolean;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _brandService: BrandService,
    private _seriesService: SeriesService,
    private _psuService: PsuService,
    private formBuilder: FormBuilder,
    private _slotService: SlotService,
    private toastr: ToastrService
  ) {
    this.id = this._route.snapshot.params['id'];
  }
  ngOnInit(): void {
    this._psuService.getPsu(this.id).subscribe(
      (res: psu) => {
        this.res.id = res.id;
        this.res = res;
        console.log(res);
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
      },
      (error) => {
        this.toastr.error('Error fetching psu', 'Server Error');
      }
    );
  }
}

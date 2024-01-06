import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { BrandService } from "src/app/core/service/brand.service";
import { RamService } from "src/app/core/service/ram.service";
import { SeriesService } from "src/app/core/service/series.service";
import { brand } from "src/app/shared/models/brand.model";
import { ram, ramSpeed } from "src/app/shared/models/ram.model";
import { series } from "src/app/shared/models/series.model";

@Component({
  selector: 'app-ram-view',
  templateUrl: './ram-view.component.html',
  styleUrls: ['./ram-view.component.scss']
})
export class RamViewComponent implements OnInit {

  id: number;
  res: ram = new ram();
  brnd: brand = new brand();
  srs: series = new series();
  speed: ramSpeed = new ramSpeed();

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _brandService: BrandService,
    private _seriesService: SeriesService,
    private _ramService: RamService,
    private toastr: ToastrService
  ) {
    this.id = this._route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this._ramService.getRam(this.id).subscribe(
      (res: ram) => {
        this.res = res;
        this.res.id = res.id;

        if(res.memorySpeedId){
          this._ramService.getSpeed(res.memorySpeedId).subscribe(
            (spd: ramSpeed) => {
              this.speed = spd;
            }
          );
        }
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
        this.toastr.error('Error fetching RAM', 'Server Error');
      }
    );
  }
}

import { Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { BrandService } from "src/app/core/service/brand.service";
import { CaseService } from "src/app/core/service/case.service";
import { SeriesService } from "src/app/core/service/series.service";
import { brand } from "src/app/shared/models/brand.model";
import { casePc, CaseSize, CaseSizes } from "src/app/shared/models/case.model";
import { series } from "src/app/shared/models/series.model";

@Component({
  selector: 'app-case-view',
  templateUrl: './case-view.component.html',
  styleUrls: ['./case-view.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class CaseViewComponent implements OnInit {

  id: number;
  res: casePc = {
    id: 0,
    name: "",
    model: "",
    height: 0,
    width: 0,
    deepth: 0,
    description: "",
    caseSizeId: 0,
    caseSize: "",
    seriesId: 0
  };
  brnd: brand = new brand();
  srs: series = new series();
  caseSizeData: CaseSize = {
    name: '',
    value: -1
  };

  brandList: brand[] = [];
  seriesList: series[] = [];
  caseSizesList: CaseSize[] = [];
  enableSeries = true;

  constructor(
    private _route: ActivatedRoute,
    public _caseService: CaseService,
    public _brandService: BrandService,
    private _seriesService: SeriesService,
    private toastr: ToastrService
  ) {
    this.id = this._route.snapshot.params['id'];
    for (const key in CaseSizes) {
      if (!isNaN(Number(CaseSizes[key]))) {
        this.caseSizesList.push({ name: key, value: CaseSizes[key] as unknown as number });
      }
    }
  }

  ngOnInit(): void {
    this._caseService.getCase(this.id).subscribe(
      (res: casePc) => {
        this.res.id = res.id;
        this.res = res;

        this.caseSizeData.name = getCaseSizeName(this.res.caseSizeId);
        this.caseSizeData.value = this.res.caseSizeId;;

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
        this.toastr.error('Error fetching data', 'Server Error');
      }
    );
  }

}

function getCaseSizeName(enumValue: number): string {
  const keys = Object.keys(CaseSizes).filter((x) => CaseSizes[x as keyof typeof CaseSizes] === enumValue);
  return keys[0];
}

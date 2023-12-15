import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { BrandService } from "src/app/core/service/brand.service";
import { CaseService } from "src/app/core/service/case.service";
import { SeriesService } from "src/app/core/service/series.service";
import { brand } from "src/app/shared/models/brand.model";
import { addCase, casePc, CaseSize, CaseSizes } from "src/app/shared/models/case.model";
import { series } from "src/app/shared/models/series.model";

@Component({
  selector: 'app-case-form',
  templateUrl: './case-form.component.html',
  styleUrls: ['./case-form.component.scss']
})
export class CaseFormComponent implements OnInit {
  id: number;
  res: casePc = new casePc();
  brnd: brand = new brand();
  srs: series = new series();
  brandList: brand[] = [];
  seriesList: series[] = [];
  caseSizesList: CaseSize[] = [];
  caseSizeData: CaseSize = {
    name: '',
    value: -1
  };
  enableSeries= true;
  caseForm!: FormGroup;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _caseService: CaseService,
    public _brandService: BrandService,
    private _seriesService: SeriesService
  ) {
    this.id = this._route.snapshot.params['id'];
    for (const key in CaseSizes) {
      if (!isNaN(Number(CaseSizes[key]))) {
        this.caseSizesList.push({ name: key, value: CaseSizes[key] as unknown as number });
      }
    }
  }

  ngOnInit(): void {
    console.log(this.caseSizesList);
    this._brandService.getBrands().subscribe(
      (brands: brand[]) => {
        this.brandList = brands;
      },
      (error) => {
        console.error('Error fetching brands:', error);
      }
    );

    if (this.id != null) {
      this._caseService.getCase(this.id).subscribe(
        (res: casePc) => {
          this.res.id = res.id;
          this.res = res;
        },
        (error) => {
          console.error('Error fetching brands:', error);
        }
      );
    }

    this.caseForm = new FormGroup({
      name: new FormControl('Sammy'),
      email: new FormControl(''),
      message: new FormControl('')
    });
  }

  executeForm(): void {
    if (this.id != null) {
      this._caseService.updateCase(this.res).subscribe(() => {
        console.log("yes");
        this._router.navigateByUrl(`brand`);
      },
      (error) => {
        console.log("no: " + error);
      });
    } else {

      let res: addCase = {
        name: this.res.name,
        model: this.res.model,
        height: this.res.height,
        width: this.res.width,
        deepth: this.res.deepth,
        description: this.res.description,
        caseSizeId: this.res.caseSizeId,
        seriesId: 0
      };

      if(this.srs.id){
        res.seriesId = this.srs.id;
      }

      this._caseService.addCase(res).subscribe(() => {
        console.log("yes");
        this._router.navigateByUrl(`brand`);
      },
      (error) => {
        console.log("no: " + error);
      });
    }
  }

  delete(id: number): void {
    console.log("im in")
    this._caseService.deleteCases(id).subscribe(
      () => {
        console.log('Brand deleted successfully');
      },
      (error) => {
        console.error('Error deleting brand:', error);
      }
    );
  }

  udpateBrand(brand: brand): void {
    this.brnd.id = brand.id;
    this.enableSeries = false;
      if(this.brnd.id){
        this._seriesService.getSeriesByBrand(this.brnd.id).subscribe(
          (res: series[]) => {
            this.seriesList = res;
          },
          (error) => {
            console.error('Error fetching brands:', error);
          }
        );
        this.brnd.name = "selected: " + brand.name;
      }
  }

  updateSeries(series: series): void {
      this.srs.id = series.id;
      this.srs.name = "selected: " + series.name;
  }

  updateCaseSize(caseS: CaseSize): void {
    this.caseSizeData = caseS;
    this.caseSizeData.name = "selected: " + this.caseSizeData.name;
  }
}

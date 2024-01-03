import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
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
  caseSizeData: CaseSize = {
    name: '',
    value: -1
  };

  brandList: brand[] = [];
  seriesList: series[] = [];
  caseSizesList: CaseSize[] = [];
  enableSeries = true;
  caseForm!: FormGroup;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _caseService: CaseService,
    public _brandService: BrandService,
    private _seriesService: SeriesService,
    private formBuilder: FormBuilder,
    private toastr: ToastrService
  ) {
    this.initForm();
    this.id = this._route.snapshot.params['id'];
    for (const key in CaseSizes) {
      if (!isNaN(Number(CaseSizes[key]))) {
        this.caseSizesList.push({ name: key, value: CaseSizes[key] as unknown as number });
      }
    }
  }

  initForm() {
    this.caseForm = this.formBuilder.group({
      name: ['', Validators.required],
      model: ['', Validators.required],
      height: [null, [Validators.required, Validators.min(1)]],
      width: [null, [Validators.required, Validators.min(1)]],
      deepth: [null, [Validators.required, Validators.min(1)]],
      caseSizeId: [null],
      seriesId: [null],
      description: ['Default description', Validators.required],
    });
  }

  ngOnInit(): void {
    this._brandService.getBrands().subscribe(
      (brands: brand[]) => {
        this.brandList = brands;
      },
      (error) => {
        this.toastr.error('Error fetching brand', 'Server Error');
      }
    );

    if (this.id != null) {
      this._caseService.getCase(this.id).subscribe(
        (res: casePc) => {
          this.res.id = res.id;
          this.res = res;
          this.caseForm.patchValue(res);

          this.caseSizeData.name = getCaseSizeName(this.res.caseSizeId);
          this.caseSizeData.value = this.res.caseSizeId;
          this.updateCaseSize(this.caseSizeData);

          this._seriesService.getSeriesById(res.seriesId).subscribe(
            (resSeries: series) => {
              this.srs = res;
              this.updateSeries(resSeries);

              if (resSeries.brandId) {
                this._brandService.getBrand(resSeries.brandId).subscribe(
                  (resBrand: brand) => {
                    this.brnd = resBrand;
                    this.updateBrand(resBrand);
                  }
                )
              }

            }
          );
        },
        (error) => {
          this.toastr.error('Error fetching Case', 'Server Error');
        }
      );
    }
  }

  executeForm(): void {
    if (this.caseForm.valid && this.srs.id && this.caseSizeData.value > -1) {
      if (this.id != null) {
        let updateForm = this.caseForm.value as casePc;
        updateForm.id = this.id;
        updateForm.seriesId = this.srs.id;
        updateForm.caseSizeId = this.caseSizeData.value;
        this._caseService.updateCase(updateForm).subscribe(() => {
          this.toastr.success('Case Updated Successfully!', 'Case Updated');
          this._router.navigateByUrl(`case`);
        },
          (error) => {
            this.toastr.error('Error adding case', 'Server Error');
          });
      } else {
        let addForm = this.caseForm.value as addCase;
        addForm.seriesId = this.srs.id;
        addForm.caseSizeId = this.caseSizeData.value;

        this._caseService.addCase(addForm).subscribe(() => {
          this.toastr.success('Case Added Successfully!', 'Case Added');
          this._router.navigateByUrl(`case`);
        },
          (error) => {
            this.toastr.error('Error editing case', 'Server Error');
          });
      }
    }
  }

  delete(id: number): void {
    this._caseService.deleteCases(id).subscribe(
      () => {
        this.toastr.success('Case Deleted Successfully!', 'Case Deleted');
      },
      (error) => {
        this.toastr.error('Error deleting case', 'Server Error');
      }
    );
  }

  updateBrand(brand: brand): void {
    this.brnd.id = brand.id;
    this.caseForm.value.brandId = brand.id;
    this.enableSeries = false;

    if (this.brnd.id != this.srs.brandId) {
      this.srs.id = undefined;
      this.srs.name = '';
    }

    if (this.brnd.id) {
      this._seriesService.getSeriesByBrand(this.brnd.id).subscribe(
        (res: series[]) => {
          this.seriesList = res;
        },
        (error) => {
          this.toastr.error('Error fetching data', 'Server Error');
        }
      );
      this.brnd.name = "selected: " + brand.name;
    }
  }

  updateSeries(series: series): void {
    this.caseForm.value.seriesId = series.id;
    this.srs = series;
    this.srs.id = series.id;
  }

  updateCaseSize(caseS: CaseSize): void {
    this.caseForm.value.caseSizeId = caseS.value;
    this.caseSizeData.value = caseS.value;
    this.caseSizeData.name = "selected: " + caseS.name;
  }
}

function getCaseSizeName(enumValue: number): string {
  const keys = Object.keys(CaseSizes).filter((x) => CaseSizes[x as keyof typeof CaseSizes] === enumValue);
  return keys[0];
}

import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
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
  selector: 'app-psu-from',
  templateUrl: './psu-form.component.html',
  styleUrls: ['./psu-form.component.scss']
})
export class PsuFormComponent implements OnInit {
  psuForm!: FormGroup;
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
    this.initForm();
    this.id = this._route.snapshot.params['id'];
  }

  initForm() {
    this.psuForm = this.formBuilder.group({
      name: ['', Validators.required],
      model: ['', Validators.required],
      type: ['', Validators.required],
      power: ['', [Validators.required, Validators.min(1)]],
      fans: ['', Validators.required],
      hasPFC: [false],
      mainConnPins: ['', Validators.required],
      pciExpressConn: ['', Validators.required],
      voltage: ['', Validators.required],
      freq: ['', Validators.required],
      connectors: ['', Validators.required],
      description: ['', Validators.required],
      dimensions: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this._brandService.getBrands().subscribe(
      (brands: brand[]) => {
        this.brandList = brands;
      },
      (error) => {
        this.toastr.error('Error fetching brands', 'Server Error');

      }
    );

    if (this.id != null) {
      this._psuService.getPsu(this.id).subscribe(
        (res: psu) => {
          this.res.id = res.id;
          this.res = res;
          this.psuForm.patchValue(res);

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
          this.toastr.error('Error fetching psu', 'Server Error');
        }
      );
    }
  }

  executeForm(): void {

    if (this.psuForm.valid && this.srs.id) {
      if (this.id != null) {
        let updateForm = this.psuForm.value as psu;
        updateForm.id = this.id;
        updateForm.seriesId = this.srs.id;
        updateForm.hasPFC = this.pfc;

        this._psuService.update(updateForm).subscribe(() => {
          this.toastr.success('PSU updated Successfully!', 'PSU} updated');
          this._router.navigateByUrl(`psu`);
        },
          (error) => {
            this.toastr.error('Error updating psu', 'Server Error');
          });
      } else {
        let addForm = this.psuForm.value as psu;
        addForm.seriesId = this.srs.id;
        addForm.hasPFC = this.pfc;

        this._psuService.add(addForm).subscribe(() => {
          this.toastr.success('PSU added Successfully!', 'PSU added');
          this._router.navigateByUrl(`psu`);
        },
          (error) => {
            this.toastr.error('Error adding psu', 'Server Error');
        });
      }
    }
  }

  delete(id: number): void {
    this._psuService.delete(id).subscribe(
      () => {
        this.toastr.success('PSU deleted Successfully!', 'PSU deleted');
      },
      (error) => {
        this.toastr.error('Error deleting PSU', 'Server Error');
      }
    );
  }

  updateBrand(brand: brand): void {
    this.brnd.id = brand.id;
    this.psuForm.value.brandId = brand.id;
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
          this.toastr.error('Error fetching series', 'Server Error');
        }
      );
      this.brnd.name = "selected: " + brand.name;
    }
  }

  updateSeries(series: series): void {
    this.srs = series;
    this.srs.id = series.id;
  }

  updatePfc(res: boolean): void {
    this.res.hasPFC = res;
    this.pfc = res;
  }
}

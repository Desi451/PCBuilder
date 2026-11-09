import { Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
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
  selector: 'app-drive-from',
  templateUrl: './drive-form.component.html',
  styleUrls: ['./drive-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class DriveFromComponent implements OnInit {
  hddForm!: FormGroup;
  id: number;
  res: hdd = new hdd();
  brnd: brand = new brand();
  srs: series = new series();
  slot: slot = new slot();
  hddList: hdd[] = [];
  slotsList: slot[] = [];
  brandList: brand[] = [];
  seriesList: series[] = [];
  enableSeries = true;

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
    this.initForm();
    this.id = this._route.snapshot.params['id'];
  }

  initForm() {
    this.hddForm = this.formBuilder.group({
      name: ['', Validators.required],
      model: ['', Validators.required],
      capacity: ['', [Validators.required, Validators.min(1)]],
      rpm: ['', Validators.required],
      description: [''],
      cache: ['', Validators.required],
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

    this._slotService.getSlots().subscribe(
      (brands: slot[]) => {
        this.slotsList = brands;
      },
      (error) => {
        this.toastr.error('Error fetching Interfaces', 'Server Error');
      }
    )

    if (this.id != null) {
      this._hddService.getHdd(this.id).subscribe(
        (res: hdd) => {
          this.res.id = res.id;
          this.res = res;
          this.hddForm.patchValue(res);

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

              if (res.slotInterfaceId) {
                this._slotService.getSlot(res.slotInterfaceId).subscribe(
                  (resSlot: slot) => {
                    this.slot = resSlot;
                    this.updateSlot(resSlot);
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

  executeForm(): void {

    if (this.hddForm.valid && this.srs.id && this.slot ) {
      if (this.id != null) {
        let updateForm = this.hddForm.value as hdd;
        updateForm.id = this.id;
        updateForm.seriesId = this.srs.id;
        updateForm.slotInterfaceId = this.slot.id;;
        this._hddService.update(updateForm).subscribe(() => {
          this.toastr.success('Drive updated Successfully!', 'Drive updated');
          this._router.navigateByUrl(`hdd`);
        },
          (error) => {
            this.toastr.error('Error updating drive', 'Server Error');
          });
      } else {
        let addForm = this.hddForm.value as hdd;
        addForm.seriesId = this.srs.id;
        addForm.slotInterfaceId = this.slot.id;

        this._hddService.add(addForm).subscribe(() => {
          this.toastr.success('Drive Added Successfully!', 'Drive Added');
          this._router.navigateByUrl(`hdd`);
        },
          (error) => {
            this.toastr.error('Error adding drive', 'Server Error');
          });
      }
    }
  }

  delete(id: number): void {
    this._hddService.delete(id).subscribe(
      () => {
        this.toastr.success('Drive deleted Successfully!', 'Drive deleted');
      },
      (error) => {
        this.toastr.error('Error deleting drive', 'Server Error');
      }
    );
  }

  updateBrand(brand: brand): void {
    this.brnd.id = brand.id;
    this.hddForm.value.brandId = brand.id;
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

  updateSlot(slot: slot): void {
    this.slot = slot;
  }
}

import { Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { BrandService } from "src/app/core/service/brand.service";
import { SeriesService } from "src/app/core/service/series.service";
import { SlotService } from "src/app/core/service/slot.service";
import { SsdService } from "src/app/core/service/ssd.service";
import { brand } from "src/app/shared/models/brand.model";
import { series } from "src/app/shared/models/series.model";
import { slot } from "src/app/shared/models/slot.model";
import { addSsd, ssd } from "src/app/shared/models/ssd.model";

@Component({
  selector: 'app-ssd-form',
  templateUrl: './ssd-form.component.html',
  styleUrls: ['./ssd-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class SsdFormComponent implements OnInit {
  ssdForm!: FormGroup;
  id: number;
  res: ssd = new ssd();
  brnd: brand = new brand();
  srs: series = new series();
  slot: slot = new slot();
  slotsList: slot[] = [];

  brandList: brand[] = [];
  seriesList: series[] = [];
  enableSeries = true;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _brandService: BrandService,
    private _seriesService: SeriesService,
    private _slotService: SlotService,
    private _ssdService: SsdService,
    private formBuilder: FormBuilder,
    private toastr: ToastrService
  ) {
    this.initForm();
    this.id = this._route.snapshot.params['id'];
  }

  initForm() {
    this.ssdForm = this.formBuilder.group({
      name: ['', Validators.required],
      model: ['', Validators.required],
      capacity: ['', [Validators.required, Validators.min(1)]],
      maxRead: ['', [Validators.required, Validators.min(1)]],
      maxWrite: ['', [Validators.required, Validators.min(1)]],
      description: ['', Validators.required]
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
      (slots: slot[]) => {
        this.slotsList = slots;
      },
      (error) => {
        this.toastr.error('Error fetching slots', 'Server Error');
      }
    )

    if (this.id != null) {
      this._ssdService.getSsd(this.id).subscribe(
        (res: ssd) => {
          this.res.id = res.id;
          this.res = res;
          this.ssdForm.patchValue(res);

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
          this.toastr.error('Error fetching SSD', 'Server Error');
        }
      );
    }
  }

  executeForm(): void {
    if (this.ssdForm.valid && this.srs.id && this.slot ) {
      if (this.id != null) {
        let updateForm = this.ssdForm.value as ssd;
        updateForm.id = this.id;
        updateForm.seriesId = this.srs.id;
        updateForm.slotInterfaceId = this.slot.id;

        this._ssdService.update(updateForm).subscribe(() => {
          this.toastr.success('SSD updated Successfully!', 'SSD updated');
          this._router.navigateByUrl(`ssd`);
        },
          (error) => {
            this.toastr.error('Error updating SSD', 'Server Error');
          });
      } else {
        let addForm = this.ssdForm.value as addSsd;
        addForm.seriesId = this.srs.id;
        addForm.slotInterfaceId = this.slot.id;

        this._ssdService.add(addForm).subscribe(() => {
          this._router.navigateByUrl(`ssd`);
        },
          (error) => {
            this.toastr.error('Error adding SSD', 'Server Error');
          });
      }
    }
  }

  delete(id: number): void {
    this._ssdService.delete(id).subscribe(
      () => {
        this.toastr.success('SSD deleted Successfully!', 'SSD deleted');
      },
      (error) => {
        this.toastr.error('Error deleting SSD', 'Server Error');
      }
    );
  }

  updateBrand(brand: brand): void {
    this.brnd.id = brand.id;
    this.ssdForm.value.brandId = brand.id;
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

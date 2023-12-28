import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { BrandService } from "src/app/core/service/brand.service";
import { GpuService } from "src/app/core/service/gpu.service";
import { SeriesService } from "src/app/core/service/series.service";
import { brand } from "src/app/shared/models/brand.model";
import { addGpu, gpu } from "src/app/shared/models/gpu.model";
import { series } from "src/app/shared/models/series.model";

@Component({
  selector: 'app-gpu-from',
  templateUrl: './gpu-form.component.html',
  styleUrls: ['./gpu-form.component.scss']
})
export class GpuFormComponent implements OnInit {
  gpuForm!: FormGroup;
  id: number;
  res: gpu = new gpu();
  brnd: brand = new brand();
  chipsetBrnd: brand = new brand();
  srs: series = new series();
  chipsetSrs: series = new series();
  brandList: brand[] = [];
  seriesList: series[] = [];
  chipsetSeriesList: series[] = [];
  enableSeries = true;
  enableChipsetSeries = true;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _brandService: BrandService,
    private _seriesService: SeriesService,
    private _gpuService: GpuService,
    private formBuilder: FormBuilder
  ) {
    this.initForm();
    this.id = this._route.snapshot.params['id'];
  }

  initForm() {
    this.gpuForm = this.formBuilder.group({
      name: ['', Validators.required],
      memorySize: ['', [Validators.required, Validators.min(1)]],
      memoryType: ['', Validators.required],
      coreClock: ['', [Validators.required, Validators.min(1)]],
      memoryInterface: ['', Validators.required],
      directX: ['', Validators.required],
      openGL: ['', Validators.required],
      tdp: ['', [Validators.required, Validators.min(1)]],
      recommendedPsuPower:  ['', [Validators.required, Validators.min(1)]],
      length:  ['', [Validators.required, Validators.min(1)]],
      description: ['']
    });
  }

  ngOnInit(): void {
    this._brandService.getBrands().subscribe(
      (brands: brand[]) => {
        this.brandList = brands;
      },
      (error) => {
        console.error('Error fetching brands:', error);
      }
    );

    if (this.id != null) {
      this._gpuService.getGpu(this.id).subscribe(
        (res: gpu) => {
          this.res = res;
          this.res.id = res.id;
          this.gpuForm.patchValue(res);
          this._seriesService.getSeriesById(res.seriesId).subscribe(
            (resSeries: series) => {
              this.srs = res;
              this.updateSeries(resSeries, false);

              if (resSeries.brandId) {
                this._brandService.getBrand(resSeries.brandId).subscribe(
                  (resBrand: brand) => {
                    this.brnd = resBrand;
                    this.updateBrand(resBrand, false);
                  }
                )
              }
            }
          );

          this._seriesService.getSeriesById(res.chipsetSeriesId).subscribe(
            (resSeries: series) => {
              this.chipsetSrs = res;
              this.updateSeries(resSeries, true);

              if (resSeries.brandId) {
                this._brandService.getBrand(resSeries.brandId).subscribe(
                  (resBrand: brand) => {
                    this.chipsetBrnd = resBrand;
                    this.updateBrand(resBrand, true);
                  }
                )
              }
            }
          );
        },
        (error) => {
          console.error('Error fetching brands:', error);
        }
      );
    }
  }

  executeForm(): void {
    debugger;
    console.log(this.gpuForm.value)
    if (this.gpuForm.valid && this.srs.id && this.chipsetSrs.id) {
      if (this.id != null) {
        let updateForm = this.gpuForm.value as gpu;
        updateForm.id = this.id;
        updateForm.seriesId = this.srs.id;
        updateForm.chipsetSeriesId = this.chipsetSrs.id
        this._gpuService.update(updateForm).subscribe(() => {
          console.log("yes");
          this._router.navigateByUrl(`gpu`);
        },
          (error) => {
            console.log("no: " + error);
          });
      } else {
        this.gpuForm.value.isApu = false;
        let addForm = this.gpuForm.value as addGpu;
        addForm.seriesId = this.srs.id;
        addForm.chipsetSeriesId = this.chipsetSrs.id;
        console.log(addForm);
        this._gpuService.add(addForm).subscribe(() => {
          console.log("yes");
          this._router.navigateByUrl(`gpu`);
        },
          (error) => {
            console.log("no: " + error.value);
          });
      }
    }
  }

  delete(id: number): void {

  }

  updateBrand(brand: brand, isChipset: boolean): void {
    if(!isChipset){
      this.brnd.id = brand.id;
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
            console.error('Error fetching brands:', error);
          }
        );
        this.brnd.name = "selected: " + brand.name;
        console.log(this.brnd.name);
      }
    }
    else {
        this.chipsetBrnd.id = brand.id;
        this.enableChipsetSeries = false;

        if (this.chipsetBrnd.id != this.chipsetSrs.brandId) {
          this.chipsetSrs.id = undefined;
          this.chipsetSrs.name = '';
        }

        if (this.brnd.id) {
          this._seriesService.getSeriesByBrand(this.chipsetBrnd.id).subscribe(
            (res: series[]) => {
              this.chipsetSeriesList = res;
            },
            (error) => {
              console.error('Error fetching brands:', error);
            }
          );
          this.chipsetBrnd.name = "selected: " + brand.name;
      }
    }
  }

  updateSeries(series: series, isChipset: boolean): void {
    if(!isChipset){
      this.srs = series;
      this.srs.name = series.name;
      this.srs.id = series.id;
    }
    else{
      this.chipsetSrs = series;
      this.chipsetSrs.name = series.name;
      this.chipsetSrs.id = series.id;
    }
  }
}

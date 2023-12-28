import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { BrandService } from "src/app/core/service/brand.service";
import { RamService } from "src/app/core/service/ram.service";
import { SeriesService } from "src/app/core/service/series.service";
import { brand } from "src/app/shared/models/brand.model";
import { addRam, ram, ramSpeed } from "src/app/shared/models/ram.model";
import { series } from "src/app/shared/models/series.model";

@Component({
  selector: 'app-ram-form',
  templateUrl: './ram-form.component.html',
  styleUrls: ['./ram-form.component.scss']
})
export class RamFormComponent implements OnInit {
  ramForm!: FormGroup;
  id: number;
  res: ram = new ram();
  brandList: brand[] = [];
  seriesList: series[] = [];
  speedsList: ramSpeed[] = [];
  brnd: brand = new brand();
  srs: series = new series();
  speed: ramSpeed = new ramSpeed();
  enableSeries = true;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _brandService: BrandService,
    private _seriesService: SeriesService,
    private _ramService: RamService,
    private formBuilder: FormBuilder
  ) {
    this.initForm();
    this.id = this._route.snapshot.params['id'];
  }

  initForm() {
    this.ramForm = this.formBuilder.group({
      name: ['', Validators.required],
      model: ['', Validators.required],
      capacity: [null, [Validators.required, Validators.min(1)]],
      noElements: [null, [Validators.required, Validators.min(1)]],
      description: ['Default description', Validators.required],
      latency: ['', Validators.required],
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

    this._ramService.getSpeeds().subscribe(
      (speeds: ramSpeed[]) => {
        this.speedsList = speeds;
      },
      (error) => {
        console.error('Error fetching brands:', error);
      }
    )

    if (this.id != null) {
      this._ramService.getRam(this.id).subscribe(
        (res: ram) => {
          console.log(res);
          this.res = res;
          this.res.id = res.id;
          this.ramForm.patchValue(res);

          if(res.memorySpeedId){
            this._ramService.getSpeed(res.memorySpeedId).subscribe(
              (spd: ramSpeed) => {
                console.log(spd);
                this.speed = spd;
                this.updateSpeed(spd);
              }
            );
          }
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
          console.error('Error fetching brands:', error);
        }
      );
    }
  }

  executeForm(): void {
    if (this.ramForm.valid && this.srs.id) {
      if (this.id != null) {
        let updateForm = this.ramForm.value as ram;
        updateForm.id = this.id;
        updateForm.seriesId = this.srs.id;
        updateForm.memorySpeedId = this.speed.id;

        this._ramService.update(updateForm).subscribe(() => {
          console.log("yes");
          this._router.navigateByUrl(`ram`);
        },
          (error) => {
            console.log("no: " + error);
          });
      } else {
        let addForm = this.ramForm.value as addRam;
        addForm.seriesId = this.srs.id;
        addForm.memorySpeedId = this.speed.id;

        console.log(addForm);
        this._ramService.add(addForm).subscribe(() => {
          console.log("yes");
          this._router.navigateByUrl(`ram`);
        },
          (error) => {
            console.log("no: " + error.value);
          });
      }
    }
  }

  delete(id: number): void {

  }

  updateBrand(brand: brand): void {

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
    }
  }

  updateSeries(series: series): void {
    this.srs = series;
    this.srs.name = series.name;
    this.srs.id = series.id;
  }

  updateSpeed(speed: ramSpeed): void {
    this.speed = speed;
    this.speed.freq = speed.freq;
    this.speed.standard = speed.standard;
  }
}

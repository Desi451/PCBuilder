import { Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { BrandService } from "src/app/core/service/brand.service";
import { CpuService } from "src/app/core/service/cpu.service";
import { SeriesService } from "src/app/core/service/series.service";
import { brand } from "src/app/shared/models/brand.model";
import { addCpu, cpu, socketCpu } from "src/app/shared/models/cpu.model";
import { series } from "src/app/shared/models/series.model";
import { getProblemMessage } from "src/app/shared/utils/problem-details";

@Component({
  selector: 'app-cpu-form',
  templateUrl: './cpu-form.component.html',
  styleUrls: ['./cpu-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})

export class CpuFormComponent implements OnInit {
  cpuForm!: FormGroup;
  id: number;
  res: cpu = new cpu();
  brnd: brand = new brand();
  srs: series = new series();
  socket: socketCpu = new socketCpu();
  brandList: brand[] = [];
  seriesList: series[] = [];
  socketList: socketCpu[] = [];

  enableSeries = true;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _brandService: BrandService,
    private _seriesService: SeriesService,
    private _cpuService: CpuService,
    private formBuilder: FormBuilder,
    private toastr: ToastrService
  ) {
    this.initForm();
    this.id = this._route.snapshot.params['id'];
  }

  initForm() {
    this.cpuForm = this.formBuilder.group({
      name: ['', Validators.required],
      model: ['', Validators.required],
      cores: ['', Validators.required],
      threads: ['', Validators.required],
      minFreq: ['', Validators.required],
      maxFreq: ['', Validators.required],
      l2Cache: ['', Validators.required],
      l3Cache: ['', Validators.required],
      maxRam: ['', Validators.required],
      isApu: [false, Validators.required],
      technology: ['', Validators.required],
      tdp: ['', Validators.required],
      description: ['', Validators.required],
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
      this._cpuService.getCpu(this.id).subscribe(
        (res: cpu) => {
          this.res = res;
          this.res.id = res.id;
          this.cpuForm.patchValue(res);
          this._seriesService.getSeriesById(res.seriesId).subscribe(
            (resSeries: series) => {
              this.srs = resSeries;
              this.updateSeries(resSeries);

              if (resSeries.brandId) {
                this._brandService.getBrand(resSeries.brandId).subscribe(
                  (resBrand: brand) => {
                    this.brnd = resBrand;
                    this.updateBrand(resBrand);
                  }
                )
              }

              if(res.socketCpuId){
                this._cpuService.getCpuSocket(res.socketCpuId).subscribe(
                  (resSocket: socketCpu) => {
                    this.socket = resSocket;
                    this.updateSocket(resSocket);
                  }
                )
              }

            }
          );
        },
        (error) => {
          this.toastr.error('Error fetching CPU', 'Server Error');
        }
      );
    }
  }

  executeForm(): void {
    if (this.cpuForm.valid && this.srs.id) {
      if (this.id != null) {
        let updateForm = this.cpuForm.value as cpu;
        updateForm.socketCpuId = this.socket.id;
        updateForm.id = this.id;
        updateForm.seriesId = this.srs.id;
        this._cpuService.update(updateForm).subscribe(() => {
          this.toastr.success('Cpu Updated Successfully!', 'Cpu Updated');
          this._router.navigateByUrl(`cpu`);
        },
          (error) => {
            this.toastr.error(getProblemMessage(error, 'Error updating CPU'), 'Server Error');
          });
      } else {
        let addForm = this.cpuForm.value as addCpu;
        addForm.socketCpuId = this.socket.id;
        addForm.seriesId = this.srs.id;

        this._cpuService.add(addForm).subscribe(() => {
          this.toastr.success('Cpu Added Successfully!', 'Cpu Added');
          this._router.navigateByUrl(`cpu`);
        },
          (error) => {
            this.toastr.error(getProblemMessage(error, 'Error adding CPU'), 'Server Error');
          });
      }
    }
  }

  delete(id: number): void {
    this._cpuService.delete(id).subscribe(
      () => {
        this.toastr.success('Brand deleted Successfully!', 'Brand deleted');
      },
      (error) => {
        this.toastr.error(getProblemMessage(error, 'Error deleting brand'), 'Server Error');
      }
    );
  }

  updateBrand(brand: brand): void {

    this.brnd.id = brand.id;
    this.enableSeries = false;

    if (this.brnd.id != this.srs.brandId) {
      this.srs.id = undefined;
      this.srs.name = '';

      this.socket.name = "";
      this.socket.id = 0;
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
      this._cpuService.getCpuSocketsByBrand(this.brnd.id).subscribe(
        (res: socketCpu[]) => {
          this.socketList = res;
        },
        (error) => {
          this.toastr.error('Error fetching sockets', 'Server Error');
        }
      );
      this.brnd.name = "selected: " + brand.name;
    }
  }

  updateSocket(socket: socketCpu): void {
    this.cpuForm.value.socketCpuId = socket.id;
    this.socket.id = socket.id;
    this.socket.brandId = socket.brandId;
    this.socket.name = socket.name;
  }

  updateSeries(series: series): void {
    this.srs = series;
    this.srs.name = series.name;
    this.srs.id = series.id;
  }

  updateApu(res: boolean): void {
    this.res.isAPU = res;
  }
}

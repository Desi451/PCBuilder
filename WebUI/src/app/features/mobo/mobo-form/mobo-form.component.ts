import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { BrandService } from "src/app/core/service/brand.service";
import { CpuService } from "src/app/core/service/cpu.service";
import { MoboService } from "src/app/core/service/mobo.service";
import { RamService } from "src/app/core/service/ram.service";
import { SeriesService } from "src/app/core/service/series.service";
import { brand } from "src/app/shared/models/brand.model";
import { CaseSize, CaseSizes } from "src/app/shared/models/case.model";
import { socketCpu } from "src/app/shared/models/cpu.model";
import { addMobo, mobo } from "src/app/shared/models/mobo.model";
import { ramSpeed } from "src/app/shared/models/ram.model";
import { series } from "src/app/shared/models/series.model";

@Component({
  selector: 'app-mobo-form',
  templateUrl: './mobo-form.component.html',
  styleUrls: ['./mobo-form.component.scss']
})
export class MoboFormComponent implements OnInit {
  moboForm!: FormGroup;
  id: number;
  res: mobo = new mobo();
  brnd: brand = new brand();
  socketBrnd: brand = new brand();
  srs: series = new series();
  socket: socketCpu = new socketCpu();
  brandList: brand[] = [];
  socketBrandList: brand[] = [];
  seriesList: series[] = [];
  socketList: socketCpu[] = [];
  caseSizesList: CaseSize[] = [];
  caseSizeData: CaseSize = {
    name: '',
    value: -1
  };
  enableSeries = true;
  ramMemoryList: ramSpeed[] = [];
  ramMemoryListUserData: ramSpeed[] = [];


  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _brandService: BrandService,
    private _seriesService: SeriesService,
    private formBuilder: FormBuilder,
    private _cpuService: CpuService,
    private _moboService: MoboService,
    private toastr: ToastrService,
    private _ramService: RamService
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
    this.moboForm = this.formBuilder.group({
      name: ['', Validators.required],
      model: ['', Validators.required],
      chipset: ['', Validators.required],
      maxMemory: [null, [Validators.required, Validators.min(1)]],
      m2Slots: [null, [Validators.required, Validators.min(1)]],
      sataSlots: [null, [Validators.required, Validators.min(1)]],
      description: ['Default description', Validators.required],
    });
  }

  ngOnInit(): void {
    this._brandService.getBrands().subscribe(
      (brands: brand[]) => {
        this.brandList = brands;
        this.socketBrandList = brands;
      },
      (error) => {
        this.toastr.error('Error fetching brands', 'Server Error');
      }
    );

    this._ramService.getSpeeds().subscribe(
      (speeds: ramSpeed[]) => {
        this.ramMemoryList = speeds;
      },
      (error) => {
        this.toastr.error('Error fetching ram speeds', 'Server Error');
      }
    );

    if(this.id){

      this._moboService.getMobo(this.id).subscribe(
        (res: mobo) => {
          this.res.id = res.id;
          this.res = res;
          this.moboForm.patchValue(res);
          this.ramMemoryListUserData = res.memories;

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
                  });
              }
            }
          );

          this._cpuService.getCpuSocket(res.socketCpuId).subscribe(
            (sockt: socketCpu) => {
              this.socket = sockt;
              this.updateSocket(sockt);

              if (sockt.brandId) {
                this._brandService.getBrand(sockt.brandId).subscribe(
                  (resBrand: brand) => {
                    this.socketBrnd = resBrand;
                    this.updateBrandSocket(resBrand);
                  });
              }
            }
          );
        },
        (error) => {
          this.toastr.error('Error fetching sockets', 'Server Error');
        }
      );
        this.ramMemoryListUserData = this.res.memories;
    }
    else{

    }
  }

  executeForm(): void {
    if(this.moboForm.valid && this.srs.id
      && this.caseSizeData.value > -1 && this.socket.id){

          if(this.id){
            let data = this.moboForm.value as mobo;
            data.caseSizeId = this.caseSizeData.value;
            data.socketCpuId = this.socket.id;
            data.seriesId = this.srs.id;
            data.memories = this.ramMemoryListUserData
            data.id = this.id;
            this._moboService.update(data).subscribe(() => {
              this.toastr.success('Motherboard updated Successfully!', 'Motherboard updated');
              this._router.navigateByUrl(`mobo`);
            },
              (error) => {
                this.toastr.error('Error updating motherboard', 'Server Error');
            });
          }
          else{
            let data = this.moboForm.value as addMobo;
            data.caseSizeId = this.caseSizeData.value;
            data.socketCpuId = this.socket.id;
            data.seriesId = this.srs.id;
            data.memories = this.ramMemoryListUserData
            this._moboService.add(data).subscribe(() => {
              this.toastr.success('Motherboard added Successfully!', 'Motherboard added');
              this._router.navigateByUrl(`mobo`);
            },
              (error) => {
                this.toastr.error('Error adding motherboard', 'Server Error');
            });
          }
    }
    else{
      this.toastr.error('Form not valid!');
    }
  }

  delete(id: number): void {
    this._moboService.delete(id).subscribe(
      () => {
        this.toastr.success('Motherboard deleted Successfully!', 'Motherboard deleted');
      },
      (error) => {
        this.toastr.error('Error deleting Motherboard', 'Server Error');
      }
    );
  }

  updateBrandSocket(brand: brand): void {

    this.socketBrnd = brand;
    this.socketBrnd.id = brand.id;

    if (this.socketBrnd.id) {
      this._cpuService.getCpuSocketsByBrand(this.socketBrnd.id).subscribe(
        (res: socketCpu[]) => {
          this.socketList = res;
        },
        (error) => {
          this.toastr.error('Error fetching socket', 'Server Error');
        }
      );
    }
  }

  updateBrand(brand: brand): void {
    this.brnd = brand;
    this.brnd.id = brand.id;
    this.enableSeries = false;

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
    }
  }

  updateSocket(socket: socketCpu): void {
    this.socket.id = socket.id;
    this.socket.brandId = socket.brandId;
    this.socket.name = socket.name;
  }

  updateSeries(series: series): void {
    this.srs = series;
    this.srs.name = series.name;
    this.srs.id = series.id;
  }

  updateCaseSize(caseS: CaseSize): void {
    this.caseSizeData.value = caseS.value;
    this.caseSizeData.name = "selected: " + caseS.name;
  }

  updateRam(ramS: ramSpeed, tab: ramSpeed[]): void {
    const index = tab.findIndex(item => item.standard === ramS.standard && item.freq === ramS.freq);
    if (index !== -1) {
      tab.splice(index, 1);
    } else {
      tab.push(ramS);
    }
  }

  createIdList(ramSpeeds: ramSpeed[]): number[] {
    return ramSpeeds.map(speed => speed.id);
  }
}

function getCaseSizeName(enumValue: number): string {
  const keys = Object.keys(CaseSizes).filter((x) => CaseSizes[x as keyof typeof CaseSizes] === enumValue);
  return keys[0];
}

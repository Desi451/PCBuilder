import { Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { AuthService } from "src/app/core/auth/auth.service";
import { ComputerService } from "src/app/core/service/computer.service";
import { GpuService } from "src/app/core/service/gpu.service";
import { HddService } from "src/app/core/service/hdd.service";
import { SlotService } from "src/app/core/service/slot.service";
import { SsdService } from "src/app/core/service/ssd.service";
import { brand } from "src/app/shared/models/brand.model";
import { casePc, CaseSizes } from "src/app/shared/models/case.model";
import { addComputer, caseRequest, computer, computerForm } from "src/app/shared/models/computer.model";
import { cpu } from "src/app/shared/models/cpu.model";
import { gpu } from "src/app/shared/models/gpu.model";
import { hdd } from "src/app/shared/models/hdd.model";
import { mobo } from "src/app/shared/models/mobo.model";
import { psu } from "src/app/shared/models/psu.model";
import { ram } from "src/app/shared/models/ram.model";
import { slot } from "src/app/shared/models/slot.model";
import { ssd } from "src/app/shared/models/ssd.model";

@Component({
  selector: 'app-computer-form',
  templateUrl: './computer-form.component.html',
  styleUrls: ['./computer-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class ComputerFormComponent implements OnInit {

  computerForm!: FormGroup;
  id: number;

  userId: number = 0;
  username: string = '';
  userRank: number = 0;

  //html
  BrandCollapsed = false;
  CpuCollapsed = true;
  MotherBoardCollapsed = true;
  RamMemoryCollapsed = true;
  GpuCollapsed = true;
  DriveCollapsed = true;
  PsuCollapsed = true;
  CaseCollapsed = true;

  //data
  brandList: brand[] = [];
  brnd: brand = new brand();

  cpuList: cpu[] = [];
  cpu: cpu = new cpu();

  moboList: mobo[] = [];
  mobo: mobo = new mobo();

  ramList: ram[] = [];
  ram: ram = new ram();

  gpuList: gpu[] = [];
  gpu: gpu = new gpu();

  psuList: psu[] = [];
  psu: psu = new psu();

  caseList: casePc[] = [];
  case: casePc = new casePc();

  selectedHdd: hdd[] = [];
  selectedSsd: ssd[] = [];
  hddList: hdd[] = [];
  ssdList: ssd[] = [];
  m2Index =0;
  sataIndex =0;
  driveSlot: slot;

  res: computer = new computer();

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private _computerService: ComputerService,
    private _gpuService: GpuService,
    private _hddService: HddService,
    private _ssdService: SsdService,
    private _slotService: SlotService,
    private _authService: AuthService
  ) {
    this.initForm();
    this.id = this._route.snapshot.params['id'];
  }

  initForm() {
    this.computerForm = this.formBuilder.group({
      name: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this._authService.getUserInfo().subscribe(response => {
      console.log(response);
      if (response.userId) {
        this.userId = response.userId;
        this.res.userId = response.userId;
        this.username = response.username;
        this.userRank = response.userRank;
      }
    });

    this._computerService.getCpuBrands().subscribe(
      (brands: brand[]) => {
        this.brandList = brands;
      },
      (error) => {
        this.toastr.error('Error fetching brands', 'Server Error');
      }
    );

    this._gpuService.getGpus().subscribe(
      (gpu: gpu[]) => {
        this.gpuList = gpu;
      },
      (error) => {
        this.toastr.error('Error fetching gpus', 'Server Error');
      }
    );

    if(this.id){
      this.BrandCollapsed = false;
      this.CpuCollapsed = false;
      this.MotherBoardCollapsed = false;
      this.RamMemoryCollapsed = false;
      this.GpuCollapsed = false;
      this.DriveCollapsed = false;
      this.PsuCollapsed = false;
      this.CaseCollapsed = false;

      this._computerService.getFullData(this.id).subscribe(
        (res: computerForm) => {
          this.updateBrand(res.cpuBrand);
          this.updateCpu(res.cpu);
          this.updateMotherboard(res.mobo);
          this.updateRam(res.ramMemory);
          this.updateGpu(res.gpu);
          for (let item of res.drives) {
            this.updateHdd(item,this.selectedHdd);
           }
           for (let item of res.ssds) {
            this.updateSsd(item,this.selectedSsd);
           }
          this.res.name = res.name;
          this.updatePsu(res.psu);
          this.updateCase(res.case);

          for (let item of res.ssds) {
            this.updateSsd(item,this.selectedSsd);
           }
        },
        (error) => {
          this.toastr.error('Error fetching brands', 'Server Error');
        }
      );

    }
  }

  updateBrand(brand: brand): void {
    if(this.brnd.id != brand.id){
      this.cpu = new cpu();
      this.updateCpu(this.cpu);

      this.mobo = new mobo();
      this.updateMotherboard(this.mobo);

      this.ram = new ram();
      this.updateRam(this.ram);
    }

    this.brnd.id = brand.id;
    if (this.brnd.id) {
      this.brnd.name = "selected: " + brand.name;

      this._computerService.getCpus(this.brnd.id).subscribe(
        (cpus: cpu[]) => {
          this.cpuList = cpus;
        },
        (error) => {
          this.toastr.error('Error fetching brands', 'Server Error');
        }
      );
    }
  }

  updateCpu(cpu: cpu): void {

    if(this.cpu.id != cpu.id){

      this.mobo = new mobo();
      this.updateMotherboard(this.mobo);

      this.ram = new ram();
      this.updateRam(this.ram);
    }

    this.cpu = cpu;
    this.cpu.id = cpu.id;
    if (this.cpu.id) {
      this.cpu.name = "selected: " + cpu.name;

      this._computerService.getMotherboards(this.cpu.socketCpuId).subscribe(
        (mobo: mobo[]) => {
          this.moboList = mobo;
        },
        (error) => {
          this.toastr.error('Error fetching brands', 'Server Error');
        }
      );
    }
  }

  updateMotherboard(mobo: mobo): void {

    if(this.mobo.id != mobo.id){
      this.ram = new ram();
      this.updateRam(this.ram);
    }

    this.mobo = mobo;
    this.mobo.id = mobo.id;
    if (this.mobo.id) {
      this.mobo.name = "selected: " + mobo.name;

      this._computerService.getRams(this.mobo.id).subscribe(
        (ram: ram[]) => {
          this.ramList = ram;
        },
        (error) => {
          this.toastr.error('Error fetching rams', 'Server Error');
        }
      );
    }

    this._hddService.getHdds().subscribe(
      (hdd: hdd[]) => {
        this.hddList = hdd;
      },
      (error) => {
        this.toastr.error('Error fetching hdds', 'Server Error');
      }
    );

    this._ssdService.getSsds().subscribe(
      (ssd: ssd[]) => {
        this.ssdList = ssd;
      },
      (error) => {
        this.toastr.error('Error fetching hdds', 'Server Error');
      }
    );
    this.m2Index =0;
    this.sataIndex =0;
  }

  updateRam(ram: ram): void {
    this.ram = ram;
    this.ram.id = ram.id;

    if (this.ram.id) {
      this.ram.name = "selected: " + ram.name;
    }
  }

  updateGpu(gpu: gpu): void {
    this.gpu = gpu;
    this.gpu.id = gpu.id;

    if (this.gpu.id) {
      this.gpu.name = "selected: " + gpu.name;
    }
    const minPow = Math.round((this.gpu.tdp + this.cpu.tdp + 50) * 1.25);
    console.log(minPow);
    this._computerService.getPsus(minPow).subscribe(
      (ram: psu[]) => {
        this.psuList = ram;
      },
      (error) => {
        this.toastr.error('Error fetching psus', 'Server Error');
      }
    );
  }


  updatePsu(psu: psu): void {
    this.psu = psu;
    this.psu.id = psu.id;
    if (this.psu.id) {
      this.psu.name = "selected: " + psu.name;
    }
    const psuVal = getCaseSizeValue(this.psu.standard) || this.mobo.caseSizeId;
    let caseReq: caseRequest;
    if (psuVal > this.mobo.caseSizeId) {
      caseReq = {
        caseId: psuVal,
        gpuLenght: this.gpu.length/10,
      };
    } else {
      caseReq = {
        caseId: this.mobo.caseSizeId,
        gpuLenght: this.gpu.length/10,
      };
    }
    console.log(caseReq);
    this._computerService.getCases(caseReq).subscribe(
      (cases: casePc[]) => {
        this.caseList = cases;
        console.log(this.caseList);
      },
      (error) => {
        this.toastr.error('Error fetching psus', 'Server Error');
      }
    );
  }

  updateCase(casep: casePc): void {
      this.case = casep;
      this.case.id = casep.id;

      if (this.case.id) {
        this.case.name = "selected: " + casep.name;
      }
  }

  updateHdd(hdd: hdd, tab: hdd[]): void {
    this._slotService.getSlot(hdd.slotInterfaceId).subscribe(
      (slot: slot) => {
        this.driveSlot = slot;

        if (this.driveSlot.name.includes("M2")) {

          if (this.m2Index <= this.mobo.m2Slots) {
            this.m2Index++;
            tab.push(hdd);
          }
        } else if (this.driveSlot.name.includes("SATA")) {

          if (this.sataIndex <= this.mobo.sataSlots) {
            this.sataIndex++;
            tab.push(hdd);
          }
        }
      },
      (error) => {
        this.toastr.error('Error fetching hdds', 'Server Error');
      }
    );
  }

  removeHdd(hdd: hdd, tab: hdd[]): void {
    const index = tab.findIndex(item => item.id === hdd.id);

    if (index !== -1) {

      this._slotService.getSlot(hdd.slotInterfaceId).subscribe(
        (slot: slot) => {
          this.driveSlot = slot;

          if (this.driveSlot.name.includes("M2")) {
            this.m2Index--;
          } else if (this.driveSlot.name.includes("SATA")) {
            this.sataIndex--;
          }
        },
        (error) => {
          this.toastr.error('Error fetching hdds', 'Server Error');
        }
      );

      tab.splice(index, 1);
    }
  }


  updateSsd(ssd: ssd, tab: ssd[]): void {
    this._slotService.getSlot(ssd.slotInterfaceId).subscribe(
      (slot: slot) => {
        this.driveSlot = slot;

        if (this.driveSlot.name.includes("M2")) {

          if (this.m2Index < this.mobo.m2Slots) {
            this.m2Index++;
            tab.push(ssd);
          }
        } else if (this.driveSlot.name.includes("SATA")) {

          if (this.sataIndex < this.mobo.sataSlots) {
            this.sataIndex++;
            tab.push(ssd);
          }
        }
      },
      (error) => {
        this.toastr.error('Error fetching hdds', 'Server Error');
      }
    );
  }

  removeSsd(ssd: ssd, tab: ssd[]): void {
    const index = tab.findIndex(item => item.id === ssd.id);

    if (index !== -1) {

      this._slotService.getSlot(ssd.slotInterfaceId).subscribe(
        (slot: slot) => {
          this.driveSlot = slot;

          if (this.driveSlot.name.includes("M2")) {
            this.m2Index--;
          } else if (this.driveSlot.name.includes("SATA")) {
            this.sataIndex--;
          }
        },
        (error) => {
          this.toastr.error('Error fetching hdds', 'Server Error');
        }
      );

      tab.splice(index, 1);
    }
  }

  executeForm(): void {
    this.res.caseId = this.case.id;
    this.res.cpuId = this.cpu.id;
    this.res.drives = this.selectedHdd;
    this.res.gpuId = this.gpu.id;
    this.res.isCompleted = true;
    this.res.motherboardId = this.mobo.id;
    this.res.psuId = this.psu.id;
    this.res.ramMemoryId = this.ram.id;
    this.res.ssds = this.selectedSsd;

    const noneIsNull = Object.values(this.res).every(value => value !== null);
    debugger;
    if (this.id && noneIsNull) {
        this.res.id = this.id;

        this._computerService.update(this.res).subscribe(() => {
          this.toastr.success('Computer updated Successfully!', 'Computer Updated');
          this._router.navigateByUrl(`computer`);
        },
        (error) => {
          this.toastr.error('Error updating Computer', 'Server Error');
        });

    } else {
      const res = this.res as unknown as addComputer;
      console.log(res);
      this._computerService.add(res).subscribe(() => {
        this.toastr.success('Computer updated Successfully!', 'Computer Updated');
        this._router.navigateByUrl(`computer`);
      },
      (error) => {
        this.toastr.error('Error updating Computer', 'Server Error');
      });
    }
  }

  delete(id: number): void {
    this._computerService.delete(id).subscribe(
      () => {
        this.toastr.success('Computer deleted Successfully!', 'Computer deleted');
      },
      (error) => {
        this.toastr.error('Error deleting computer', 'Server Error');
      }
    );
  }
}

function getCaseSizeValue(enumName: string): number | undefined {
  const sizeValue = CaseSizes[enumName as keyof typeof CaseSizes];
  return sizeValue !== undefined ? sizeValue : undefined;
}

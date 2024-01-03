import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { BrandService } from "src/app/core/service/brand.service";
import { CpuService } from "src/app/core/service/cpu.service";
import { brand } from "src/app/shared/models/brand.model";
import { addSocketCpu, socketCpu } from "src/app/shared/models/cpu.model";

@Component({
  selector: 'app-socket-form',
  templateUrl: './socket-form.component.html',
  styleUrls: ['./socket-form.component.scss']
})
export class SocketFormComponent {
  id: number;
  res: socketCpu = new socketCpu();
  brnd: brand = new brand();
  brandList: brand[] = [];

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _brandService: BrandService,
    private _cpuService: CpuService,
    private toastr: ToastrService
  ) {
    this.id = this._route.snapshot.params['id'];
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
     this._cpuService.getCpuSocket(this.id).subscribe(
      (socket: socketCpu) => {
        this.res = socket;

        if(socket.brandId){
          this._brandService.getBrand(socket.brandId).subscribe(
            (resBrand: brand) => {
              this.brnd = resBrand;
              this.updateBrand(resBrand);
            }
          );
        }
      },
      (error) => {
        this.toastr.error('Error getting socket', 'Server Error');
      }
     )
    }
  }

  executeForm(): void {
    this.res.brandId = this.brnd.id;
    if (this.res.name && this.res.brandId) {

      if(this.id){
        this.res.id;
        this._cpuService.updateSocket(this.res).subscribe(
          () => {
            this.toastr.success('Socket updated Successfully!', 'Socket updated');
            this._router.navigateByUrl(`cpu`);
          },
            (error) => {
              this.toastr.error('Error updating socket', 'Server Error');
          });
      }
      else{
        const res = this.res as addSocketCpu;
        this._cpuService.addSocket(res).subscribe(
          () => {
            this.toastr.success('Socket added Successfully!', 'Socket added');
            this._router.navigateByUrl(`cpu`);
          },
            (error) => {
              this.toastr.error('Error adding socket', 'Server Error');
          });
      }

    }
    else {
      this.toastr.error('Form not valid!');
    }
  }


  delete(id: number): void {
    this._cpuService.deleteSocket(id).subscribe(
      () => {
        this.toastr.success('Socket deleted Successfully!', 'Socket deleted');
      },
      (error) => {
        this.toastr.error('Error deleting socket', 'Server Error');
      }
    );
  }

  updateBrand(brand: brand): void {
    this.brnd.id = brand.id;
    this.brnd.name = "selected: " + brand.name;
  }
}

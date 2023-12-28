import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
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
    private _cpuService: CpuService
  ) {
    this.id = this._route.snapshot.params['id'];
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
        console.error('Error fetching cpus:', error);
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
            this._router.navigateByUrl(`cpu`);
          },
            (error) => {
              console.log("no: " + error.value);
          });
      }
      else{
        const res = this.res as addSocketCpu;
        this._cpuService.addSocket(res).subscribe(
          () => {
            this._router.navigateByUrl(`cpu`);
          },
            (error) => {
              console.log("no: " + error.value);
          });
      }

    }
    else {
        console.error('form not valid');
    }
  }


  delete(id: number): void {
    console.log("im in")
    this._cpuService.deleteSocket(id).subscribe(
      () => {
        console.log('Socket deleted successfully');
      },
      (error) => {
        console.error('Error deleting socket:', error);
      }
    );
  }

  updateBrand(brand: brand): void {

    this.brnd.id = brand.id;
    this.brnd.name = "selected: " + brand.name;
  }
}

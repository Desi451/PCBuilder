import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { BrandService } from "src/app/core/service/brand.service";
import { addBrand, brand } from "src/app/shared/models/brand.model";

@Component({
  selector: 'app-brand-form',
  templateUrl: './brand-form.component.html',
  styleUrls: ['./brand-form.component.scss']
})
export class BrandFormComponent implements OnInit {

  id: number;
  res: brand = new brand();

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _brandService: BrandService,
    private toastr: ToastrService
  ) {
    this.id = this._route.snapshot.params['id'];
  }

  ngOnInit(): void {
    if (this.id != null) {
      this._brandService.getBrand(this.id).subscribe(
        (res: brand) => {
          this.res.id = res.id;
          this.res = res;
        },
        (error) => {
          this.toastr.error('Error fetching brand', 'Server Error');
        }
      );
    }
  }

  executeForm(): void {

    if (this.res.name) {
      if (this.id != null) {
        this._brandService.updateBrand(this.res).subscribe(() => {
          this.toastr.success('Brand updated Successfully!', 'Brand updated');
          this._router.navigateByUrl(`brand`);
        },
          (error) => {
            this.toastr.error('Error updating brand', 'Server Error');
          });
      } else {
        let res: addBrand = {};
        res.name = this.res.name;
        this._brandService.addBrand(res).subscribe(() => {
          this.toastr.success('Brand Added Successfully!', 'Brand Added');
          this._router.navigateByUrl(`brand`);
        },
          (error) => {
            this.toastr.error('Error sending brand', 'Server Error');
          });
      }
    } else {
      this.toastr.error('Fill all needed data!', 'Form Error');
    }

  }

  delete(id: number): void {
    this._brandService.deleteBrand(id).subscribe(
      () => {
        this.toastr.success('Brand deleted Successfully!', 'Brand deleted');
      },
      (error) => {
        this.toastr.error('Error deleting brand', 'Server Error');
      }
    );
  }
}

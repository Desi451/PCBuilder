import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
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
    public _brandService: BrandService
  ) {
    this.id = this._route.snapshot.params['id'];
  }

  ngOnInit(): void {
    if (this.id != null) {
      this._brandService.getBrand(this.id).subscribe(
        (res: brand) => {
          console.log("res= ", res);
          this.res.id = res.id;
          this.res = res;
        },
        (error) => {
          console.error('Error fetching brands:', error);
        }
      );
    }
  }

  executeForm(): void {
    console.log(this.id);
    if (this.id != null) {
      console.log(this.res);
      this._brandService.updateBrand(this.res).subscribe(() => {
        console.log("yes");
        this._router.navigateByUrl(`brand`);
      },
      (error) => {
        console.log("no: " + error);
      });
    } else {
      let res: addBrand = {};
      res.name = this.res.name;
      this._brandService.addBrand(res).subscribe(() => {
        console.log("yes");
        this._router.navigateByUrl(`brand`);
      },
      (error) => {
        console.log("no: " + error);
      });
    }
  }

  delete(id: number): void {
    console.log("im in")
    this._brandService.deleteBrand(id).subscribe(
      () => {
        console.log('Brand deleted successfully');
      },
      (error) => {
        console.error('Error deleting brand:', error);
      }
    );
  }
}

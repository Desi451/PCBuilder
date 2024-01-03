import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { BrandService } from "src/app/core/service/brand.service";
import { SeriesService } from "src/app/core/service/series.service";
import { brand } from "src/app/shared/models/brand.model";
import { series } from "src/app/shared/models/series.model";

@Component({
  selector: 'app-brand-view',
  templateUrl: './brand-view.component.html',
  styleUrls: ['./brand-view.component.scss']
})
export class BrandViewComponent implements OnInit {
  id: number;
  seriesList: series[] = [];
  brand: brand = new brand();
  isDataLoaded = false;

  constructor(
    public _brandService: BrandService,
    public _seriesService: SeriesService,
    private _route: ActivatedRoute,
    private _router: Router,
    private cdr: ChangeDetectorRef, // Inject ChangeDetectorRef
    private toastr: ToastrService
  ) { this.id = this._route.snapshot.params['id']; }

  ngOnInit(): void {
    this._seriesService.changeBrandId(this.id);
    this._brandService.getBrand(this.id).subscribe(
      (res: brand) => {
        this.brand = res;
      },
      (error) => {
        this.toastr.error('Error fetching brand', 'Server Error');
      }
    );

    this._seriesService.getSeriesByBrand(this.id).subscribe(
      (res: series[]) => {
        this.seriesList = res;
        this.isDataLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        this.toastr.error('Error fetching Series', 'Server Error');
      }
    )
  }
}

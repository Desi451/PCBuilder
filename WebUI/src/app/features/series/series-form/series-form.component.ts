import { Component, ChangeDetectionStrategy } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { SeriesService } from "src/app/core/service/series.service";
import { addSeries, series } from "src/app/shared/models/series.model";

@Component({
  selector: 'app-series-form',
  templateUrl: './series-form.component.html',
  styleUrls: ['./series-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class SeriesFormComponent {
  seriesId: number;
  brandId!: number;
  res: series = new series();

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _seriesService: SeriesService,
    private toastr: ToastrService
  ) {
    this.seriesId = this._route.snapshot.params['id'];
    this._seriesService.currentBrandId.subscribe(brandId => {
      this.brandId = brandId;
    });
  }

  ngOnInit(): void {
    if (this.seriesId != null) {
      this._seriesService.getSeriesById(this.seriesId).subscribe(
        (res: series) => {
          this.res.id = res.id;
          this.res = res;
        },
        (error) => {
          this.toastr.error('Error fetching series', 'Server Error');
        }
      );
    }
  }

  executeForm(): void {
    if (this.seriesId != null) {
      this.res.brandId = this.brandId;
      this._seriesService.updateSeries(this.res).subscribe(() => {
        this.toastr.success('Series updated Successfully!', 'Series updated');
        this._router.navigateByUrl(`brand`);
      },
      (error) => {
        this.toastr.error('Error updating series', 'Server Error');
      });
    } else {
      let res: addSeries = {};
      res.name = this.res.name;
      res.brandId = this.brandId;
      this._seriesService.addSeries(res).subscribe(() => {
        this.toastr.success('Series added Successfully!', 'Series added');
        this._router.navigateByUrl(`brand`);
      },
      (error) => {
        this.toastr.error('Error adding series', 'Server Error');
      });
    }
  }

  delete(id: number): void {
    this._seriesService.deleteSeries(id).subscribe(
      () => {
        this.toastr.success('Brand deleted Successfully!', 'Brand deleted');
      },
      (error) => {
        this.toastr.error('Error deleting series', 'Server Error');
      }
    );
  }
}

import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { SeriesService } from "src/app/core/service/series.service";
import { addSeries, series } from "src/app/shared/models/series.model";

@Component({
  selector: 'app-series-form',
  templateUrl: './series-form.component.html',
  styleUrls: ['./series-form.component.scss']
})
export class SeriesFormComponent {
  seriesId: number;
  brandId!: number;
  res: series = new series();

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _seriesService: SeriesService
  ) {
    this.seriesId = this._route.snapshot.params['id'];
    this._seriesService.currentBrandId.subscribe(brandId => {
      console.log("brand:" + brandId);
      this.brandId = brandId;
    });
  }

  ngOnInit(): void {
    if (this.seriesId != null) {
      this._seriesService.getSeriesById(this.seriesId).subscribe(
        (res: series) => {
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
    if (this.seriesId != null) {
      this.res.brandId = this.brandId;
      this._seriesService.updateSeries(this.res).subscribe(() => {
        console.log("yes");
        this._router.navigateByUrl(`brand`);
      },
      (error) => {
        console.log("no: " + error);
      });
    } else {
      let res: addSeries = {};
      res.name = this.res.name;
      res.brandId = this.brandId;
      this._seriesService.addSeries(res).subscribe(() => {
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
    this._seriesService.deleteSeries(id).subscribe(
      () => {
        console.log('Brand deleted successfully');
      },
      (error) => {
        console.error('Error deleting brand:', error);
      }
    );
  }
}

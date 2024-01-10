import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { PsuService } from "src/app/core/service/psu.service";
import { psu } from "src/app/shared/models/psu.model";

@Component({
  selector: 'app-psu-list',
  templateUrl: './psu-list.component.html',
  styleUrls: ['./psu-list.component.scss']
})
export class PsuListComponent implements OnInit {
  list: psu[] = [];
  isDataLoaded = false;
  constructor(
    public _psuService: PsuService,
    private toastr: ToastrService,
    private cdr: ChangeDetectorRef // Inject ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this._psuService.getPsus().subscribe(
      (brands: psu[]) => {
        this.list = brands;
        this.isDataLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        this.toastr.error('Error fetching PSUs', 'Server Error');
      }
    );
  }
}

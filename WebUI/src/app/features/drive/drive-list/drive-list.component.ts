import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { HddService } from "src/app/core/service/hdd.service";
import { hdd } from "src/app/shared/models/hdd.model";

@Component({
  selector: 'app-drive-list',
  templateUrl: './drive-list.component.html',
  styleUrls: ['./drive-list.component.scss']
})
export class DriveListComponent implements OnInit {
  list: hdd[] = [];
  isDataLoaded = false;
  constructor(
    public _hddService: HddService,
    private toastr: ToastrService,
    private cdr: ChangeDetectorRef // Inject ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this._hddService.getHdds().subscribe(
      (brands: hdd[]) => {
        this.list = brands;
        this.isDataLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        this.toastr.error('Error fetching drives', 'Server Error');
      }
    );
  }
}

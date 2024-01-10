import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { SsdService } from "src/app/core/service/ssd.service";
import { ssd } from "src/app/shared/models/ssd.model";

@Component({
  selector: 'app-ssd-list',
  templateUrl: './ssd-list.component.html',
  styleUrls: ['./ssd-list.component.scss']
})
export class SsdListComponent implements OnInit {
  list: ssd[] = [];
  isDataLoaded = false;
  constructor(
    public _ssdService: SsdService,
    private cdr: ChangeDetectorRef,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this._ssdService.getSsds().subscribe(
      (brands: ssd[]) => {
        this.list = brands;
        this.isDataLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        this.toastr.error('Error fetching SSDs', 'Server Error');
      }
    );
  }
}

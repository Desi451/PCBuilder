import { ChangeDetectorRef, Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { SlotService } from "src/app/core/service/slot.service";
import { slot } from "src/app/shared/models/slot.model";

@Component({
  selector: 'app-slot-list',
  templateUrl: './slot-list.component.html',
  styleUrls: ['./slot-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class SlotListComponent implements OnInit {
  list: slot[] = [];
  isDataLoaded = false;
  constructor(
    public _slotservice: SlotService,
    private cdr: ChangeDetectorRef, // Inject ChangeDetectorRef
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this._slotservice.getSlots().subscribe(
      (brands: slot[]) => {
        this.list = brands;
        this.isDataLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        this.toastr.error('Error fetching interfaces', 'Server Error');
      }
    );
  }
}

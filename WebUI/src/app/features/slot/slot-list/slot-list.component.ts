import { ChangeDetectorRef, Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
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
    private cdr: ChangeDetectorRef // Inject ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this._slotservice.getSlots().subscribe(
      (brands: slot[]) => {
        this.list = brands;
        this.isDataLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        console.error('Error fetching brands:', error);
        
      }
    );
  }
}

import { Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { SlotService } from "src/app/core/service/slot.service";
import { addSlot, slot } from "src/app/shared/models/slot.model";
import { getProblemMessage } from "src/app/shared/utils/problem-details";

@Component({
  selector: 'app-slot-from',
  templateUrl: './slot-form.component.html',
  styleUrls: ['./slot-form.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class SlotFormComponent implements OnInit {

  id: number;
  res: slot = new slot();

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _slotService: SlotService,
    private toastr: ToastrService
  ) {
    this.id = this._route.snapshot.params['id'];
  }

  ngOnInit(): void {
    if (this.id != null) {
      this._slotService.getSlot(this.id).subscribe(
        (res: slot) => {
          this.res.id = res.id;
          this.res = res;
        },
        (error) => {
          this.toastr.error('Error fetching slots', 'Server Error');
        }
      );
    }
  }

  executeForm(): void {

    if (this.res.name) {
      if (this.id != null) {
        this._slotService.update(this.res).subscribe(() => {
          this.toastr.success('Slot updated Successfully!', 'Slot updated');
          this._router.navigateByUrl(`slot`);
        },
          (error) => {
            this.toastr.error(getProblemMessage(error, 'Error updating slot'), 'Server Error');
          });
      } else {
        let res: addSlot = {
          name: this.res.name
        };
        this._slotService.add(res).subscribe(() => {
          this.toastr.success('Slot updated Successfully!', 'Slot updated');
          this._router.navigateByUrl(`slot`);
        },
          (error) => {
            this.toastr.error(getProblemMessage(error, 'Error adding slot'), 'Server Error');
          });
      }
    }

  }

  delete(id: number): void {
    this._slotService.delete(id).subscribe(
      () => {
        this.toastr.success('Slot deleted Successfully!', 'Brand deleted');
      },
      (error) => {
        this.toastr.error(getProblemMessage(error, 'Error deleting slot'), 'Server Error');
      }
    );
  }
}

import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { SlotService } from "src/app/core/service/slot.service";
import { addSlot, slot } from "src/app/shared/models/slot.model";

@Component({
  selector: 'app-slot-from',
  templateUrl: './slot-form.component.html',
  styleUrls: ['./slot-form.component.scss']
})
export class SlotFormComponent implements OnInit {

  id: number;
  res: slot = new slot();

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _slotService: SlotService
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
          console.error('Error fetching brands:', error);
        }
      );
    }
  }

  executeForm(): void {

    if (this.res.name) {
      if (this.id != null) {
        this._slotService.update(this.res).subscribe(() => {
          console.log("yes");
          this._router.navigateByUrl(`slot`);
        },
          (error) => {
            console.log("no: " + error);
          });
      } else {
        let res: addSlot = {
          name: this.res.name
        };
        this._slotService.add(res).subscribe(() => {
          console.log("yes");
          this._router.navigateByUrl(`slot`);
        },
          (error) => {
            console.log("no: " + error);
          });
      }
    }

  }

  delete(id: number): void {
    console.log("im in")
    this._slotService.delete(id).subscribe(
      () => {
        console.log('Brand deleted successfully');
      },
      (error) => {
        console.error('Error deleting brand:', error);
      }
    );
  }
}

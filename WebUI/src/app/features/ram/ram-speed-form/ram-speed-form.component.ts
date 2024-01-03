import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { RamService } from "src/app/core/service/ram.service";
import { addRam, ramSpeed } from "src/app/shared/models/ram.model";

@Component({
  selector: 'app-ram-speed-form',
  templateUrl: './ram-speed-form.component.html',
  styleUrls: ['./ram-speed-form.component.scss']
})
export class RamSpeedFormComponent implements OnInit {
  ramForm!: FormGroup;
  id: number;
  speed: ramSpeed = new ramSpeed();
  enableSeries = true;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private _ramService: RamService,
    private formBuilder: FormBuilder,
    private toastr: ToastrService
  ) {
    this.initForm();
    this.id = this._route.snapshot.params['id'];
  }

  initForm() {
    this.ramForm = this.formBuilder.group({
      standard: ['', Validators.required],
      freq: [null, [Validators.required, Validators.min(1)]],
    });
  }

  ngOnInit(): void {
    if (this.id != null) {
      this._ramService.getSpeed(this.id).subscribe(
        (res: ramSpeed) => {
          this.speed = res;
          this.ramForm.patchValue(res);
        },
        (error) => {
          this.toastr.error('Error fetching RAM standard', 'Server Error');
        }
      );
    }
  }

  executeForm(): void {
    if (this.ramForm.valid) {
      if (this.id != null) {
        let updateForm = this.ramForm.value as ramSpeed;
        updateForm.id = this.id;
        this._ramService.updateSpeed(updateForm).subscribe(() => {
          this.toastr.success('RAM speed updated Successfully!', 'RAM speed updated');
          this._router.navigateByUrl(`ram`);
        },
          (error) => {
            this.toastr.error('Error updating RAM', 'Server Error');
          });
      } else {
        let addForm = this.ramForm.value as addRam;
        this._ramService.addSpeed(addForm).subscribe(() => {
          this.toastr.success('RAM speed added Successfully!', 'RAM speed added');
          this._router.navigateByUrl(`ram`);
        },
          (error) => {
            this.toastr.error('Error adding RAM speed', 'Server Error');
          });
      }
    } else {
      this.toastr.error('Data not valid!');
    }
  }

  delete(id: number): void {
    this._ramService.deleteSpeed(id).subscribe(
      () => {
        this.toastr.success('RAM deleted Successfully!', 'RAM deleted');
      },
      (error) => {
        this.toastr.error('Error deleting RAM', 'Server Error');
      }
    );
  }
}

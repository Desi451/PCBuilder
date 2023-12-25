import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { BrandService } from "src/app/core/service/brand.service";
import { SeriesService } from "src/app/core/service/series.service";
import { psu } from "src/app/shared/models/psu.model";

@Component({
  selector: 'app-psu-from',
  templateUrl: './psu-form.component.html',
  styleUrls: ['./psu-form.component.scss']
})
export class PsuFormComponent implements OnInit {
  psuForm!: FormGroup;
  id: number;
  res: psu = new psu();

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    public _brandService: BrandService,
    private _seriesService: SeriesService,
    private formBuilder: FormBuilder
  ) {
    this.initForm();
    this.id = this._route.snapshot.params['id'];
  }

  initForm() {
    this.psuForm = this.formBuilder.group({
      name: ['', Validators.required],
      model: ['', Validators.required],
      height: [null, [Validators.required, Validators.min(1)]],
      width: [null, [Validators.required, Validators.min(1)]],
      deepth: [null, [Validators.required, Validators.min(1)]],
      caseSizeId: [null],
      seriesId: [null],
      description: ['Default description', Validators.required],
    });
  }

  ngOnInit(): void {
    throw new Error("Method not implemented.");
  }

  executeForm(): void {

  }

  delete(id: number): void {

  }
}

import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { BrandService } from "src/app/core/service/brand.service";
import { SeriesService } from "src/app/core/service/series.service";
import { mobo } from "src/app/shared/models/mobo.model";

@Component({
  selector: 'app-mobo-form',
  templateUrl: './mobo-form.component.html',
  styleUrls: ['./mobo-form.component.scss']
})
export class MoboFormComponent implements OnInit {
  moboForm!: FormGroup;
  id: number;
  res: mobo = new mobo();

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
    this.moboForm = this.formBuilder.group({
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

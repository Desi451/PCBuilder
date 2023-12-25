import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { BrandService } from "src/app/core/service/brand.service";
import { SeriesService } from "src/app/core/service/series.service";
import { gpu } from "src/app/shared/models/gpu.model";

@Component({
  selector: 'app-gpu-from',
  templateUrl: './gpu-form.component.html',
  styleUrls: ['./gpu-form.component.scss']
})
export class GpuFormComponent implements OnInit {
  gpuForm!: FormGroup;
  id: number;
  res: gpu = new gpu();

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
    this.gpuForm = this.formBuilder.group({
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

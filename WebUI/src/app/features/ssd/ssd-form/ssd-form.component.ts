import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { BrandService } from "src/app/core/service/brand.service";
import { SeriesService } from "src/app/core/service/series.service";
import { ssd } from "src/app/shared/models/ssd.model";

@Component({
  selector: 'app-ssd-form',
  templateUrl: './ssd-form.component.html',
  styleUrls: ['./ssd-form.component.scss']
})
export class SsdFormComponent implements OnInit {
  ssdForm!: FormGroup;
  id: number;
  res: ssd = new ssd();

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
    this.ssdForm = this.formBuilder.group({
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
    
  }

  executeForm(): void {

  }

  delete(id: number): void {

  }
}

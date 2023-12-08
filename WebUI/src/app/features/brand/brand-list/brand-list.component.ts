import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { BrandService } from "src/app/core/service/brand.service";
import { brand } from "src/app/shared/models/brand.model";

@Component({
  selector: 'app-brand-list',
  templateUrl: './brand-list.component.html',
  styleUrls: ['./brand-list.component.scss']
})

export class BrandListComponent implements OnInit {
  brandList: brand[] = [];
  isDataLoaded = false;
  constructor(
    public _brandService: BrandService,
    private cdr: ChangeDetectorRef // Inject ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this._brandService.getBrands().subscribe(
      (brands: brand[]) => {
        this.brandList = brands;
        this.isDataLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        console.error('Error fetching brands:', error);
      }
    );
  }
}

import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { GpuService } from "src/app/core/service/gpu.service";
import { gpu } from "src/app/shared/models/gpu.model";

@Component({
  selector: 'app-gpu-list',
  templateUrl: './gpu-list.component.html',
  styleUrls: ['./gpu-list.component.scss']
})
export class GpuListComponent implements OnInit {
  cpuList: gpu[] = [];
  isDataLoaded = false;
  constructor(
    public _gpuService: GpuService,
    private cdr: ChangeDetectorRef // Inject ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this._gpuService.getGpus().subscribe(
      (brands: gpu[]) => {
        this.cpuList = brands;
        this.isDataLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        console.error('Error fetching brands:', error);
      }
    );
  }
}

import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { CpuService } from "src/app/core/service/cpu.service";
import { cpu } from "src/app/shared/models/cpu.model";

@Component({
  selector: 'app-cpu-list',
  templateUrl: './cpu-list.component.html',
  styleUrls: ['./cpu-list.component.scss']
})
export class CpuListComponent implements OnInit {
  cpuList: cpu[] = [];
  isDataLoaded = false;
  constructor(
    public _cpuService: CpuService,
    private cdr: ChangeDetectorRef // Inject ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this._cpuService.getCpus().subscribe(
      (brands: cpu[]) => {
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

import { ChangeDetectorRef, Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { CpuService } from "src/app/core/service/cpu.service";
import { cpu, socketCpu } from "src/app/shared/models/cpu.model";

@Component({
  selector: 'app-cpu-list',
  templateUrl: './cpu-list.component.html',
  styleUrls: ['./cpu-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: false
})
export class CpuListComponent implements OnInit {
  cpuList: cpu[] = [];
  socketList: socketCpu[] = [];
  isDataLoaded = false;
  isSocketLoaded= false;
  constructor(
    public _cpuService: CpuService,
    private cdr: ChangeDetectorRef,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this._cpuService.getCpus().subscribe(
      (cpu: cpu[]) => {
        this.cpuList = cpu;
        this.isDataLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        this.toastr.error('Error fetching cpus', 'Server Error');
      }
    );

    this._cpuService.getCpuSockets().subscribe(
      (res: socketCpu[]) => {
        this.socketList = res;
        this.isSocketLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        this.toastr.error('Error fetching sockets', 'Server Error');
      }
    );
  }
}

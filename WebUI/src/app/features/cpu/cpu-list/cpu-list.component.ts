import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { CpuService } from "src/app/core/service/cpu.service";
import { cpu, socketCpu } from "src/app/shared/models/cpu.model";

@Component({
  selector: 'app-cpu-list',
  templateUrl: './cpu-list.component.html',
  styleUrls: ['./cpu-list.component.scss']
})
export class CpuListComponent implements OnInit {
  cpuList: cpu[] = [];
  socketList: socketCpu[] = [];
  isDataLoaded = false;
  isSocketLoaded= false;
  constructor(
    public _cpuService: CpuService,
    private cdr: ChangeDetectorRef // Inject ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this._cpuService.getCpus().subscribe(
      (cpu: cpu[]) => {
        this.cpuList = cpu;
        this.isDataLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        console.error('Error fetching cpus:', error);
      }
    );

    this._cpuService.getCpuSockets().subscribe(
      (res: socketCpu[]) => {
        this.socketList = res;
        this.isSocketLoaded = true;
        this.cdr.detectChanges();
      },
      (error) => {
        console.error('Error fetching sockets:', error);
      }
    );
  }
}

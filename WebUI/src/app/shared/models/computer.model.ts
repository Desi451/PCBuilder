import { brand } from "./brand.model";
import { casePc } from "./case.model";
import { cpu } from "./cpu.model";
import { gpu } from "./gpu.model";
import { hdd } from "./hdd.model";
import { mobo } from "./mobo.model";
import { psu } from "./psu.model";
import { ram } from "./ram.model";
import { ssd } from "./ssd.model";

export class computer {
  id: number;
  userId: number;
  name: string;
  isCompleted: boolean;
  caseId: number;
  cpuId: number;
  gpuId?: number | null;
  motherboardId: number;
  ramMemoryId: number;
  psuId: number;

  drives: hdd[] = [];
  ssds: ssd[] = [];
}

export class computerForm {

  id: number;
  userId: number;
  name: string;
  isCompleted: boolean;
  case: casePc;
  cpu: cpu;
  gpu?: gpu | null;
  mobo: mobo;
  ramMemory: ram;
  psu: psu;

  cpuBrand: brand;

  drives: hdd[] = [];
  ssds: ssd[] = [];
}

export type addComputer = {
  name: string,
  userId: number;
  model: string,
  isCompleted: boolean,
  caseId: number,
  cpuId: number,
  motherboardId: number,
  ramMemoryId: number,
  psuId: number,

  drives: hdd[],
  ssds: ssd[],
}

export type caseRequest = {
  motherboardId: number,
  psuId: number,
  gpuId?: number | null,
}

export type computerView = {
  id: number;
  name: string,
  cpu: string,
  ram: string
}

import { ramSpeed } from "./ram.model";

export class mobo {
  id: number;
  name: string;
  model: string;
  chipset: string;
  maxMemory: number;
  m2Slots: number;
  sataSlots: number;
  ramSlots: number;
  description: string;

  caseSizeId: number;
  seriesId: number;
  socketCpuId: number;
  memories: ramSpeed[] = [];
}

export type addMobo = {
  id: number,
  name: string,
  model: string,
  chipset: string,
  maxMemory: number,
  m2Slots: number,
  sataSlots: number;
  ramSlots: number;
  description: string,

  caseSizeId: number,
  seriesId: number,
  socketCpuId: number,
  memories: ramSpeed[]
}

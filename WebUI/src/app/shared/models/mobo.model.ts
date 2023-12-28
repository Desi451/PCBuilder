export class mobo {
  id: number;
  name: string;
  model: string;
  chipset: string;
  maxMemory: number;
  m2Slots: number;
  sataSlots: number;
  description: string;

  caseSizeId: number;
  seriesId: number;
  socketCpuId: number;
  MemoryIds: number[] = [];
}

export type addMobo = {
  id: number,
  name: string,
  model: string,
  chipset: string,
  maxMemory: number,
  m2Slots: number,
  sataSlots: number;
  description: string,

  caseSizeId: number,
  seriesId: number,
  socketCpuId: number,
  MemoryIds: number[]
}

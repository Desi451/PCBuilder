export class mobo {
  id: number;
  name: string;
  model: string;
  chipset: string;
  maxMemory: number;
  m2Slots: number;
  caseSizeId: number;
  description: string;

  seriesId: number;
  socketCpuId: number;
}

export type addMobo = {
  id: number,
  name: string,
  model: string,
  chipset: string,
  maxMemory: number,
  m2Slots: number,
  caseSizeId: number,
  description: string,

  seriesId: number,
  socketCpuId: number
}

export class gpu {
  id: number;
  name: string;
  model: string;
  coreClock: string;
  memorySize: number;
  memoryInterface: number;
  memoryType: string;
  directX: string;
  opengGL: number;
  tdp: number;
  recommendedPsuPower: number;
  length: number;
  description: string;

  seriesId: number;
  chipsetSeriesId: number;
  socketCpuId: number
}

export type addGpu = {
  name: string,
  model: string,
  coreClock: string,
  memorySize: number,
  memoryInterface: number,
  memoryType: string,
  directX: string,
  opengGL: number,
  tdp: number,
  recommendedPsuPower: number,
  length: number,
  description: string,

  seriesId: number,
  chipsetSeriesId: number,
  socketCpuId: number
}

export class gpu {
  id: number;
  name: string;
  coreClock: string;
  memorySize: number;
  memoryInterface: number;
  memoryType: string;
  directX: string;
  openGL: number;
  tdp: number;
  recommendedPsuPower: number;
  length: number;
  description: string;

  seriesId: number;
  chipsetSeriesId: number;
}

export type addGpu = {
  name: string;
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
}

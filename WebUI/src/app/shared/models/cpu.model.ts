export class cpu {
  id: number;
  name: string;
  model: string;
  cores: string;
  threads: number;
  minFreq: number;
  maxFreq: number;
  l2Cache: number;
  l3Cache: number;
  maxRam: number;
  isApu: boolean;
  technology: number;
  tdp: number;
  description: string;

  seriesId: number;
  socketCpuId: number;
}

export class socketCpu {
  id: number;
  name: string;
  brandId: number;
}

export type addSocketCpu = {
  name: string;
  brandId: number;
}

export type addCpu = {
  name: string,
  model: string,
  cores: string,
  threads: number,
  minFreq: number,
  maxFreq: number,
  l2Cache: number,
  l3Cache: number,
  maxRam: number,
  isApu: boolean,
  technology: number, //nm
  tdp: number,
  description: string,

  seriesId: number,
  socketCpuId: number
}

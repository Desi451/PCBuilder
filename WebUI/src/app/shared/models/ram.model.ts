export class ram {
  id: number;
  name: string;
  model: string;
  capacity: number;
  noElements: number;
  description: string;
  latency: string;

  seriesId: number;
}

export type ramSpeed = {
  id: number,
  standard: string,
  freq: number
}

export type addRam = {
  id: number,
  name: string,
  model: string,
  capacity: number,
  noElements: number,
  description: string,
  latency: string,

  seriesId: number
}

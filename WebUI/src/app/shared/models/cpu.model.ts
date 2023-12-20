export type cpu = {
  id: number,
  name: string,
  model: string,
  cores: string,
  threads: number,
  minFreq: number,
  maxFreq: number,
  l2Cahe: number,
  l3Cache: number,
  maxRam: number,
  isApu: number,
  technology: number, //nm
  tdp: number,
  description: string,

  seriesId: number,
  socketCpuId: number
}

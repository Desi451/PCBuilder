export class psu {
  id: number;
  name: string;
  model: string;
  standard: string;
  power: number;
  fans: string;
  hasPFC: boolean;
  mainConnPins: string;
  pciExpressConn: string;
  voltage: string;
  freq: string;
  connectors: string;
  description: string;
  dimensions: string;

  seriesId: number;
}

export type addPsu = {
  name: string,
  model: string,
  standard: string,
  power: number,
  fans: string,
  hasPFC: boolean,
  mainConnPins: string,
  pciExpressConn: string,
  voltage: string,
  freq: string,
  connectors: string,
  description: string,
  dimensions: string,

  seriesId: number
}

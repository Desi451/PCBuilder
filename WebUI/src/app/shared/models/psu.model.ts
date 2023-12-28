export class psu {
  id: number;
  name: string;
  model: string;
  type: string;
  maxPower: number;
  Fans: string;
  hasPFC: boolean;
  MainConnPins: string;
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
  type: string,
  maxPower: number,
  Fans: string,
  hasPFC: boolean,
  MainConnPins: string,
  pciExpressConn: string,
  voltage: string,
  freq: string,
  connectors: string,
  description: string,
  dimensions: string,

  seriesId: number
}

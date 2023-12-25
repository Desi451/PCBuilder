export class hdd {
  id: number;
  name: string;
  model: string;
  capacity: number;
  rpm: number;
  description: string;
  cache: number;

  seriesId: number;
  slotInterfaceId: number;
}

export type addHdd = {
  name: string,
  model: string,
  capacity: number,
  rpm: number,
  description: string
  cache: number,

  seriesId: number,
  slotInterfaceId: number
}

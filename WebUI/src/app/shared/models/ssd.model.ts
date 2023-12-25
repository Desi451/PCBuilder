export class ssd {
  id: number;
  name: string;
  model: string;
  capacity: number;
  maxRead: number;
  description: string;
  maxWrite: number;

  seriesId: number;
  slotInterfaceId: number;
}

export type addSsd = {
  name: string,
  model: string,
  capacity: number,
  maxRead: number,
  description: string
  maxWrite: number,

  seriesId: number,
  slotInterfaceId: number
}

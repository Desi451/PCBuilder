
export class casePc {
  id: number;
  name: string;
  model: string;
  height: number;
  width: number;
  deepth: number;
  description: string;

  caseSizeId: number;
  seriesId: number;
}

export type addCase = {
  name: string;
  model: string;
  height: number;
  width: number;
  deepth: number;
  description: string;

  caseSizeId: CaseSizes;
  seriesId: number;
}

export enum CaseSizes {
  EATX = 0,
  ATX = 1,
  ITXMicroATX = 2,
  ITX = 3,
}

export interface CaseSize {
  name: string;
  value: number;
}


export class casePc {
  id?: number;
  name!: string;
  model!: string;
  height!: number;
  width!: number;
  deepth!: number;
  description!: string;

  caseSizeId!: CaseSizes;
  seriesId!: number;
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
  ATX = 0,
  ITX = 1,
  MicroATX = 2,
  EATX = 3
}

export interface CaseSize {
  name: string;
  value: number;
}

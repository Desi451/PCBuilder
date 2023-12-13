
export class casePc {
  id?: number;
  name!: string;
  model!: string;
  height!: number;
  width!: number;
  deepth!: number;
  description!: string;

  caseSizeId!: number;
  seriesId!: number;
}

export type addCase = {
  name: string;
  model: string;
  height: number;
  width: number;
  deepth: number;
  description: string;

  caseSizeId: number;
  seriesId: number;
}

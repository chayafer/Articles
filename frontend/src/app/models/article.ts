export interface Article {
  id: number;
  image: string;
  title: string;
  description: string;
  isFavorite: boolean;
  categoryId:number;
}


export interface Category {
  id: number;
  name: string;
  icon: string;
}

export enum ListMode {
  Category = 0,
  favorites = 1
}

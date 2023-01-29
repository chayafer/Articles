import { Component, Input } from '@angular/core';
import {Article, ListMode } from 'src/app/models/article';
import { ArticleService } from 'src/app/services/article.service';
import { FavoriteService } from 'src/app/services/favorite.service';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss']
})
export class ArticleComponent {

  @Input() article!: Article;
  @Input() mode!: ListMode;

  favoritesMode = ListMode.favorites;

  constructor(private articleService: ArticleService,
    private favoritesService: FavoriteService) {
  }

  addTofavorite(article: Article) {
    article.isFavorite=true;
    this.favoritesService.addToFavourite(article.id);
  }

  removeFromFavorite(article: Article) {
    article.isFavorite=false;
    this.favoritesService.removeFromFavourite(article.id);
  }
}

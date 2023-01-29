import { Component, Input } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { ListMode } from 'src/app/models/article';
import { ArticleService } from 'src/app/services/article.service';
import { FavoriteService } from 'src/app/services/favorite.service';

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.scss']
})
export class ArticleListComponent {
  sub: any;
  categoryId: string | null | undefined;
  articles: any;
  listMode!: ListMode;
  
  @Input() mode!: ListMode;

  constructor(private activatedroute: ActivatedRoute,private router:
    Router,private articlesService : ArticleService, private favoritesService: FavoriteService) {

   }

   ngOnInit() {
    this.sub = this.activatedroute.paramMap.subscribe((params) => {

      let categoryId = params.get('id');
      if(categoryId){
         this.articles = this.articlesService.getArticles(categoryId);
      }
      else{
        this.articles = this.favoritesService.getFavouritesArticles();

      }


      //this.product = products.find((p) => p.productID == this.id);
    });

    //You can also use this
    //this.sub=this._Activatedroute.params.subscribe(params => {
    //    this.id = params['id'];
    //    let products=this._productService.getProducts();
    //    this.product=products.find(p => p.productID==this.id);
    //});
  }

  ngOnDestroy() {
    if (this.sub) this.sub.unsubscribe();
  }

  onBack(): void {
    this.router.navigate(['product']);
  }

}


import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArticleListComponent } from './components/article-list/article-list.component';
import { ArticleComponent } from './components/article/article.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: '',   component: HomeComponent },
  { path: 'home',   component: HomeComponent },
  { path: 'article-list', component: ArticleListComponent },
  { path: 'article-list/:id', component: ArticleListComponent },
  { path: 'article-list/:id/:type', component: ArticleListComponent },
  { path: 'article', component: ArticleComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

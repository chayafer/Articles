import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';
import {Article,  Category } from '../models/article';
import { CoreService } from './core.service';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  constructor(private http: HttpClient, private coreService: CoreService) { }

  getCategories(): Observable<Category> {
    return this.http.get<Category>(`${this.coreService.baseUrl}GetCategories`).pipe(
      catchError(this.coreService.handleError));
  }

  getArticles(categoryId: string | null): Observable<Article> {
    let url = `${this.coreService.baseUrl}Articles/GetArticles`;
    if (categoryId) {
      url += `/${categoryId}`;
    }
    return this.http.get<Article>(url);
  }

}

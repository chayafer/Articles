import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { debounceTime, map, filter, switchMap, retry, catchError } from 'rxjs/operators';
import {Article} from '../models/article';
import { CoreService } from './core.service';

@Injectable({
  providedIn: 'root'
})
export class FavoriteService {

  private favoritesSubject = new BehaviorSubject<Article[]>([]);

  favorites$ = this.favoritesSubject.asObservable();

  constructor(private http: HttpClient, private coreService: CoreService) { }

  addToFavourite(id: number) {
    let url = `${this.coreService.baseUrl}Favorite/Add/${id}`;

    return this.http.put<Article[]>(url,{}).pipe(
      catchError(this.coreService.handleError)).subscribe(newValue => {
        this.favoritesSubject.next(newValue);
      });
  }

  removeFromFavourite(id: number) {
    let url = `${this.coreService.baseUrl}Favorite/Remove/${id}`;

    return this.http.delete<Article[]>(url).pipe(
      catchError(this.coreService.handleError)).subscribe(newValue => {
        this.favoritesSubject.next(newValue);
      });
  }

  private getArticles(): void {
    let url = 'http://localhost:5249/Favorite/GetArticles';

    this.http.get<Article[]>(url).pipe(
      catchError(this.coreService.handleError)).subscribe(newValue => {
        this.favoritesSubject.next(newValue);
      });
  }


  getFavouritesArticles(): Observable<Article[]> {
    if(this.favoritesSubject.value.length==0){
      this.getArticles();
    }
    return this.favorites$;
  }
}

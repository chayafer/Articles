import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import  {  Category } from 'src/app/models/article';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent {

  @Input() categories!: any

  constructor(private http:HttpService){

  }

  ngOnInit(){
    this.categories= this.http.getCategories()
  }

}

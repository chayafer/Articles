import { Component } from '@angular/core';
import { ListMode } from 'src/app/models/article';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  tabIndex : Tabs = Tabs.Categories;
  favoritesMode = ListMode.favorites;

  ngOnInit(){
    this.setTab(Tabs.Categories);
  }

  setTab(tab : Tabs){
    this.tabIndex = tab;
  }
}

enum Tabs{
  Categories = 0,
  favorites = 1
}

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { from } from 'rxjs';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { MainContainerComponent } from './main-container/main-container.component';
import { SubmenuComponent } from './submenu/submenu.component';
import { HistoryTableComponent } from './history-table/history-table.component';
@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    MainContainerComponent,
    SubmenuComponent,
    HistoryTableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

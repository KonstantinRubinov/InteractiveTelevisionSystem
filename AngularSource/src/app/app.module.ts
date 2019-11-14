import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './modules/app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { EmbedVideo } from 'ngx-embed-video';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { ImageService } from './services/image.service';

import {NgRedux, NgReduxModule} from "ng2-redux";
import { Store } from './redux/store';
import { Reducer } from './redux/reducer';

import { HeaderComponent } from './components/design-elements/header/header.component';
import { FooterComponent } from './components/design-elements/footer/footer.component';

import { MainvideoComponent } from './components/data-elements/home/mainvideo/mainvideo.component';
import { WatchvideosComponent } from './components/data-elements/home/watchvideos/watchvideos.component';
import { WatchTonightComponent } from './components/data-elements/home/watch-tonight/watch-tonight.component';
import { LatestVideosComponent } from './components/data-elements/home/latest-videos/latest-videos.component';
import { HomepageComponent } from './components/data-elements/home/homepage/homepage.component';
import { ComNewSectionComponent } from './components/data-elements/home/com-new-section/com-new-section.component';
import { CommercialComponent } from './components/data-elements/home/commercial/commercial.component';
import { WhatNewComponent } from './components/data-elements/home/what-new/what-new.component';

import { ProgramsComponent } from './components/data-elements/programsPage/programs/programs.component';
import { ProgramsAllComponent } from './components/data-elements/programsPage/programs-all/programs-all.component';
import { ProgramsByDateComponent } from './components/data-elements/programsPage/programs-by-date/programs-by-date.component';

import { NewsComponent } from './components/data-elements/newsPage/news/news.component';
import { NewsPreferedComponent } from './components/data-elements/newsPage/news-prefered/news-prefered.component';
import { NewsSportComponent } from './components/data-elements/newsPage/news-sport/news-sport.component';
import { NewsImportantComponent } from './components/data-elements/newsPage/news-important/news-important.component';



import { BlogComponent } from './components/data-elements/blogPage/blog/blog.component';



import { ContactComponent } from './components/data-elements/contactsPage/contact/contact.component';
import { FindUsComponent } from './components/data-elements/contactsPage/find-us/find-us.component';
import { ContactUsComponent } from './components/data-elements/contactsPage/contact-us/contact-us.component';
import { BlogCategoriesComponent } from './components/data-elements/blogPage/blog-categories/blog-categories.component';
import { BlogArchivesComponent } from './components/data-elements/blogPage/blog-archives/blog-archives.component';
import { BlogLastPostsComponent } from './components/data-elements/blogPage/blog-last-posts/blog-last-posts.component';
import { MorePopupComponent } from './components/data-elements/more-popup/more-popup.component';
import { LayoutComponent } from './components/design-elements/layout/layout.component';








@NgModule({
  declarations: [
    LayoutComponent,
    HeaderComponent,
    FooterComponent,
    MainvideoComponent,
    WatchvideosComponent,
    WatchTonightComponent,
    LatestVideosComponent,
    ProgramsComponent,
    NewsComponent,
    BlogComponent,
    ContactComponent,
    HomepageComponent,
    ComNewSectionComponent,
    CommercialComponent,
    WhatNewComponent,
    ProgramsAllComponent,
    ProgramsByDateComponent,
    NewsPreferedComponent,
    NewsSportComponent,
    NewsImportantComponent,
    FindUsComponent,
    ContactUsComponent,
    BlogCategoriesComponent,
    BlogArchivesComponent,
    BlogLastPostsComponent,
    MorePopupComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgReduxModule,
    EmbedVideo.forRoot()
  ],
  // providers: [NgxSmartModalService],
  bootstrap: [LayoutComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA, ImageService]
})
export class AppModule { 
  public constructor(redux:NgRedux<Store>){
      redux.configureStore(Reducer.reduce, new Store())
  }
}

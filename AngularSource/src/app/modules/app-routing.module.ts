import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomepageComponent }  from '../components/data-elements/home/homepage/homepage.component';
import { ProgramsComponent }  from '../components/data-elements/programsPage/programs/programs.component';
import { NewsComponent }  from '../components/data-elements/newsPage/news/news.component';
import { BlogComponent }  from '../components/data-elements/blogPage/blog/blog.component';
import { ContactComponent }  from '../components/data-elements/contactsPage/contact/contact.component';

const routes: Routes = [
  { path: '', redirectTo: '/homepage', pathMatch: 'full' },
  { path: 'homepage', component: HomepageComponent },
  { path: 'programs', component: ProgramsComponent },
  { path: 'news', component: NewsComponent },
  { path: 'blog', component: BlogComponent },
  { path: 'contact', component: ContactComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }






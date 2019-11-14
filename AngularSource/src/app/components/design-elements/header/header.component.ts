import { Component, OnInit} from '@angular/core';
import { Navigator } from 'src/app/models/navigator';
import { TranslationService } from 'src/app/services/basics/translation.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  
  constructor(private translationService: TranslationService) { }

  ngOnInit() {
    this.setTranslations();
  }
  
  private setTranslations(){

    let i:number;
    for (i=0;i<this.translationKeys.length;i++){
      this.navigators[i].linkName = this.translationService.GetTranslatioFromDictionaryByKey(this.translationKeys[i]);
    }

    this.search_btn_text = this.translationService.GetTranslatioFromDictionaryByKey('header-search');
    this.signup_text = this.translationService.GetTranslatioFromDictionaryByKey('header-signUp');
    this.signin_text = this.translationService.GetTranslatioFromDictionaryByKey('header-signIn');
  }

  navigators = [
    new Navigator("/homepage", ''),
    new Navigator("/programs", ''),
    new Navigator("/news", ''),
    new Navigator("/blog", ''),
    new Navigator("/contact", '')
  ];
  
  search_btn_text='';
  signup_text='';
  signin_text='';

  translationKeys = ['header-nav-homePage',
                     'header-nav-programs',
                     'header-nav-news',
                     'header-nav-blog',
                     'header-nav-contacts'];

}

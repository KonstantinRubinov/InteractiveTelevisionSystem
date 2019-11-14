import { Component, OnInit } from '@angular/core';
import { ImportantNews } from 'src/app/models/important_news';
import { TranslationService } from 'src/app/services/basics/translation.service';
import { LogService } from 'src/app/services/log.service';

@Component({
  selector: 'app-news-important',
  templateUrl: './news-important.component.html',
  styleUrls: ['./news-important.component.css']
})
export class NewsImportantComponent implements OnInit {

  constructor(private translationService: TranslationService, private logger: LogService) { }

  ngOnInit() {
    this.setTranslations();
  }

  private setTranslations(){
    this.important_news_title=this.translationService.GetTranslatioFromDictionaryByKey('section-highlights');
  }

  important_news_title='';

  important_news_array = [
    new ImportantNews('0', '../../assets/images/pic1.png'),
    new ImportantNews('1', '../../assets/images/pic2.png'),
    new ImportantNews('2', '../../assets/images/pic3.png'),
  ];

  changeOnePictureRight(){
    let i;
    let tempImportantNews=this.important_news_array[0];
    for (i=0;i<this.important_news_array.length;i++){

      if (i+1<this.important_news_array.length){
        this.important_news_array[i]=this.important_news_array[i+1];
      }
      
    }
    this.important_news_array[this.important_news_array.length-1] = tempImportantNews;
    this.logger.debug("NewsImportant: ", "changeOnePictureRight clicked");
  }

  changeOnePictureLeft(){
    let i;
    let tempImportantNews=this.important_news_array[this.important_news_array.length-1];
    for (i=this.important_news_array.length-1;i>=0;i--){

      if (i-1>=0){
        this.important_news_array[i]=this.important_news_array[i-1];
      }
      
    }
    this.important_news_array[0] = tempImportantNews;
    this.logger.debug("NewsImportant: ", "changeOnePictureLeft clicked");
  }

}

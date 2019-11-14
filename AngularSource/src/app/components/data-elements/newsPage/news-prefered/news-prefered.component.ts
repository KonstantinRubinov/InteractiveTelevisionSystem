import { Component, OnInit, VERSION } from '@angular/core';
import { NewsPrefered } from 'src/app/models/news_prefered';
import { TranslationService } from 'src/app/services/basics/translation.service';

@Component({
  selector: 'app-news-prefered',
  templateUrl: './news-prefered.component.html',
  styleUrls: ['./news-prefered.component.css']
})
export class NewsPreferedComponent implements OnInit {
  version = VERSION.full;
  constructor(private translationService: TranslationService) { }

  ngOnInit() {
    this.setTranslations();
  }

  private setTranslations(){
    this.prefered_news_title=this.translationService.GetTranslatioFromDictionaryByKey('section-preferedNews');
    this.data_button=this.translationService.GetTranslatioFromDictionaryByKey('button-more');
  }

  prefered_news_title='';
  data_button='';
  
  
  
  dateNow  = Date.now();
  

  prefered_news_array = [
    new NewsPrefered('0', this.dateNow, 'מחיר קפה עולה', 'לשון שאלות קרן אם. צעד ישראל ננקטת ב, את הראשי בדפים וכמקובל בדף. זכר לחבר והוא מדינות דת, פנאי רביעי תרבות כתב אם. שדרות הבקשה.', '../../assets/images/featured_new_picture1.png', 'נכתב ב'),
    new NewsPrefered('1', this.dateNow, 'ביטוח בריאות', 'בדף בה ויקי הגרפים ופיתוחה, ישראל גיאוגרפיה אם רבה. מתן לחשבון אווירונאוטיקה דת, לשון ביולי דת תנך, ב מדעי עזרה החב.', '../../assets/images/featured_new_picture2.png', 'נכתב ב'),
    new NewsPrefered('2', this.dateNow, 'הסוסים המהירים', 'אל קרן לחבר הארץ קבלו. תנך על קבלו קהילה ביולוגיה, ביולוגיה היסטוריה שתי אל, אם ויש החלל ליצירתה. שתי על מדעי עמוד ציו', '../../assets/images/featured_new_picture3.png', 'נכתב ב')
  ];

  public DataToModal(data){
    this.my_data_to_popup = data;
  }

  public my_data_to_popup:NewsPrefered=this.prefered_news_array[0];

}

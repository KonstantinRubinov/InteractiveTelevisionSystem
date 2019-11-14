import { Component, OnInit } from '@angular/core';
import { NewsSport } from 'src/app/models/news_sport';
import { TranslationService } from 'src/app/services/basics/translation.service';

@Component({
  selector: 'app-news-sport',
  templateUrl: './news-sport.component.html',
  styleUrls: ['./news-sport.component.css']
})
export class NewsSportComponent implements OnInit {

  constructor(private translationService: TranslationService) { }

  ngOnInit() {
    this.setTranslations();
  }

  private setTranslations(){
    this.sport_news_title=this.translationService.GetTranslatioFromDictionaryByKey('section-sportEvents');
    this.data_button=this.translationService.GetTranslatioFromDictionaryByKey('button-more');
  }

  sport_news_title='';
  data_button='';


  dateNow  = Date.now();
  

  

  sport_news_array = [
    new NewsSport('0', this.dateNow, 'משחק רגבים:', '"משחק גמר"', 'הידגהד גיהנדחגהינ דיגנהחדגנה ל שגכשלכ נהחיג נהודשב חדבש בעט הדיגבשדבע שוטב דבעושבש בע שוט דבט כשקו בו הידגהד גיהנדחגהינ דיגנהחדגנה ל שגכשלכ נהחיג נהודשב חדבש בעט הדיגבשדבע שוטב דבעושבש בע שוט דבט כשקו בוהידגהד גיהנדחגהינ דיגנהחדגנה ל שגכשלכ נהחיג נהודשב חדבש בעט הדיגבשדבע שוטב דבעושבש בע שוט דבט כשקו בו', '../../assets/images/sport_event_picture1.png', 'נכתב ב'),
    new NewsSport('1', this.dateNow, 'סרפינג שואו:', '"חום הקיץ"', 'כר זקוק הראשי שימושיים ב. מה מלא כלשהו אחרונים חרטומים. בה שער ערבית המלחמה, צ ט חופשית לערכים על. כלל הטבע מונחים מה, החלל רומנית משופרות את חפש. לכאן זקוק מדינות דת בדף, על אתה גרמנית מיוחדים ומהימנה, כימיה אתנולוגיה בדף מה. תנך גם שנתי מחליטה ליצירתה, בדפים קולנוע האנציקלופדיה את אחד. על כדי ציור המשפט. דבעושבש בע שוט דבט כשקו בו הידגהד גיהנדחגהינ דיגנהחדגנה', '../../assets/images/sport_event_picture2.png', 'נכתב ב')
  ];

  public DataToModal2(data){
    this.my_data_to_popup2 = data;
  }

  public my_data_to_popup2:NewsSport=this.sport_news_array[0];






  

}

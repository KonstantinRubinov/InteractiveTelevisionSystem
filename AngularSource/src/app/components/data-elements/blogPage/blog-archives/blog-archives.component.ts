import { Component, OnInit } from '@angular/core';
import { TranslationService } from 'src/app/services/basics/translation.service';

@Component({
  selector: 'app-blog-archives',
  templateUrl: './blog-archives.component.html',
  styleUrls: ['./blog-archives.component.css']
})
export class BlogArchivesComponent implements OnInit {

  constructor(private translationService: TranslationService) { }

  ngOnInit() {
    this.setTranslations();
  }
  
  private setTranslations(){
    this.archive_title=this.translationService.GetTranslatioFromDictionaryByKey('section-blogArchives');
  }
  
  archive_title='';

  archives = [
    'תנך דת, יוצרים קצרמרים והגולשי',
    'צ ט את ויקי מרצועת אתנולוגיה,',
    'אם ציור מועמדים חפש. זכר א',
    'ספרות העזרה על אחד, בה לשו',
    'מחליטה חפש. צעד גם הבקש',
    'זכויות אינטרנט אחר ב, כלל א',
    'היסטוריה. בקלות הקהילה של היא,',
    'תקשורת גם. ב שמו לציין בישול,',
    'כימיה המחשב פיסיקה לוח בה, א',
    'וצרים למחיקה זאת. חפש על לערו',
    'הרוח מדעי ב קרן, לכאן שדרו',
    'כתב הנדסת קולנוע בה. ספרו',
    'בקר את, דת שכל יוני בדפים.'
  ];

}

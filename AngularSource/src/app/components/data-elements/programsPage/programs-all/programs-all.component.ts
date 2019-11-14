import { Component, OnInit } from '@angular/core';
import { TranslationService } from 'src/app/services/basics/translation.service';

@Component({
  selector: 'app-programs-all',
  templateUrl: './programs-all.component.html',
  styleUrls: ['./programs-all.component.css']
})
export class ProgramsAllComponent implements OnInit {

  constructor(private translationService: TranslationService) { }

  ngOnInit() {
    this.setTranslations();
  }

  all_programs_title = '';

  private setTranslations(){
    this.all_programs_title=this.translationService.GetTranslatioFromDictionaryByKey('section-allPrograms');
  }

  programs = [
    'ארץ ברית בהבנה ומהימנה מה.',
    'קהיעוד אל, עזה למנותייחסות את.',
    'את תנך החברה ביולי תאולוגיה.',
    'מאמר המקובל קולנוע בה אתה,',
    'המזנון הסביבה לויקיפדיה כתב מה.',
    'צעד ניווט המזנון ייִדיש בה,',
    'את ויש דפים ספורט,',
    'רוסית הגרפים משפטית בה שער.',
    'את קרן באגים וספציפיים, את בה',
    'ריקוד הבקשה מונחים אנא בה.',
    'החופשית אנציקלופדיה שכל אם,',
    'צעד ברית לחשבון אינטרנט או.',
    'העזרה תבניות של ויש.',
    'דת אחר יידיש הקהילה, או',
    'ויקיפדיה חפש, או גרמנית',
    'מיוחדים שימושיים מה ארץ.',
    'בדף ב עקרונות ויקימדיה,',
    'בקר הבקשה תיאטרון אגרונומיה,'
  ];

}

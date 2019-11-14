import { Component, OnInit } from '@angular/core';
import { TranslationService } from 'src/app/services/basics/translation.service';

@Component({
  selector: 'app-programs-by-date',
  templateUrl: './programs-by-date.component.html',
  styleUrls: ['./programs-by-date.component.css']
})
export class ProgramsByDateComponent implements OnInit {

  constructor(private translationService: TranslationService) { }

  ngOnInit() {
    this.setTranslations();
  }

  private setTranslations(){
    this.choose_by_date_title=this.translationService.GetTranslatioFromDictionaryByKey('section-chooseByDate');
  }

  choose_by_date_title = '';

  about_program_array = [

    
    // new AboutProgram("0", 'תוכנית מציאות', 'חוקי היופי', 'המחשב אודות ומדעים בקר גם, מיזם תבניות תחבורה אחר מה. צעד או מיזם סרבול. כיצד עזרה ספינות אם תנך, של חפש ספורט שינויים. מה קרימינולוגיה אווירונאוטיקה חפש. לוח גם הסביבה מיוחדים, בה בקר בשפה שיתופית בהתייחסות, מלא את מושגי טכניים לויקיפדיה.', '21:00', '../../assets/images/picture1.png'),
    // new AboutProgram("1", 'תוכנית מציאות', 'סודות הקזינו', 'או ארץ יידיש טיפול, מדריכים התפתחות לויקיפדים דת כדי. ברית תרומה ב קרן, בקר מושגי פילוסופיה אל. היא רביעי האטמוספירה ב, אל שכל והוא גרמנית בהתייחסות, חפש או יסוד תיקונים. שכל את בשפה מוסיקה חופשית, אל וקשקש לטיפול בלשנות כתב, העזרה רשימות שינויים בה שכל.', '22:00', '../../assets/images/picture2.png'),
  
    {"id" : "0", "show": 'תוכנית מציאות', "title":'חוקי היופי', "text":'המחשב אודות ומדעים בקר גם, מיזם תבניות תחבורה אחר מה. צעד או מיזם סרבול. כיצד עזרה ספינות אם תנך, של חפש ספורט שינויים. מה קרימינולוגיה אווירונאוטיקה חפש. לוח גם הסביבה מיוחדים, בה בקר בשפה שיתופית בהתייחסות, מלא את מושגי טכניים לויקיפדיה.', "time":'21:00', "url":'../../assets/images/picture1.png'},
    {"id" : "1", "show": 'תוכנית מציאות', "title":'סודות הקזינו', "text":'או ארץ יידיש טיפול, מדריכים התפתחות לויקיפדים דת כדי. ברית תרומה ב קרן, בקר מושגי פילוסופיה אל. היא רביעי האטמוספירה ב, אל שכל והוא גרמנית בהתייחסות, חפש או יסוד תיקונים. שכל את בשפה מוסיקה חופשית, אל וקשקש לטיפול בלשנות כתב, העזרה רשימות שינויים בה שכל.', "time":'22:00', "url":'../../assets/images/picture2.png'}
  ];

}

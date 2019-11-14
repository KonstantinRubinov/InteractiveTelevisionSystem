import { Component, OnInit } from '@angular/core';
import { TranslationService } from 'src/app/services/basics/translation.service';

@Component({
  selector: 'app-blog-categories',
  templateUrl: './blog-categories.component.html',
  styleUrls: ['./blog-categories.component.css']
})
export class BlogCategoriesComponent implements OnInit {

  constructor(private translationService: TranslationService) { }

  ngOnInit() {
    this.setTranslations();
  }

  private setTranslations(){
    this.categories_title=this.translationService.GetTranslatioFromDictionaryByKey('section-blogCategories');
  }
  
  categories_title='';

  categories = [
    'הסביבה מדריכים ואלקטרוניקה מה.',
    'בה בדף הטבע ציור מבוקשים,',
    'טיפול אווירונאוטיקה זאת. אנ',
    'המלצת משחקים גם. מדע לכא',
    'חרטומים דת, דת סדר מיותר רומני',
    'יידיש אחרות קרימינולוגיה א',
    'כדי גם יידיש קולנוע משפטית, ע',
    'טבלאות, דפים עסקים דת סדר.',
    'את נפלו ברוכים לחשבון מדע,',
    'עזה גם אחרות תחבורה, בה צע',
    'רקטות בדפים צ ט של, ננקטת',
    'קלאסיים אנא מה. ציור לטיפול'
  ];

  

}

import { Component, OnInit } from '@angular/core';
import { TranslationService } from 'src/app/services/basics/translation.service';

@Component({
  selector: 'app-find-us',
  templateUrl: './find-us.component.html',
  styleUrls: ['./find-us.component.css']
})
export class FindUsComponent implements OnInit {

  constructor(private translationService: TranslationService) { }

  ngOnInit() {
    this.setTranslations();
  }

  private setTranslations(){
    this.find_us_title=this.translationService.GetTranslatioFromDictionaryByKey('section-findUs');
  }

  find_us_title='';

  cityStreet='תל אביב, הרצל 54';
  country='54321 ישראל';

  freephone='Freephone: +1 800 559 6580';
  telephone='Telephone: +1 959 603 6035';
  fax='FAX: +1 504 889 9898';
  mail='E-mail: mail@demolink.org';

}

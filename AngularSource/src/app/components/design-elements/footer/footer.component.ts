import { Component, OnInit } from '@angular/core';
import { TranslationService } from 'src/app/services/basics/translation.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  constructor(private translationService: TranslationService) { }

  ngOnInit() {
    this.setTranslations();
  }

  private setTranslations(){
    let i:number;
    for (i=0;i<this.translationKeys.length;i++){
      this.footerNavigators[i] = this.translationService.GetTranslatioFromDictionaryByKey(this.translationKeys[i]);
    }
    
    this.footerUlNavigators[0] = [this.footerNavigators[0], this.footerNavigators[1], this.footerNavigators[2], this.footerNavigators[3]];
    this.footerUlNavigators[1] = [this.footerNavigators[4], this.footerNavigators[5], this.footerNavigators[6], this.footerNavigators[7]];
    this.footerUlNavigators[2] = [this.footerNavigators[8], this.footerNavigators[9], this.footerNavigators[10], this.footerNavigators[11]];
    this.footerUlNavigators[3] = [this.footerNavigators[12], this.footerNavigators[13], this.footerNavigators[14], this.footerNavigators[15]];
    this.footerUlNavigators[4] = [this.footerNavigators[16], this.footerNavigators[17], this.footerNavigators[18], this.footerNavigators[19]];
  
  }



  translationKeys = ['footer-nav-homePage',
                     'footer-nav-television',
                     'footer-nav-radio',
                     'footer-nav-production',
                     'footer-nav-support',
                     'footer-nav-FAQs',
                     'footer-nav-usageRules',
                     'footer-nav-policy',
                     'footer-nav-journalism',
                     'footer-nav-communication',
                     'footer-nav-careers',
                     'footer-nav-aboutUs',
                     'footer-nav-digitalMedia',
                     'footer-nav-ourTeam',
                     'footer-nav-events',
                     'footer-nav-advertisers',
                     'footer-nav-broadcastMode',
                     'footer-nav-broadcastQuality',
                     'footer-nav-businessOffers',
                     'footer-nav-worldBroadcast'];

  footerNavigators = [];
  footerUlNavigators = [];
}

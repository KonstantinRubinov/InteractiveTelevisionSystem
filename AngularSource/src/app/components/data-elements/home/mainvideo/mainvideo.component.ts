import { Component, OnInit, ElementRef  } from '@angular/core';
import { TranslationService } from 'src/app/services/basics/translation.service';
import { LogService } from 'src/app/services/log.service';

@Component({
  selector: 'app-mainvideo',
  templateUrl: './mainvideo.component.html',
  styleUrls: ['./mainvideo.component.css']
})
export class MainvideoComponent implements OnInit {
  constructor(private hostElement:ElementRef,
              private translationService: TranslationService,
              private logger: LogService) { }

  ngOnInit() {
    this.setTranslations();
    this.showVideo();
  }

  private setTranslations(){
    let i:number;
    for (i=0;i<this.translationKeys.length;i++){
      this.text_in_table[i] = this.translationService.GetTranslatioFromDictionaryByKey(this.translationKeys[i]);
    }
  }

  translationKeys = ['program-nav-sport',
                     'program-nav-music',
                     'program-nav-video',
                     'program-nav-education',
                     'program-nav-game',
                     'program-nav-talkshow',
                     'program-nav-analytics'];

  text_in_table = [];

  videoUrls = [
    'https://www.youtube.com/embed/Hm3LtRyX9WA',
    'https://www.youtube.com/embed/W1TGrIJKMjg'
  ];
  
  welcome_first:string ='ברוכים הבאים לאתר"TV.CO.IL"!';
  welcome_text:string ='האתר הראשון, שבו אתה לא אורח, אך אדון מן המניין. זה מקום שבו כל אחד מכם יכול לא רק להכיר את התוכן הווידאו שלנו, אלא גם כדי לשלוט בו! רק בלחיצת אחד על כפתור - ואתה שולט בגיבורי הסרטים, שחקנים של וידיאוקליפים, מובילים של תוכניות. כל זה ועוד הרבה רק באתר אינטראקטיבי שלנו. כנס ותרגיש בבית.';

  
  private i=0;
  
  changeVideoRight(){
    this.i++;
    if(this.i>this.videoUrls.length-1){
      this.i=0;
    }
    this.showVideo()
    this.logger.debug("Mainvideo: ", "changeVideoRight clicked");
  }

  changeVideoLeft(){
    this.i--;
    if(this.i<0){
      this.i=this.videoUrls.length-1;
    }
    this.showVideo()
    this.logger.debug("Mainvideo: ", "changeVideoLeft clicked");
  }

  showVideo(){
    let iframe = this.hostElement.nativeElement.querySelector('iframe');
    iframe.src = this.videoUrls[this.i];
    this.logger.debug("Mainvideo: ", "showVideo clicked");
  }
  
  
  changeToMusic(){
    let iframe = this.hostElement.nativeElement.querySelector('iframe');
    iframe.src = "https://www.youtube.com/embed/EX_7NLVYIR4";
    this.logger.debug("Mainvideo: ", "changeToMusic clicked");
  }
  
  
  changeToMovie(){
    let iframe = this.hostElement.nativeElement.querySelector('iframe');
    iframe.src = "https://www.youtube.com/embed/Hm3LtRyX9WA";
    this.logger.debug("Mainvideo: ", "changeToMovie clicked");
  }
  
  
  changeToStudy(){
    let iframe = this.hostElement.nativeElement.querySelector('iframe');
    iframe.src = "https://www.youtube.com/embed/W1TGrIJKMjg";
    this.logger.debug("Mainvideo: ", "changeToStudy clicked");
  }

}
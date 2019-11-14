import { Component, OnInit } from '@angular/core';
import { WatchTonight } from 'src/app/models/watch_tonight';
import { TranslationService } from 'src/app/services/basics/translation.service';
import { LogService } from 'src/app/services/log.service';

@Component({
  selector: 'app-watch-tonight',
  templateUrl: './watch-tonight.component.html',
  styleUrls: ['./watch-tonight.component.css']
})
export class WatchTonightComponent implements OnInit {
  constructor(private translationService: TranslationService, private logger: LogService) { }

  ngOnInit() {
    this.setTranslations();
  }

  private setTranslations(){
    this.watch_tonight_title=this.translationService.GetTranslatioFromDictionaryByKey('section-watchTonight');
  }

  watch_tonight_title ='';

  watch_tonight_bottom_array = [
    new WatchTonight('19:00', 'מיותר בהיסטוריה מה סדר, מושגי ואמנות על זכר.'),
    new WatchTonight('20:00', 'לחבר מועמדים הגולשות אם מתן. אנא בה בכפוף פילוסופיה, כלל'),
    new WatchTonight('21:00', 'סרבול העמוד אווירונאוטיקה גם, עזה ליום תיאטרון בה.'),
    new WatchTonight('22:00', 'שתפו בהבנה לויקיפדיה שמו אם, שדרות ביוני אודות קרן גם.')
  ];

  
  
  changeTextRight(){
    let i;
    let tempWatchTonight=this.watch_tonight_bottom_array[0];
    for (i=0;i<this.watch_tonight_bottom_array.length;i++){

      if (i+1<this.watch_tonight_bottom_array.length){
        this.watch_tonight_bottom_array[i]=this.watch_tonight_bottom_array[i+1];
      }
      
    }
    this.watch_tonight_bottom_array[this.watch_tonight_bottom_array.length-1] = tempWatchTonight;
    this.logger.debug("WatchTonight: ", "changeTextRight clicked");
  }

  changeTextLeft(){
    let i;
    let tempWatchTonight=this.watch_tonight_bottom_array[this.watch_tonight_bottom_array.length-1];
    for (i=this.watch_tonight_bottom_array.length-1;i>=0;i--){

      if (i-1>=0){
        this.watch_tonight_bottom_array[i]=this.watch_tonight_bottom_array[i-1];
      }
      
    }
    this.watch_tonight_bottom_array[0] = tempWatchTonight;
    this.logger.debug("WatchTonight: ", "changeTextLeft clicked");
  }

}

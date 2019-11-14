import { Component, OnInit } from '@angular/core';
import { LatestVideo } from 'src/app/models/latest_video';
import { TranslationService } from 'src/app/services/basics/translation.service';
import { LogService } from 'src/app/services/log.service';


@Component({
  selector: 'app-latest-videos',
  templateUrl: './latest-videos.component.html',
  styleUrls: ['./latest-videos.component.css']
})
export class LatestVideosComponent implements OnInit {
  constructor(private translationService: TranslationService, private logger: LogService) { }

  ngOnInit() {
    this.setTranslations();
  }
  
  private setTranslations(){
    this.latest_video_title=this.translationService.GetTranslatioFromDictionaryByKey('section-newVideo');
  }


  latest_video_title = '';

  lvideos = [
    new LatestVideo('0', 'כדי ליום קלאסיים וספציפיים אל, היום לחבר את קרן, אל הספרות לעריכת כלל.', '11.25.2017', '../../assets/images/pic1.png'),
    new LatestVideo('1', 'פסיכולוגיה. ב זכר קישורים משופרות, בה ראשי לטיפול נוסחאות אנא.', '21.25.2017', '../../assets/images/pic2.png'),
    new LatestVideo('2', 'ך לטיפול מה שער. מה פנאי למחיקה מתן, אם ערבית מיזמים לחיבור ארץ.', '31.25.2017', '../../assets/images/pic3.png'),
    new LatestVideo('3', 'וכמקובל את, גם כלל בדפים לחיבור ואלקטרוניקה, דת שתפו מאמר כתב.', '14.25.2017', '../../assets/images/pic4.png'),
    new LatestVideo('4', 'לחיבור אתה. מיזם לעריכה של זכר, ארץ המחשב פולנית ביולוגיה אל.', '15.25.2017', '../../assets/images/pic5.png'),
    new LatestVideo('5', 'בהבנה המקושרים ארכיאולוגיה אחר על, רבה משפטים תחבורה התפתחות', '16.25.2017', '../../assets/images/pic6.png')
  ];

  
  
  // programs = [
  //   new Program(0, 'adwwa', 'rthrth', 'rthew', 'כדי ליום קלאסיים וספציפיים אל, היום לחבר את קרן, אל הספרות לעריכת כלל.', new Date(Date.now()) , 'https://pp.userapi.com/c624418/v624418811/2e7d/5_5bT0KLdkw.jpg', 'https://www.google.co.il/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjDp6W08avfAhWSLVAKHXAjAggQjRx6BAgBEAU&url=https%3A%2F%2Fwww.euronews.com%2F2018%2F07%2F13%2Fin-pictures-the-brief-life-of-the-trump-baby-balloon&psig=AOvVaw323pFsHHL8qr0LUEOWkK0H&ust=1545308633027354'),
  //   new Program(1, 'adwwa', 'rthrth', 'rthew', 'כדי ליום קלאסיים וספציפיים אל, היום לחבר את קרן, אל הספרות לעריכת כלל.', new Date(Date.now()) , 'https://pp.userapi.com/c624418/v624418811/2e7d/5_5bT0KLdkw.jpg', 'https://www.google.co.il/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjDp6W08avfAhWSLVAKHXAjAggQjRx6BAgBEAU&url=https%3A%2F%2Fwww.euronews.com%2F2018%2F07%2F13%2Fin-pictures-the-brief-life-of-the-trump-baby-balloon&psig=AOvVaw323pFsHHL8qr0LUEOWkK0H&ust=1545308633027354'),
  //   new Program(3, 'adwwa', 'rthrth', 'rthew', 'כדי ליום קלאסיים וספציפיים אל, היום לחבר את קרן, אל הספרות לעריכת כלל.', new Date(Date.now()) , 'https://pp.userapi.com/c624418/v624418811/2e7d/5_5bT0KLdkw.jpg', 'https://www.google.co.il/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjDp6W08avfAhWSLVAKHXAjAggQjRx6BAgBEAU&url=https%3A%2F%2Fwww.euronews.com%2F2018%2F07%2F13%2Fin-pictures-the-brief-life-of-the-trump-baby-balloon&psig=AOvVaw323pFsHHL8qr0LUEOWkK0H&ust=1545308633027354'),
  //   new Program(4, 'adwwa', 'rthrth', 'rthew', 'כדי ליום קלאסיים וספציפיים אל, היום לחבר את קרן, אל הספרות לעריכת כלל.', new Date(Date.now()) , 'https://pp.userapi.com/c624418/v624418811/2e7d/5_5bT0KLdkw.jpg', 'https://www.google.co.il/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjDp6W08avfAhWSLVAKHXAjAggQjRx6BAgBEAU&url=https%3A%2F%2Fwww.euronews.com%2F2018%2F07%2F13%2Fin-pictures-the-brief-life-of-the-trump-baby-balloon&psig=AOvVaw323pFsHHL8qr0LUEOWkK0H&ust=1545308633027354'),
  //   new Program(5, 'adwwa', 'rthrth', 'rthew', 'כדי ליום קלאסיים וספציפיים אל, היום לחבר את קרן, אל הספרות לעריכת כלל.', new Date(Date.now()) , 'https://pp.userapi.com/c624418/v624418811/2e7d/5_5bT0KLdkw.jpg', 'https://www.google.co.il/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjDp6W08avfAhWSLVAKHXAjAggQjRx6BAgBEAU&url=https%3A%2F%2Fwww.euronews.com%2F2018%2F07%2F13%2Fin-pictures-the-brief-life-of-the-trump-baby-balloon&psig=AOvVaw323pFsHHL8qr0LUEOWkK0H&ust=1545308633027354'),
  //   new Program(6, 'adwwa', 'rthrth', 'rthew', 'כדי ליום קלאסיים וספציפיים אל, היום לחבר את קרן, אל הספרות לעריכת כלל.', new Date(Date.now()) , 'https://pp.userapi.com/c624418/v624418811/2e7d/5_5bT0KLdkw.jpg', 'https://www.google.co.il/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjDp6W08avfAhWSLVAKHXAjAggQjRx6BAgBEAU&url=https%3A%2F%2Fwww.euronews.com%2F2018%2F07%2F13%2Fin-pictures-the-brief-life-of-the-trump-baby-balloon&psig=AOvVaw323pFsHHL8qr0LUEOWkK0H&ust=1545308633027354'),
  // ];

  // programs = [
  //   new Program(0, 'adwwa', 'rthrth', 'rthew', 'כדי ליום קלאסיים וספציפיים אל, היום לחבר את קרן, אל הספרות לעריכת כלל.', new Date(Date.now()) , '../../assets/images/pic1.png', 'https://www.google.co.il/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjDp6W08avfAhWSLVAKHXAjAggQjRx6BAgBEAU&url=https%3A%2F%2Fwww.euronews.com%2F2018%2F07%2F13%2Fin-pictures-the-brief-life-of-the-trump-baby-balloon&psig=AOvVaw323pFsHHL8qr0LUEOWkK0H&ust=1545308633027354'),
  //   new Program(1, 'adwwa', 'rthrth', 'rthew', 'כדי ליום קלאסיים וספציפיים אל, היום לחבר את קרן, אל הספרות לעריכת כלל.', new Date(Date.now()) , '../../assets/images/pic2.png', 'https://www.google.co.il/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjDp6W08avfAhWSLVAKHXAjAggQjRx6BAgBEAU&url=https%3A%2F%2Fwww.euronews.com%2F2018%2F07%2F13%2Fin-pictures-the-brief-life-of-the-trump-baby-balloon&psig=AOvVaw323pFsHHL8qr0LUEOWkK0H&ust=1545308633027354'),
  //   new Program(3, 'adwwa', 'rthrth', 'rthew', 'כדי ליום קלאסיים וספציפיים אל, היום לחבר את קרן, אל הספרות לעריכת כלל.', new Date(Date.now()) , '../../assets/images/pic3.png', 'https://www.google.co.il/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjDp6W08avfAhWSLVAKHXAjAggQjRx6BAgBEAU&url=https%3A%2F%2Fwww.euronews.com%2F2018%2F07%2F13%2Fin-pictures-the-brief-life-of-the-trump-baby-balloon&psig=AOvVaw323pFsHHL8qr0LUEOWkK0H&ust=1545308633027354'),
  //   new Program(4, 'adwwa', 'rthrth', 'rthew', 'כדי ליום קלאסיים וספציפיים אל, היום לחבר את קרן, אל הספרות לעריכת כלל.', new Date(Date.now()) , '../../assets/images/pic4.png', 'https://www.google.co.il/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjDp6W08avfAhWSLVAKHXAjAggQjRx6BAgBEAU&url=https%3A%2F%2Fwww.euronews.com%2F2018%2F07%2F13%2Fin-pictures-the-brief-life-of-the-trump-baby-balloon&psig=AOvVaw323pFsHHL8qr0LUEOWkK0H&ust=1545308633027354'),
  //   new Program(5, 'adwwa', 'rthrth', 'rthew', 'כדי ליום קלאסיים וספציפיים אל, היום לחבר את קרן, אל הספרות לעריכת כלל.', new Date(Date.now()) , '../../assets/images/pic5.png', 'https://www.google.co.il/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjDp6W08avfAhWSLVAKHXAjAggQjRx6BAgBEAU&url=https%3A%2F%2Fwww.euronews.com%2F2018%2F07%2F13%2Fin-pictures-the-brief-life-of-the-trump-baby-balloon&psig=AOvVaw323pFsHHL8qr0LUEOWkK0H&ust=1545308633027354'),
  //   new Program(6, 'adwwa', 'rthrth', 'rthew', 'כדי ליום קלאסיים וספציפיים אל, היום לחבר את קרן, אל הספרות לעריכת כלל.', new Date(Date.now()) , '../../assets/images/pic6.png', 'https://www.google.co.il/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjDp6W08avfAhWSLVAKHXAjAggQjRx6BAgBEAU&url=https%3A%2F%2Fwww.euronews.com%2F2018%2F07%2F13%2Fin-pictures-the-brief-life-of-the-trump-baby-balloon&psig=AOvVaw323pFsHHL8qr0LUEOWkK0H&ust=1545308633027354'),
  // ];
  
  
  changePictureRight(){
    let i;
    let tempLatestVideo=this.lvideos[0];
    for (i=0;i<this.lvideos.length;i++){

      if (i+1<this.lvideos.length){
        this.lvideos[i]=this.lvideos[i+1];
      }
      
    }
    this.lvideos[this.lvideos.length-1] = tempLatestVideo;
    this.logger.debug("LatestVideos: ", "changePictureRight clicked");
  }

  changePictureLeft(){
    let i;
    let tempLatestVideo=this.lvideos[this.lvideos.length-1];
    for (i=this.lvideos.length-1;i>=0;i--){

      if (i-1>=0){
        this.lvideos[i]=this.lvideos[i-1];
      }
      
    }
    this.lvideos[0] = tempLatestVideo;
    this.logger.debug("LatestVideos: ", "changePictureLeft clicked");
  }

  
}
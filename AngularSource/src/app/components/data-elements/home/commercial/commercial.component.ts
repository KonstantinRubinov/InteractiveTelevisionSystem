import { Component, OnInit } from '@angular/core';
import { Commercial } from 'src/app/models/commercial';

@Component({
  selector: 'app-commercial',
  templateUrl: './commercial.component.html',
  styleUrls: ['./commercial.component.css']
})
export class CommercialComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }


  commercials = [
    new Commercial('0', 'את ב בהתייחסות העריכהגירסאות, ב מדע צרפתית לרפובליקה.', '../../assets/images/hungred.png'),
    new Commercial('1', 'כל שתפו הארץ אקטואליה מה. ספורט המלחמה שינויים שכל גם, למנוע ספרות', '../../assets/images/disc.png'),
    new Commercial('2', 'רקטות ביוני טכנולוגיה תנך של. בשפות ויקימדיה אם חפש.', '../../assets/images/infinity.png'),
  ];

}

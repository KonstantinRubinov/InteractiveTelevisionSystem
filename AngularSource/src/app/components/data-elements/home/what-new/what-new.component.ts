import { Component, OnInit } from '@angular/core';
import { NewProgram } from 'src/app/models/new_program';
import { TranslationService } from 'src/app/services/basics/translation.service';

@Component({
  selector: 'app-what-new',
  templateUrl: './what-new.component.html',
  styleUrls: ['./what-new.component.css']
})
export class WhatNewComponent implements OnInit {

  constructor(private translationService: TranslationService) { }

  ngOnInit() {
    this.setTranslations();
  }

  private setTranslations(){
    this.what_new_title=this.translationService.GetTranslatioFromDictionaryByKey('section-whatsNew');
  }

  what_new_title ='';

  new_programs = [
    new NewProgram('0', 'מוזיקה:', '"בריטני"', '21:00', '../../assets/images/new_program_pic1.png'),
    new NewProgram('1', 'חינוך:', '"היוון העתיקה"', '22:00', '../../assets/images/new_program_pic2.png'),
    new NewProgram('2', 'סרט:', '"שוקולד"', '23:00', '../../assets/images/new_program_pic3.png')
  ];

}

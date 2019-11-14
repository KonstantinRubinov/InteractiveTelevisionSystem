import { Component, OnInit } from '@angular/core';
import { TranslationService } from 'src/app/services/basics/translation.service';
import { LogService } from 'src/app/services/log.service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {

  constructor(private translationService: TranslationService, private logger: LogService) { }
  
  ngOnInit() {
    this.setTranslations();
  }

  private setTranslations(){
    this.contact_us_title=this.translationService.GetTranslatioFromDictionaryByKey('section-contactUs');
    this.namePlaceholder=this.translationService.GetTranslatioFromDictionaryByKey('form-name');
    this.telephonePlaceholder=this.translationService.GetTranslatioFromDictionaryByKey('form-telephone');
    this.mailPlaceholder=this.translationService.GetTranslatioFromDictionaryByKey('form-email');
    this.messagePlaceholder=this.translationService.GetTranslatioFromDictionaryByKey('form-message');
    this.send=this.translationService.GetTranslatioFromDictionaryByKey('form-submit');
    this.clear=this.translationService.GetTranslatioFromDictionaryByKey('form-cancel');
  }

  find_us_title='';
  contact_us_title='';

  namePlaceholder='';
  telephonePlaceholder='';
  mailPlaceholder='';
  messagePlaceholder='';

  send='';
  clear='';

  model : LoginSchema = {} as LoginSchema;
  submitted = false;
  onSubmit() {
    this.submitted = true;
    this.logger.debug("contact message: ", "submitted");
  }

}

interface LoginSchema{
  name:string;
  phone:string;
  email:string;
  message:string;
}

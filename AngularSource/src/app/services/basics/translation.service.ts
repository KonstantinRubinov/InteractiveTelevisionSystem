import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { KeyedCollection } from '../../dictionary/KeyedCollection';
import { environment, translationsUrl } from 'src/environments/environment';
import { Translation } from 'src/app/models/basics/translation';
import { LogService } from '../log.service';




@Injectable({
  providedIn: 'root'
})
export class TranslationService {

  

  private env = environment;

  constructor(private translationDictionary:KeyedCollection<Translation>,
              private http: HttpClient,
              private logger: LogService) { }
  
  private makeTranslationDictionary(t: Translation[]):void{
    let i:number;
    for (i=0;i<t.length;i++){
        this.translationDictionary.Add(t[i].translationKey, t[i]);
    }
    this.env.hasTranslations = true;
  }

  public GetTranslationDictionary():KeyedCollection<Translation>{
    return this.translationDictionary;
  }

  public GetTranslatioFromDictionaryByKey(key:string):string{
    if (this.env.language==='he'){
      return this.translationDictionary.Item(key).translationHebrew;
    } else if (this.env.language==='en'){
      return this.translationDictionary.Item(key).translationEnglish;
    } else {
      return this.translationDictionary.Item(key).translationEnglish;
    }
    
  }

  private addToTranslationDictionary(t: Translation):void{
    this.translationDictionary.Add(t.translationKey, t);
  }
  

  public GetTranslation(): void {
    let observable = this.http.get<Translation[]>(translationsUrl);
    observable.subscribe(translations=>{
      this.makeTranslationDictionary(translations);
    });
  }

  public GetTranslationByKey(key: string): void {
    const url = `${translationsUrl + 'key'}/${key}`;
    let observable = this.http.get<Translation>(url);
    observable.subscribe(translation=>{
      this.addToTranslationDictionary(translation);
    });
  }
}

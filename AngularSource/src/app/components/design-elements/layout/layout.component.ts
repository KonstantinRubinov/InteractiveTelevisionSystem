import { Component, OnInit} from '@angular/core';
import { environment } from 'src/environments/environment';
import { TranslationService } from 'src/app/services/basics/translation.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {

  public env = environment;

  constructor(
    private translationService: TranslationService) {}

  ngOnInit() {
    this.translationService.GetTranslation();
  }

}

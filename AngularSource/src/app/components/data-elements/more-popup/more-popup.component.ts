import { Component, OnInit, Input } from '@angular/core';
import { NewsPrefered } from 'src/app/models/news_prefered';
import { NewsSport } from 'src/app/models/news_sport';
import { Blog } from 'src/app/models/basics/blog';
import { LogService } from 'src/app/services/log.service';

@Component({
  selector: 'app-more-popup',
  templateUrl: './more-popup.component.html',
  styleUrls: ['./more-popup.component.css']
})
export class MorePopupComponent implements OnInit {
  @Input() myData: any;
  private width:string = "150px";
  private pwidth:string = "523px";
  private pheight:string = "265px";

  constructor(private logger: LogService) { }

  ngOnInit() {
    if (this.myData instanceof Blog){
        this.logger.debug("Popup: ", "the data is Blog");
        this.myData = this.myData as Blog;
        this.width = "150px";
        this.pwidth = "200px";
        this.pheight = "200px";
    } else if (this.myData instanceof NewsSport){
      this.logger.debug("Popup: ", "the data is NewsSport");
      this.myData = this.myData as NewsSport;
      this.width = "90px";
      this.pwidth = "523px";
      this.pheight = "265px";
    } else {
      this.logger.debug("Popup: ", "the data is NewsPrefered");
      this.myData = this.myData as NewsPrefered;
      this.width = "90px";
      this.pwidth = "200px";
      this.pheight = "200px";
    }
  }

  public getMainPostedBy(){
    let styles = {
      'background-color': 'rgba(255, 255, 255, 0.3)',
	    'float':'right',
	    'width':this.width,
      'text-align':'center',
      'margin-top':'5px',
	    'margin-bottom':'5px'
    };
    return styles;
  }

  public getPictureWHC(){
    let styles = {
      'width':this.pwidth,
      'height':this.pheight,
      'background-image': 'url(' + this.myData.url + ')'
    };
    return styles;
  }

}

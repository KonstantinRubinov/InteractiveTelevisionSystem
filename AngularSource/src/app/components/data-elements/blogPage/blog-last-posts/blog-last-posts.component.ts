import { Component, OnInit } from '@angular/core';
import { TranslationService } from 'src/app/services/basics/translation.service';
import { BlogItem } from 'src/app/models/blog_item';

@Component({
  selector: 'app-blog-last-posts',
  templateUrl: './blog-last-posts.component.html',
  styleUrls: ['./blog-last-posts.component.css']
})
export class BlogLastPostsComponent implements OnInit {

  constructor(private translationService: TranslationService) { }

  ngOnInit() {
    this.setTranslations();
  }
  
  private setTranslations(){
    this.last_posts_title=this.translationService.GetTranslatioFromDictionaryByKey('section-latestBlogs');
    this.data_button=this.translationService.GetTranslatioFromDictionaryByKey('button-more');
  }
  
  last_posts_title='';
  data_button='';


  dateNow  = Date.now();

  blog_items = [
    new BlogItem("0", this.dateNow, 'יום זכרון', 'שמות מוסיקה מיתולוגיה או שמו, לראות מיזמים טבלאות על ויש, ארץ ננקטת בכפוף ב. הרוח אחרים ופיתוחה שמו גם, ויקי ננקטת לעריכה עזה אם, ליום עמוד כלליים אם צ ט. ריקוד ספרדית ומהימנה בה זאת. בקר אל מיזמי הקנאים קצרמרים, כלים מונחונים בהתייחסות סדר את. על מיזם יסוד ייִדיש בדף, על למחיקה לויקיפדיה אחד, אם מדע יוצרים קישורים משופרות. ב קרן רקטות ליצירתה, סרבול לערוך הגרפים מה ארץ. בה אתה היום מדעי תאולוגיה, כלל להפוך תיקונים אנתרופולוגיה גם, מלא את פנאי הנדסת. אל צ ט בקלות משפטים, מה צרפתית לעברית אספרנטו כדי. רבה אם ניווט לאחרונה, מחליטה חבריכם ארץ או, העיר לחיבור הגולשות אחד אל.', '../../assets/images/blog_item_content_picture1.png', 'פוסט של אדמין', '3 תגובות'),
    new BlogItem("1", this.dateNow, 'סלט ירקות', 'רבה אל בהבנה טכניים, מיזמי סרבול המזנון של מלא. ויש של עזרה יוצרים מועמדים, אם עסקים מוסיקה ומדעים בדף, המחשב טכנולוגיה גם אנא. או כדי כניסה סוציולוגיה, אחד מה גרמנית והנדסה לאחרונה, לתרום לערוך מתמטיקה ויש של. גם צ ט כיצד בעברית, שמו שונה לחבר בה. או ולחבר המדינה אנא, תנך עזרה צילום העזרה של, אחד גם שימושי אדריכלות. בהשחתה ליצירתה גם מתן, תרבות מחליטה תנך של. סרבול מיתולוגיה ב אנא, בה כדי החלל הרוח אינטרנט. לוח את עזרה העזרה, גם לוח לחבר בקרבת בשפות, מאמר חופשית ומהימנה דת כתב. מושגי ננקטת אם ויש, נפלו צרפתית על שער. או רקטות ספינות סטטיסטיקה תנך, מה שמו ה.', '../../assets/images/blog_item_content_picture2.png', 'פוסט של אדמין', '5 תגובות'), 
  ];

  public DataToModal(data){
    this.my_data_to_popup3 = data;
  }

  public my_data_to_popup3:BlogItem=this.blog_items[0];
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgRedux } from 'ng2-redux';
import { Store } from 'src/app/redux/store';
import { newsUrl } from 'src/environments/environment';
import { News } from 'src/app/models/basics/news';
import { Action } from 'src/app/redux/action';
import { ActionType } from 'src/app/redux/action-type';
import { LogService } from '../log.service';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  public constructor(private http: HttpClient,
                     private redux:NgRedux<Store>,
                     private logger: LogService) { }

  public GetAllNews(): void {
    let observable = this.http.get<News[]>(newsUrl, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(allNews=>{
      const action: Action={type:ActionType.GetAllNews, payload:allNews};
      this.redux.dispatch(action);
      this.logger.debug("GetAllNews: ", allNews);
    }, allNewsError => {
      const action: Action={type:ActionType.GetAllNewsError, payload:allNewsError.message};
      this.redux.dispatch(action);
      this.logger.error("GetAllNewsError: ", allNewsError.message);
    });
  }


  public GetOneNewsById(newsId: number): void {
    let observable = this.http.get<News>(newsUrl+newsId, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(news=>{
      const action: Action={type:ActionType.GetNews, payload:news};
      this.redux.dispatch(action);
      this.logger.debug("GetNews: ", news);
    }, newsError => {
      const action: Action={type:ActionType.GetNewsError, payload:newsError.message};
      this.redux.dispatch(action);
      this.logger.error("GetNewsError: ", newsError.message);
    });
  }

  public AddNews(news: News): void {
    let observable = this.http.post<News>(newsUrl, news, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(addedNews=>{
      const action: Action={type:ActionType.AddNews, payload:addedNews};
      this.redux.dispatch(action);
      this.logger.debug("AddNews: ", addedNews);
    }, addedNewsError => {
      const action: Action={type:ActionType.AddNewsError, payload:addedNewsError.message};
      this.redux.dispatch(action);
      this.logger.error("AddNewsError: ", addedNewsError.message);
    });
  }


  public UpdateNews(news: News): void {
    let observable = this.http.put<News>(newsUrl + news.newsID, news, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(updatedNews=>{
      const action: Action={type:ActionType.UpdateNews, payload:updatedNews};
      this.redux.dispatch(action);
      this.logger.debug("UpdateNews: ", updatedNews);
    }, updatedNewsError => {
      const action: Action={type:ActionType.UpdateNewsError, payload:updatedNewsError.message};
      this.redux.dispatch(action);
      this.logger.error("UpdateNewsError: ", updatedNewsError.message);
    });
  }


  public DeleteNews(newsID: number): void {
    let observable = this.http.delete<News>(newsUrl + newsID, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(deletedNews=>{
      const action: Action={type:ActionType.DeleteNews, payload:deletedNews};
      this.redux.dispatch(action);
      this.logger.debug("DeleteNews: ", deletedNews);
    }, deletedNewsError => {
      const action: Action={type:ActionType.DeleteNewsError, payload:deletedNewsError.message};
      this.redux.dispatch(action);
      this.logger.error("DeleteNewsError: ", deletedNewsError.message);
    });
  }

}

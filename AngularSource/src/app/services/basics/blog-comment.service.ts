import { Injectable } from '@angular/core';
import { NgRedux } from 'ng2-redux';
import { Store } from 'src/app/redux/store';
import { BlogComment } from 'src/app/models/basics/blog_comment';
import { blogCommentsUrl } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Action } from 'src/app/redux/action';
import { ActionType } from 'src/app/redux/action-type';
import { LogService } from '../log.service';

@Injectable({
  providedIn: 'root'
})
export class BlogCommentService {

  public constructor(private http: HttpClient,
                     private redux:NgRedux<Store>,
                     private logger: LogService) { }


  public GetAllBlogComments(): void {
    let observable = this.http.get<BlogComment[]>(blogCommentsUrl, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(allBlogComments=>{
      const action: Action={type:ActionType.GetAllBlogComments, payload:allBlogComments};
      this.redux.dispatch(action);
      this.logger.debug("GetAllBlogComments: ", allBlogComments);
    }, allBlogCommentsError => {
      const action: Action={type:ActionType.GetAllBlogCommentsError, payload:allBlogCommentsError.message};
      this.redux.dispatch(action);
      this.logger.error("GetAllBlogCommentsError: ", allBlogCommentsError.message);
    });
  }

  public GetOneBlogCommentById(commentId: number): void {
    let observable = this.http.get<BlogComment>(blogCommentsUrl+commentId, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(blogComment=>{
      const action: Action={type:ActionType.GetBlogComment, payload:blogComment};
      this.redux.dispatch(action);
      this.logger.debug("GetBlogComment: ", blogComment);
    }, blogCommentError => {
      const action: Action={type:ActionType.GetBlogCommentError, payload:blogCommentError.message};
      this.redux.dispatch(action);
      this.logger.error("GetBlogCommentError: ", blogCommentError.message);
    });
  }

  public GetOneBlogCommentByBlogId(blogId: number): void {
    let observable = this.http.get<BlogComment[]>(blogCommentsUrl+"forBlog/"+blogId, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(blogCommentByBlogId=>{
      const action: Action={type:ActionType.GetBlogCommentsByBlogId, payload:blogCommentByBlogId};
      this.redux.dispatch(action);
      this.logger.debug("GetBlogCommentsByBlogId: ", blogCommentByBlogId);
    }, blogCommentByBlogIdError => {
      const action: Action={type:ActionType.GetBlogCommentsByBlogIdError, payload:blogCommentByBlogIdError.message};
      this.redux.dispatch(action);
      this.logger.error("GetBlogCommentsByBlogIdError: ", blogCommentByBlogIdError.message);
    });
  }


  public AddBlogComment(blogComment: BlogComment): void {
    let observable = this.http.post<BlogComment>(blogCommentsUrl, blogComment, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(addedBlogComment=>{
      const action: Action={type:ActionType.AddBlogComment, payload:addedBlogComment};
      this.redux.dispatch(action);
      this.logger.debug("AddBlogComment: ", addedBlogComment);
    }, addedBlogCommentError => {
      const action: Action={type:ActionType.AddBlogCommentError, payload:addedBlogCommentError.message};
      this.redux.dispatch(action);
      this.logger.error("AddBlogCommentError: ", addedBlogCommentError.message);
    });
  }


  public UpdateBlogComment(blogComment: BlogComment): void {
    let observable = this.http.put<BlogComment>(blogCommentsUrl + blogComment.commentId, blogComment, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(updatedBlogComment=>{
      const action: Action={type:ActionType.UpdateBlogComment, payload:updatedBlogComment};
      this.redux.dispatch(action);
      this.logger.debug("UpdateBlogComment: ", updatedBlogComment);
    }, updatedBlogCommentError => {
      const action: Action={type:ActionType.UpdateBlogCommentError, payload:updatedBlogCommentError.message};
      this.redux.dispatch(action);
      this.logger.error("UpdateBlogCommentError: ", updatedBlogCommentError.message);
    });
  }

  public DeleteBlogComment(commentId: number): void {
    let observable = this.http.delete<BlogComment>(blogCommentsUrl + commentId, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(deletedBlogComment=>{
      const action: Action={type:ActionType.DeleteBlogComment, payload:deletedBlogComment};
      this.redux.dispatch(action);
      this.logger.debug("DeleteBlogComment: ", deletedBlogComment);
    }, deletedBlogCommentError => {
      const action: Action={type:ActionType.DeleteBlogCommentError, payload:deletedBlogCommentError.message};
      this.redux.dispatch(action);
      this.logger.error("DeleteBlogCommentError: ", deletedBlogCommentError.message);
    });
  }
}

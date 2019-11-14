import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Store } from '../../redux/store';
import { NgRedux } from 'ng2-redux';
import { Action } from '../../redux/action';
import { ActionType } from '../../redux/action-type';
import { Blog } from '../../models/basics/blog';
import { blogsUrl } from 'src/environments/environment';
import { LogService } from '../log.service';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  public constructor(private http: HttpClient,
                     private redux:NgRedux<Store>,
                     private logger: LogService) { }


  public GetAllBlogs(): void {
    let observable = this.http.get<Blog[]>(blogsUrl, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(allBlogs=>{
      const action: Action={type:ActionType.GetAllBlogs, payload:allBlogs};
      this.redux.dispatch(action);
      this.logger.debug("GetAllBlogs: ", allBlogs);
    }, allBlogsError => {
      const action: Action={type:ActionType.GetAllBlogsError, payload:allBlogsError.message};
      this.redux.dispatch(action);
      this.logger.error("GetAllBlogsError: ", allBlogsError.message);
    });
  }

  public GetOneBlogById(blogId: number): void {
    let observable = this.http.get<Blog>(blogsUrl+blogId, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(blog=>{
      const action: Action={type:ActionType.GetBlog, payload:blog};
      this.redux.dispatch(action);
      this.logger.debug("GetBlog: ", blog);
    }, blogError => {
      const action: Action={type:ActionType.GetBlogError, payload:blogError.message};
      this.redux.dispatch(action);
      this.logger.error("GetBlogError: ", blogError.message);
    });
  }


  public AddBlog(blog: Blog): void {
    let observable = this.http.post<Blog>(blogsUrl, blog, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(addedBlog=>{
      const action: Action={type:ActionType.AddBlog, payload:addedBlog};
      this.redux.dispatch(action);
      this.logger.debug("AddBlog: ", blog);
    }, addedBlogError => {
      const action: Action={type:ActionType.AddBlogError, payload:addedBlogError.message};
      this.redux.dispatch(action);
      this.logger.error("AddBlogError: ", addedBlogError.message);
    });
  }


  public UpdateBlog(blog: Blog): void {
    let observable = this.http.put<Blog>(blogsUrl + blog.blogId, blog, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(updatedBlog=>{
      const action: Action={type:ActionType.UpdateBlog, payload:updatedBlog};
      this.redux.dispatch(action);
      this.logger.debug("UpdateBlog: ", updatedBlog);
    }, updatedBlogError => {
      const action: Action={type:ActionType.UpdateBlogError, payload:updatedBlogError.message};
      this.redux.dispatch(action);
      this.logger.error("UpdateBlogError: ", updatedBlogError.message);
    });
  }

  public DeleteBlog(blogId: number): void {
    let observable = this.http.delete<Blog>(blogsUrl + blogId, {
      headers: {'Content-Type':  'application/json'}
    });
    observable.subscribe(deletedBlog=>{
      const action: Action={type:ActionType.DeleteBlog, payload:deletedBlog};
      this.redux.dispatch(action);
      this.logger.debug("DeleteBlog: ", deletedBlog);
    }, deletedBlogError => {
      const action: Action={type:ActionType.DeleteBlogError, payload:deletedBlogError.message};
      this.redux.dispatch(action);
      this.logger.error("DeleteBlogError: ", deletedBlogError.message);
    });
  }
  



}
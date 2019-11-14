import {Translation} from "../models/basics/translation";
import {KeyedCollection } from '../dictionary/KeyedCollection';
import { Blog } from '../models/basics/blog';
import { Program } from '../models/basics/program';
import { BlogComment } from '../models/basics/blog_comment';
import { News } from '../models/basics/news';

export class Store{
    public translationDictionary:KeyedCollection<Translation>;


    allBlogs:Blog[]=[];
    blog:Blog = new Blog();
    allBlogsError:string='';
    blogError:string='';
    addedBlogError:string='';
    updatedBlogError:string='';
    deletedBlogError:string='';

    allPrograms:Program[]=[];
    program:Program = new Program();
    allProgramsError:string='';
    programError:string='';
    addedProgramError:string='';
    updatedProgramError:string='';
    deletedProgramError:string='';

    allBlogComments:BlogComment[]=[];
    blogComment:BlogComment = new BlogComment();
    allBlogCommentsByBlogId:BlogComment[]=[];
    allBlogCommentsError:string='';
    blogCommentError:string='';
    blogCommentByBlogIdError:string='';
    addedBlogCommentError:string='';
    updatedBlogCommentError:string='';
    deletedBlogCommentError:string='';

    allNews:News[]=[];
    news:News = new News();
    allNewsError:string='';
    newsError:string='';
    addedNewsError:string='';
    updatedNewsError:string='';
    deletedNewsError:string='';
}
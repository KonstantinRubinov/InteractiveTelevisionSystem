import { Store } from "./store";
import { Action } from "./action";
import { ActionType } from "./action-type";

export class Reducer{
    public static reduce(oldStore: Store, action:Action):Store{
        let newStore:Store = {...oldStore};

        switch(action.type){
            case ActionType.GetAllTranslations:
                newStore.translationDictionary = action.payload;
                break;
            case ActionType.GetTranslationByKey:
                newStore.translationDictionary = action.payload;
                break;



            case ActionType.GetAllBlogs:
                newStore.allBlogs=action.payload;
                break;
            case ActionType.GetAllBlogsError:
                newStore.allBlogsError=action.payload;
                break;
            case ActionType.GetBlog:
                newStore.blog=action.payload;
                break;
            case ActionType.GetBlogError:
                newStore.blogError=action.payload;
                break;
            case ActionType.AddBlog:
                newStore.allBlogs.push(action.payload);
                break;
            case ActionType.AddBlogError:
                newStore.addedBlogError=action.payload;
                break;
            case ActionType.UpdateBlog:
                let blogIndex = newStore.allBlogs.findIndex(item => item.blogId === action.payload.blogId);
                    newStore.allBlogs[blogIndex] = action.payload;
                    break;
            case ActionType.UpdateBlogError:
                newStore.updatedBlogError=action.payload;
                break;
            case ActionType.DeleteBlog:
                newStore.allBlogs.forEach( (item, index) => {
                    if(item.blogId === action.payload.blogId)
                        newStore.allBlogs.splice(index,1);
                });
                break;
            case ActionType.DeleteBlogError:
                newStore.deletedBlogError=action.payload;
                break;
                


            case ActionType.GetAllPrograms:
                newStore.allPrograms=action.payload;
                break;
            case ActionType.GetAllProgramsError:
                newStore.allProgramsError=action.payload;
                break;
            case ActionType.GetProgram:
                newStore.program=action.payload;
                break;
            case ActionType.GetProgramError:
                newStore.programError=action.payload;
                break;
            case ActionType.AddProgram:
                newStore.allPrograms.push(action.payload);
                break;
            case ActionType.AddProgramError:
                newStore.addedProgramError=action.payload;
                break;
            case ActionType.UpdateProgram:
                let programIndex = newStore.allPrograms.findIndex(item => item.programId === action.payload.programId);
                    newStore.allPrograms[programIndex] = action.payload;
                break;
            case ActionType.UpdateProgramError:
                newStore.updatedProgramError=action.payload;
                break;
            case ActionType.DeleteProgram:
                newStore.allPrograms.forEach( (item, index) => {
                    if(item.programId === action.payload.programId)
                        newStore.allPrograms.splice(index,1);
                });
                break;
            case ActionType.DeleteProgramError:
                newStore.deletedProgramError=action.payload;
                break;




            case ActionType.GetAllBlogComments:
                newStore.allBlogComments=action.payload;
                break;
            case ActionType.GetAllBlogCommentsError:
                newStore.allBlogCommentsError=action.payload;
                break;
            case ActionType.GetBlogComment:
                newStore.blogComment=action.payload;
                break;
            case ActionType.GetBlogCommentError:
                newStore.blogCommentError=action.payload;
                break;
            case ActionType.GetBlogCommentsByBlogId:
                newStore.allBlogCommentsByBlogId=action.payload;
                break;
            case ActionType.GetBlogCommentsByBlogIdError:
                newStore.blogCommentByBlogIdError=action.payload;
                break;
            case ActionType.AddBlogComment:
                newStore.allBlogComments.push(action.payload);
                break;
            case ActionType.AddBlogCommentError:
                newStore.addedBlogCommentError=action.payload;
                break;
            case ActionType.UpdateBlogComment:
                let blogCommentIndex = newStore.allBlogComments.findIndex(item => item.commentId === action.payload.commentId);
                    newStore.allBlogComments[blogCommentIndex] = action.payload;
                break;
            case ActionType.UpdateBlogCommentError:
                newStore.updatedBlogCommentError=action.payload;
                break;
            case ActionType.DeleteBlogComment:
                newStore.allBlogComments.forEach( (item, index) => {
                    if(item.commentId === action.payload.commentId)
                        newStore.allBlogComments.splice(index,1);
                });
                break;
            case ActionType.DeleteBlogCommentError:
                newStore.deletedBlogCommentError=action.payload;
                break;


            case ActionType.GetAllNews:
                newStore.allNews=action.payload;
                break;
            case ActionType.GetAllNewsError:
                newStore.allNewsError=action.payload;
                break;
            case ActionType.GetNews:
                newStore.news=action.payload;
                break;
            case ActionType.GetNewsError:
                newStore.newsError=action.payload;
                break;
            case ActionType.AddNews:
                newStore.allNews.push(action.payload);
                break;
            case ActionType.AddNewsError:
                newStore.addedNewsError=action.payload;
                break;
            case ActionType.UpdateNews:
                let newsIndex = newStore.allNews.findIndex(item => item.newsID === action.payload.newsID);
                    newStore.allNews[newsIndex] = action.payload;
                break;
            case ActionType.UpdateNewsError:
                newStore.updatedNewsError=action.payload;
                break;
            case ActionType.DeleteNews:
                newStore.allNews.forEach( (item, index) => {
                    if(item.newsID === action.payload.newsID)
                        newStore.allNews.splice(index,1);
                });
                break;
            case ActionType.DeleteNewsError:
                newStore.deletedNewsError=action.payload;
                break;









            default:
                break;
        }

        return newStore;

    }
}
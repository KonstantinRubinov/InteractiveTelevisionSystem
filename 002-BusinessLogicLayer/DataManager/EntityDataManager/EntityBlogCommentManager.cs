using IntTVapi.EntityDataBase;
using System.Collections.Generic;
using System.Linq;

namespace IntTVapi
{
	public class EntityBlogCommentManager : EntityBaseManager, IBlogCommentRepository
	{
		public List<BlogComment> GetAllBlogComments()
		{
			var resultQuary = DB.BLOGCOMMENTs.Select(bc => new BlogComment
			{
				blogId = bc.blogId,
				commentId = bc.commentId,
				commentContent = bc.commentContent
			});

			var resultSP = DB.GetAllBlogComment().Select(bc => new BlogComment
			{
				blogId = bc.blogId,
				commentId = bc.commentId,
				commentContent = bc.commentContent
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public BlogComment GetBlogCommentById(int commentId)
		{
			var resultQuary = DB.BLOGCOMMENTs.Where(bc => bc.commentId==commentId).Select(bc => new BlogComment
			{
				blogId = bc.blogId,
				commentId = bc.commentId,
				commentContent = bc.commentContent
			});

			var resultSP = DB.GetBlogCommentById(commentId).Select(bc => new BlogComment
			{
				blogId = bc.blogId,
				commentId = bc.commentId,
				commentContent = bc.commentContent
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public List<BlogComment> GetBlogCommentsByBlogId(int blogId)
		{
			var resultQuary = DB.BLOGCOMMENTs.Where(bc => bc.blogId == blogId).Select(bc => new BlogComment
			{
				blogId = bc.blogId,
				commentId = bc.commentId,
				commentContent = bc.commentContent
			});

			var resultSP = DB.GetBlogCommentsByBlogId(blogId).Select(bc => new BlogComment
			{
				blogId = bc.blogId,
				commentId = bc.commentId,
				commentContent = bc.commentContent
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public BlogComment AddBlogComment(BlogComment comment)
		{
			var resultSP = DB.PostBlogComment(comment.blogId, comment.commentContent).Select(bc => new BlogComment
			{
				blogId = bc.blogId,
				commentId = bc.commentId,
				commentContent = bc.commentContent
			});

			if (GlobalVariable.queryType == 0)
			{
				BLOGCOMMENT blogComment = new BLOGCOMMENT
				{
					blogId = comment.blogId,
					commentContent = comment.commentContent
				};

				DB.BLOGCOMMENTs.Add(blogComment);
				DB.SaveChanges();
				return GetBlogCommentById(blogComment.commentId);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public BlogComment UpdateBlogComment(BlogComment blogComment)
		{
			var resultSP = DB.UpdateBlogComment(blogComment.commentId, blogComment.blogId, blogComment.commentContent).Select(bc => new BlogComment
			{
				blogId = bc.blogId,
				commentId = bc.commentId,
				commentContent = bc.commentContent
			});

			if (GlobalVariable.queryType == 0)
			{
				BLOGCOMMENT blogComment2 = DB.BLOGCOMMENTs.Where(bc => bc.commentId == blogComment.commentId).SingleOrDefault();
				if (blogComment == null)
					return null;
				blogComment2.blogId = blogComment.blogId;
				blogComment2.commentId = blogComment.commentId;
				blogComment2.commentContent = blogComment.commentContent;
				DB.SaveChanges();
				return GetBlogCommentById(blogComment2.commentId);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public int DeleteBlogComment(int id)
		{
			var resultSP = DB.DeleteBlogComment(id);

			if (GlobalVariable.queryType == 0)
			{
				BLOGCOMMENT blogComment = DB.BLOGCOMMENTs.Where(bc => bc.commentId == id).SingleOrDefault();
				DB.BLOGCOMMENTs.Attach(blogComment);
				if (blogComment == null)
					return 0;
				DB.BLOGCOMMENTs.Remove(blogComment);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}
	}
}

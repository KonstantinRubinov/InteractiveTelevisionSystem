using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IntTVapi
{
	public class SqlBlogCommentManager: SqlDataBase, IBlogCommentRepository
	{
		public List<BlogComment> GetAllBlogComments()
		{
			DataTable dt = new DataTable();
			List<BlogComment> arrBlogComment = new List<BlogComment>();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(BlogCommentStringsSql.GetAllBlogComment());
			}

			foreach (DataRow ms in dt.Rows)
			{
				arrBlogComment.Add(BlogComment.ToObject(ms));
			}

			return arrBlogComment;
		}


		public BlogComment GetBlogCommentById(int id)
		{
			DataTable dt = new DataTable();

			if (id < 0)
				throw new ArgumentOutOfRangeException();
			BlogComment blogComment = new BlogComment();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(BlogCommentStringsSql.GetBlogCommentById(id));
			}

			foreach (DataRow ms in dt.Rows)
			{
				blogComment = BlogComment.ToObject(ms);
			}

			return blogComment;
		}

		public List<BlogComment> GetBlogCommentsByBlogId(int blogId)
		{
			DataTable dt = new DataTable();
			List<BlogComment> arrBlogComment = new List<BlogComment>();

			if (blogId < 0)
				throw new ArgumentOutOfRangeException();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(BlogCommentStringsSql.GetBlogCommentsByBlogId(blogId));
			}

			foreach (DataRow ms in dt.Rows)
			{
				arrBlogComment.Add(BlogComment.ToObject(ms));
			}

			return arrBlogComment;
		}

		public BlogComment AddBlogComment(BlogComment value)
		{
			DataTable dt = new DataTable();
			BlogComment blogComment = new BlogComment();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(BlogCommentStringsSql.PostBlogComment(value));
			}
			foreach (DataRow ms in dt.Rows)
			{
				blogComment = BlogComment.ToObject(ms);
			}

			return blogComment;
		}


		public BlogComment UpdateBlogComment(BlogComment value)
		{
			DataTable dt = new DataTable();
			BlogComment blogComment = new BlogComment();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(BlogCommentStringsSql.UpdateBlogComment(value));
			}

			foreach (DataRow ms in dt.Rows)
			{
				blogComment=BlogComment.ToObject(ms);
			}
			return GetBlogCommentById(value.commentId);
		}

		public int DeleteBlogComment(int id)
		{
			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(BlogCommentStringsSql.DeleteBlogComment(id));
			}

			return i;
		}
	}
}

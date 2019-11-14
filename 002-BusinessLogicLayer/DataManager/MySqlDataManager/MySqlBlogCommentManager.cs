using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace IntTVapi
{
	public class MySqlBlogCommentManager : MySqlDataBase, IBlogCommentRepository
	{
		public List<BlogComment> GetAllBlogComments()
		{
			DataTable dt = new DataTable();
			List<BlogComment> arrBlogComment = new List<BlogComment>();

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(BlogCommentStringsMySql.GetAllBlogComment());
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(BlogCommentStringsMySql.GetBlogCommentById(id));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(BlogCommentStringsMySql.GetBlogCommentsByBlogId(blogId));
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

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(BlogCommentStringsMySql.PostBlogComment(value));
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

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(BlogCommentStringsMySql.UpdateBlogComment(value));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(BlogCommentStringsMySql.DeleteBlogComment(id));
			}

			return i;
		}
	}
}

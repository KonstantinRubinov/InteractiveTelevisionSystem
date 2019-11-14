using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IntTVapi
{
	public class SqlBlogManager: SqlDataBase, IBlogRepository
	{
		public List<Blog> GetAllBlogs()
		{
			DataTable dt = new DataTable();
			List<Blog> arrBlog = new List<Blog>();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(BlogStringsSql.GetAllBlog());
			}

			foreach (DataRow ms in dt.Rows)
			{
				arrBlog.Add(Blog.ToObject(ms));
			}

			return arrBlog;
		}


		public Blog GetBlogById(int id)
		{
			DataTable dt = new DataTable();
			Blog blog = new Blog();

			if (id < 0)
				throw new ArgumentOutOfRangeException();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(BlogStringsSql.GetBlogById(id));
			}

			foreach (DataRow ms in dt.Rows)
			{
				blog = Blog.ToObject(ms);
			}

			return blog;
		}

		public Blog AddBlog(Blog value)
		{
			DataTable dt = new DataTable();
			Blog blog = new Blog();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(BlogStringsSql.PostBlog(value));
			}

			foreach (DataRow ms in dt.Rows)
			{
				blog = Blog.ToObject(ms);
			}
			return blog;
		}


		public Blog UpdateBlog(Blog value)
		{
			DataTable dt = new DataTable();
			Blog blog = new Blog();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(BlogStringsSql.UpdateBlog(value));
			}

			foreach (DataRow ms in dt.Rows)
			{
				blog = Blog.ToObject(ms);
			}
			return GetBlogById(value.blogId);
		}

		public int DeleteBlog(int id)
		{
			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(BlogStringsSql.DeleteBlog(id));
			}
			return i;
		}
	}
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace IntTVapi
{
	public class MySqlBlogManager : MySqlDataBase, IBlogRepository
	{
		public List<Blog> GetAllBlogs()
		{
			DataTable dt = new DataTable();
			List<Blog> arrBlog = new List<Blog>();

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(BlogStringsMySql.GetAllBlog());
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

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(BlogStringsMySql.GetBlogById(id));
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

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(BlogStringsMySql.PostBlog(value));
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

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(BlogStringsMySql.UpdateBlog(value));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(BlogStringsMySql.DeleteBlog(id));
			}
			return i;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IntTVapi
{
	public class SqlNewsManager: SqlDataBase, INewsRepository
	{
		public List<News> GetAllNews()
		{
			DataTable dt = new DataTable();
			List<News> arrNews = new List<News>();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(NewsStringsSql.GetAllNews());
			}

			foreach (DataRow ms in dt.Rows)
			{
				arrNews.Add(News.ToObject(ms));
			}
			return arrNews;
		}


		public News GetNewsById(int id)
		{
			DataTable dt = new DataTable();
			if (id < 0)
				throw new ArgumentOutOfRangeException();
			News news = new News();

			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(NewsStringsSql.GetNewsById(id));
			}

			foreach (DataRow ms in dt.Rows)
			{
				news = News.ToObject(ms);
			}
			return news;
		}

		public News AddNews(News value)
		{
			DataTable dt = new DataTable();
			News news = new News();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(NewsStringsSql.PostNews(value));
			}

			foreach (DataRow ms in dt.Rows)
			{
				news = News.ToObject(ms);
			}
			return news;
		}


		public News UpdateNews(News value)
		{
			DataTable dt = new DataTable();
			News news = new News();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(NewsStringsSql.UpdateNews(value));
			}

			foreach (DataRow ms in dt.Rows)
			{
				news = News.ToObject(ms);
			}
			return GetNewsById(value.newsID);
		}

		public int DeleteNews(int id)
		{
			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(NewsStringsSql.DeleteNews(id));
			}
			
			return i;
		}
	}
}

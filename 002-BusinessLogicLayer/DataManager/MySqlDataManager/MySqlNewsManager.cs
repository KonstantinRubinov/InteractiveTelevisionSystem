using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace IntTVapi
{
	public class MySqlNewsManager : MySqlDataBase, INewsRepository
	{
		public List<News> GetAllNews()
		{
			DataTable dt = new DataTable();
			List<News> arrNews = new List<News>();

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(NewsStringsMySql.GetAllNews());
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

			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(NewsStringsMySql.GetNewsById(id));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(NewsStringsMySql.PostNews(value));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(NewsStringsMySql.UpdateNews(value));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(NewsStringsMySql.DeleteNews(id));
			}
			
			return i;
		}
	}
}

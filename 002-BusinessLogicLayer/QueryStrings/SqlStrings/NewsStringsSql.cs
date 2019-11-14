using System.Data.SqlClient;

namespace IntTVapi
{
	static public class NewsStringsSql
	{
		static private string queryNewsString = "SELECT * from News;";
		static private string queryNewsByIdString = "SELECT * from News where newsID=@newsID;";
		static private string queryNewsPost = "INSERT INTO News (newsCategory,newsGenre,newsName,newsDescription,newsDateTime,newsMainPictureLink,newsVideoLink,newsPrefered) VALUES (@newsCategory, @newsGenre, @newsName, @newsDescription, @newsDateTime, @newsMainPictureLink, @newsVideoLink, @newsPrefered); SELECT * FROM News WHERE newsID = SCOPE_IDENTITY();";
		static private string queryNewsUpdate = "UPDATE News SET newsCategory = @newsCategory, newsGenre = @newsGenre, newsName = @newsName, newsDescription = @newsDescription, newsDateTime = @newsDateTime, newsMainPictureLink = @newsMainPictureLink, newsVideoLink = @newsVideoLink, newsPrefered = @newsPrefered  WHERE newsID = @newsID; SELECT * FROM News WHERE newsID = @newsID;";
		static private string queryNewsDelete = "DELETE FROM News WHERE newsID=@newsID;";
		static private string queryNewsTopSix = "SELECT TOP (6) * FROM News;";

		static private string procedureNewsString = "EXEC GetAllNews;";
		static private string procedureNewsByIdString = "EXEC GetNewsById @newsID;";
		static private string procedureNewsPost = "EXEC PostNews @newsCategory, @newsGenre, @newsName, @newsDescription, @newsDateTime, @newsMainPictureLink, @newsVideoLink, @newsPrefered;";
		static private string procedureNewsUpdate = "EXEC UpdateNews @newsID, @newsCategory, @newsGenre, @newsName, @newsDescription, @newsDateTime, @newsMainPictureLink, @newsVideoLink, @newsPrefered;";
		static private string procedureNewsDelete = "EXEC DeleteNews @newsID;";
		static private string procedureNewsTopSix = "EXEC TopSixNews;";

		static public SqlCommand GetAllNews()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryNewsString);
			else
				return CreateSqlCommand(procedureNewsString);
		}

		static public SqlCommand GetNewsById(int newsId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(newsId, queryNewsByIdString);
			else
				return CreateSqlCommand(newsId, procedureNewsByIdString);
		}

		static public SqlCommand PostNews(News news)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(news, queryNewsPost);
			else
				return CreateSqlCommand(news, procedureNewsPost);
		}

		static public SqlCommand UpdateNews(News news)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(news, queryNewsUpdate);
			else
				return CreateSqlCommand(news, procedureNewsUpdate);
		}

		static public SqlCommand DeleteNews(int newsId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(newsId, queryNewsDelete);
			else
				return CreateSqlCommand(newsId, procedureNewsDelete);
		}

		static public SqlCommand TopSixNews()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryNewsTopSix);
			else
				return CreateSqlCommand(procedureNewsTopSix);
		}

		static private SqlCommand CreateSqlCommand(News news, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@newsID", news.newsID);
			command.Parameters.AddWithValue("@newsCategory", news.newsCategory);
			command.Parameters.AddWithValue("@newsGenre", news.newsGenre);
			command.Parameters.AddWithValue("@newsName", news.newsName);
			command.Parameters.AddWithValue("@newsDescription", news.newsDescription);
			command.Parameters.AddWithValue("@newsDateTime", news.newsDateTime);
			command.Parameters.AddWithValue("@newsMainPictureLink", news.newsMainPictureLink);
			command.Parameters.AddWithValue("@newsVideoLink", news.newsVideoLink);
			command.Parameters.AddWithValue("@newsPrefered", news.newsPrefered);

			return command;
		}

		static private SqlCommand CreateSqlCommand(int newsID, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@newsID", newsID);

			return command;
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}











	}
}

using MySql.Data.MySqlClient;

namespace IntTVapi
{
	static public class NewsStringsMySql
	{
		static private string queryNewsString = "SELECT * from News;";
		static private string queryNewsByIdString = "SELECT * from News where newsID=@newsID;";
		static private string queryNewsPost = "INSERT INTO News (newsCategory,newsGenre,newsName,newsDescription,newsDateTime,newsMainPictureLink,newsVideoLink,newsPrefered) VALUES (@newsCategory, @newsGenre, @newsName, @newsDescription, @newsDateTime, @newsMainPictureLink, @newsVideoLink, @newsPrefered); SELECT * FROM News WHERE newsID = SCOPE_IDENTITY();";
		static private string queryNewsUpdate = "UPDATE News SET newsCategory = @newsCategory, newsGenre = @newsGenre, newsName = @newsName, newsDescription = @newsDescription, newsDateTime = @newsDateTime, newsMainPictureLink = @newsMainPictureLink, newsVideoLink = @newsVideoLink, newsPrefered = @newsPrefered  WHERE newsID = @newsID; SELECT * FROM News WHERE newsID = @newsID;";
		static private string queryNewsDelete = "DELETE FROM News WHERE newsID=@newsID;";
		static private string queryNewsTopSix = "SELECT TOP (6) FROM News;";

		static private string procedureNewsString = "CALL `tvcoil`.`GetAllNews`();";
		static private string procedureNewsByIdString = "CALL `tvcoil`.`GetNewsById`(@newsID);";
		static private string procedureNewsPost = "CALL `tvcoil`.`PostNews`(@newsCategory, @newsGenre, @newsName, @newsDescription, @newsDateTime, @newsMainPictureLink, @newsVideoLink, @newsPrefered);";
		static private string procedureNewsUpdate = "CALL `tvcoil`.`UpdateNews`(@newsID, @newsCategory, @newsGenre, @newsName, @newsDescription, @newsDateTime, @newsMainPictureLink, @newsVideoLink, @newsPrefered);";
		static private string procedureNewsDelete = "CALL `tvcoil`.`DeleteNews`(@newsID);";
		static private string procedureNewsTopSix = "CALL `tvcoil`.`TopSixNews`();";

		static public MySqlCommand GetAllNews()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryNewsString);
			else
				return CreateSqlCommand(procedureNewsString);
		}

		static public MySqlCommand GetNewsById(int newsId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(newsId, queryNewsByIdString);
			else
				return CreateSqlCommand(newsId, procedureNewsByIdString);
		}

		static public MySqlCommand PostNews(News news)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(news, queryNewsPost);
			else
				return CreateSqlCommand(news, procedureNewsPost);
		}

		static public MySqlCommand UpdateNews(News news)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(news, queryNewsUpdate);
			else
				return CreateSqlCommand(news, procedureNewsUpdate);
		}

		static public MySqlCommand DeleteNews(int newsId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(newsId, queryNewsDelete);
			else
				return CreateSqlCommand(newsId, procedureNewsDelete);
		}

		static public MySqlCommand TopSixNews()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryNewsTopSix);
			else
				return CreateSqlCommand(procedureNewsTopSix);
		}

		static private MySqlCommand CreateSqlCommand(News news, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

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

		static private MySqlCommand CreateSqlCommand(int newsID, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@newsID", newsID);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			return command;
		}











	}
}

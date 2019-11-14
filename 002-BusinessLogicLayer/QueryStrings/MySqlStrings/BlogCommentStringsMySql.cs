using MySql.Data.MySqlClient;

namespace IntTVapi
{
	static public class BlogCommentStringsMySql
	{
		static private string queryBlogCommentString = "SELECT * from BlogComment;";
		static private string queryBlogCommentByIdString = "SELECT * from BlogComment WHERE commentId = @commentId;";
		static private string queryBlogCommentByBlogIdString = "SELECT * from BlogComment WHERE blogId = @blogId;";
		static private string queryBlogCommentPost = "INSERT INTO BlogComment (blogId, commentContent) VALUES (@blogId, @commentContent); SELECT * FROM BlogComment WHERE commentId = SCOPE_IDENTITY();";
		static private string queryBlogCommentUpdate = "UPDATE BlogComment SET commentContent = @commentContent WHERE commentId = @commentId AND blogId = @blogId; SELECT * FROM BlogComment WHERE commentId = SCOPE_IDENTITY();";
		static private string queryBlogCommentDelete = "DELETE FROM BlogComment WHERE commentId = @commentId;";
		static private string queryBlogCommentTopSix = "SELECT TOP (6) FROM BlogComment;";


		static private string procedureBlogCommentString = "CALL `tvcoil`.`GetAllBlogComment`();";
		static private string procedureBlogCommentByIdString = "CALL `tvcoil`.`GetBlogCommentById`(@commentId);";
		static private string procedureBlogCommentByBlogIdString = "CALL `tvcoil`.`GetBlogCommentsByBlogId`(@blogId);";
		static private string procedureBlogCommentPost = "CALL `tvcoil`.`PostBlogComment`(@blogId, @commentContent);";
		static private string procedureBlogCommentUpdate = "CALL `tvcoil`.`UpdateBlogComment`(@commentId, @blogId, @commentContent);";
		static private string procedureBlogCommentDelete = "CALL `tvcoil`.`DeleteBlogComment`(@commentId);";
		static private string procedureBlogCommentTopSix = "CALL `tvcoil`.`TopSixBlogComment`();";


		static public MySqlCommand GetAllBlogComment()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryBlogCommentString);
			else
				return CreateSqlCommand(procedureBlogCommentString);
		}

		static public MySqlCommand GetBlogCommentById(int commentId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandc(commentId, queryBlogCommentByIdString);
			else
				return CreateSqlCommandc(commentId, procedureBlogCommentByIdString);
		}

		static public MySqlCommand GetBlogCommentsByBlogId(int blogId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandb(blogId, queryBlogCommentByBlogIdString);
			else
				return CreateSqlCommandb(blogId, procedureBlogCommentByBlogIdString);
		}

		static public MySqlCommand PostBlogComment(BlogComment blogComment)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(blogComment, queryBlogCommentPost);
			else
				return CreateSqlCommand(blogComment, procedureBlogCommentPost);
		}

		static public MySqlCommand UpdateBlogComment(BlogComment blogComment)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(blogComment, queryBlogCommentUpdate);
			else
				return CreateSqlCommand(blogComment, procedureBlogCommentUpdate);
		}

		static public MySqlCommand DeleteBlogComment(int commentId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandc(commentId, queryBlogCommentDelete);
			else
				return CreateSqlCommandc(commentId, procedureBlogCommentDelete);
		}

		static public MySqlCommand TopSixBlogComment()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryBlogCommentTopSix);
			else
				return CreateSqlCommand(procedureBlogCommentTopSix);
		}




		static private MySqlCommand CreateSqlCommand(BlogComment blogComment, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@commentId", blogComment.commentId);
			command.Parameters.AddWithValue("@blogId", blogComment.blogId);
			command.Parameters.AddWithValue("@commentContent", blogComment.commentContent);

			return command;
		}

		static private MySqlCommand CreateSqlCommandc(int commentId, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@commentId", commentId);

			return command;
		}

		static private MySqlCommand CreateSqlCommandb(int blogId, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@blogId", blogId);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			return command;
		}
	}
}

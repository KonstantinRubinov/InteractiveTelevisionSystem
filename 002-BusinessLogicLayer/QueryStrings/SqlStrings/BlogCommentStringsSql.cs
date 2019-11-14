using System.Data.SqlClient;

namespace IntTVapi
{
	static public class BlogCommentStringsSql
	{
		static private string queryBlogCommentString = "SELECT * from BlogComment;";
		static private string queryBlogCommentByIdString = "SELECT * from BlogComment WHERE commentId = @commentId;";
		static private string queryBlogCommentByBlogIdString = "SELECT * from BlogComment WHERE blogId = @blogId;";
		static private string queryBlogCommentPost = "INSERT INTO BlogComment (blogId, commentContent) VALUES (@blogId, @commentContent); SELECT * FROM BlogComment WHERE commentId = SCOPE_IDENTITY();";
		static private string queryBlogCommentUpdate = "UPDATE BlogComment SET commentContent = @commentContent WHERE commentId = @commentId AND blogId = @blogId; SELECT * FROM BlogComment WHERE commentId = SCOPE_IDENTITY();";
		static private string queryBlogCommentDelete = "DELETE FROM BlogComment WHERE commentId = @commentId;";
		static private string queryBlogCommentTopSix = "SELECT TOP (6) * FROM BlogComment;";

		static private string procedureBlogCommentString = "EXEC GetAllBlogComment;";
		static private string procedureBlogCommentByIdString = "EXEC GetBlogCommentById @commentId;";
		static private string procedureBlogCommentByBlogIdString = "EXEC GetBlogCommentsByBlogId @blogId;";
		static private string procedureBlogCommentPost = "EXEC PostBlogComment @blogId, @commentContent;";
		static private string procedureBlogCommentUpdate = "EXEC UpdateBlogComment @commentId, @blogId, @commentContent;";
		static private string procedureBlogCommentDelete = "EXEC DeleteBlogComment @commentId;";
		static private string procedureBlogCommentTopSix = "EXEC TopSixBlogComment;";

		static public SqlCommand GetAllBlogComment()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryBlogCommentString);
			else
				return CreateSqlCommand(procedureBlogCommentString);
		}

		static public SqlCommand GetBlogCommentById(int commentId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandc(commentId, queryBlogCommentByIdString);
			else
				return CreateSqlCommandc(commentId, procedureBlogCommentByIdString);
		}

		static public SqlCommand GetBlogCommentsByBlogId(int blogId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandb(blogId, queryBlogCommentByBlogIdString);
			else
				return CreateSqlCommandb(blogId, procedureBlogCommentByBlogIdString);
		}

		static public SqlCommand PostBlogComment(BlogComment blogComment)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(blogComment, queryBlogCommentPost);
			else
				return CreateSqlCommand(blogComment, procedureBlogCommentPost);
		}

		static public SqlCommand UpdateBlogComment(BlogComment blogComment)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(blogComment, queryBlogCommentUpdate);
			else
				return CreateSqlCommand(blogComment, procedureBlogCommentUpdate);
		}

		static public SqlCommand DeleteBlogComment(int commentId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommandc(commentId, queryBlogCommentDelete);
			else
				return CreateSqlCommandc(commentId, procedureBlogCommentDelete);
		}

		static public SqlCommand TopSixBlogComment()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryBlogCommentTopSix);
			else
				return CreateSqlCommand(procedureBlogCommentTopSix);
		}




		static private SqlCommand CreateSqlCommand(BlogComment blogComment, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@commentId", blogComment.commentId);
			command.Parameters.AddWithValue("@blogId", blogComment.blogId);
			command.Parameters.AddWithValue("@commentContent", blogComment.commentContent);

			return command;
		}

		static private SqlCommand CreateSqlCommandc(int commentId, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@commentId", commentId);

			return command;
		}

		static private SqlCommand CreateSqlCommandb(int blogId, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@blogId", blogId);

			return command;
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}
	}
}

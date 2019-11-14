using System.Data.SqlClient;

namespace IntTVapi
{
	static public class BlogStringsSql
	{
		static private string queryBlogString = "SELECT * from Blog;";
		static private string queryBlogByIdString = "SELECT * from Blog where blogId=@blogId;";
		static private string queryBlogPost = "INSERT INTO Blog (blogCategory, blogName, blogPublisher, blogContent, blogDate, blogMainPictureLink) VALUES (@blogCategory, @blogName, @blogPublisher, @blogContent, @blogDate, @blogMainPictureLink); SELECT * FROM Blog WHERE blogId = SCOPE_IDENTITY();";
		static private string queryBlogUpdate = "UPDATE Blog SET blogCategory = @blogCategory, blogName = @blogName, blogPublisher = @blogPublisher, blogContent = @blogContent, blogDate = @blogDate, blogMainPictureLink = @blogMainPictureLink WHERE blogId = @blogId; SELECT * FROM Blog WHERE blogId=@blogId;";
		static private string queryBlogDelete = "DELETE FROM Blog WHERE blogId=@blogId;";
		static private string queryBlogTopSix = "SELECT TOP (6) * FROM Blog;";

		static private string procedureBlogString = "EXEC GetAllBlog;";
		static private string procedureBlogByIdString = "EXEC GetBlogById @blogId;";
		static private string procedureBlogPost = "EXEC PostBlog @blogCategory, @blogName, @blogPublisher, @blogContent, @blogDate, @blogMainPictureLink;";
		static private string procedureBlogUpdate = "EXEC UpdateBlog @blogId, @blogCategory, @blogName, @blogPublisher, @blogContent, @blogDate, @blogMainPictureLink;";
		static private string procedureBlogDelete = "EXEC DeleteBlog @blogId;";
		static private string procedureBlogTopSix = "EXEC TopSixBlog;";

		static public SqlCommand GetAllBlog()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryBlogString);
			else
				return CreateSqlCommand(procedureBlogString);
		}

		static public SqlCommand GetBlogById(int blogId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(blogId, queryBlogByIdString);
			else
				return CreateSqlCommand(blogId, procedureBlogByIdString);
		}

		static public SqlCommand PostBlog(Blog blog)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(blog, queryBlogPost);
			else
				return CreateSqlCommand(blog, procedureBlogPost);
		}

		static public SqlCommand UpdateBlog(Blog blog)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(blog, queryBlogUpdate);
			else
				return CreateSqlCommand(blog, procedureBlogUpdate);
		}

		static public SqlCommand DeleteBlog(int blogId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(blogId, queryBlogDelete);
			else
				return CreateSqlCommand(blogId, procedureBlogDelete);
		}

		static public SqlCommand TopSixBlog()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryBlogTopSix);
			else
				return CreateSqlCommand(procedureBlogTopSix);
		}

		static private SqlCommand CreateSqlCommand(Blog blog, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@blogId", blog.blogId);
			command.Parameters.AddWithValue("@blogCategory", blog.blogCategory);
			command.Parameters.AddWithValue("@blogName", blog.blogName);
			command.Parameters.AddWithValue("@blogPublisher", blog.blogPublisher);
			command.Parameters.AddWithValue("@blogContent", blog.blogContent);
			command.Parameters.AddWithValue("@blogDate", blog.blogDate);
			command.Parameters.AddWithValue("@blogMainPictureLink", blog.blogMainPictureLink);

			return command;
		}

		static private SqlCommand CreateSqlCommand(int blogId, string commandText)
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

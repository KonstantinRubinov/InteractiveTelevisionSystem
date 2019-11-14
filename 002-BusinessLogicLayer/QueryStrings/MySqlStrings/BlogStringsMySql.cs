using MySql.Data.MySqlClient;

namespace IntTVapi
{
	static public class BlogStringsMySql
	{
		static private string queryBlogString = "SELECT * from Blog;";
		static private string queryBlogByIdString = "SELECT * from Blog where blogId=@blogId;";
		static private string queryBlogPost = "INSERT INTO Blog (blogCategory, blogName, blogPublisher, blogContent, blogDate, blogMainPictureLink) VALUES (@blogCategory, @blogName, @blogPublisher, @blogContent, @blogDate, @blogMainPictureLink); SELECT * FROM Blog WHERE blogId = SCOPE_IDENTITY();";
		static private string queryBlogUpdate = "UPDATE Blog SET blogCategory = @blogCategory, blogName = @blogName, blogPublisher = @blogPublisher, blogContent = @blogContent, blogDate = @blogDate, blogMainPictureLink = @blogMainPictureLink WHERE blogId = @blogId; SELECT * FROM Blog WHERE blogId=@blogId;";
		static private string queryBlogDelete = "DELETE FROM Blog WHERE blogId=@blogId;";
		static private string queryBlogTopSix = "SELECT TOP (6) FROM Blog;";

		static private string procedureBlogString = "CALL `tvcoil`.`GetAllBlog`();";
		static private string procedureBlogByIdString = "CALL `tvcoil`.`GetBlogById`(@blogId);";
		static private string procedureBlogPost = "CALL `tvcoil`.`PostBlog`(@blogCategory, @blogName, @blogPublisher, @blogContent, @blogDate, @blogMainPictureLink);";
		static private string procedureBlogUpdate = "CALL `tvcoil`.`UpdateBlog`(@blogId, @blogCategory, @blogName, @blogPublisher, @blogContent, @blogDate, @blogMainPictureLink);";
		static private string procedureBlogDelete = "CALL `tvcoil`.`DeleteBlog`(@blogId);";
		static private string procedureBlogTopSix = "CALL `tvcoil`.`TopSixBlog`();";

		static public MySqlCommand GetAllBlog()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryBlogString);
			else
				return CreateSqlCommand(procedureBlogString);
		}

		static public MySqlCommand GetBlogById(int blogId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(blogId, queryBlogByIdString);
			else
				return CreateSqlCommand(blogId, procedureBlogByIdString);
		}

		static public MySqlCommand PostBlog(Blog blog)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(blog, queryBlogPost);
			else
				return CreateSqlCommand(blog, procedureBlogPost);
		}

		static public MySqlCommand UpdateBlog(Blog blog)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(blog, queryBlogUpdate);
			else
				return CreateSqlCommand(blog, procedureBlogUpdate);
		}

		static public MySqlCommand DeleteBlog(int blogId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(blogId, queryBlogDelete);
			else
				return CreateSqlCommand(blogId, procedureBlogDelete);
		}

		static public MySqlCommand TopSixBlog()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryBlogTopSix);
			else
				return CreateSqlCommand(procedureBlogTopSix);
		}

		static private MySqlCommand CreateSqlCommand(Blog blog, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@blogId", blog.blogId);
			command.Parameters.AddWithValue("@blogCategory", blog.blogCategory);
			command.Parameters.AddWithValue("@blogName", blog.blogName);
			command.Parameters.AddWithValue("@blogPublisher", blog.blogPublisher);
			command.Parameters.AddWithValue("@blogContent", blog.blogContent);
			command.Parameters.AddWithValue("@blogDate", blog.blogDate);
			command.Parameters.AddWithValue("@blogMainPictureLink", blog.blogMainPictureLink);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(int blogId, string commandText)
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

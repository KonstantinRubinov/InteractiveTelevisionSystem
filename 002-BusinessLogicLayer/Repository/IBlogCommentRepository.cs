using System.Collections.Generic;

namespace IntTVapi
{
	public interface IBlogCommentRepository
	{
		List<BlogComment> GetAllBlogComments();
		BlogComment GetBlogCommentById(int id);
		List<BlogComment> GetBlogCommentsByBlogId(int blogId);
		BlogComment AddBlogComment(BlogComment value);
		BlogComment UpdateBlogComment(BlogComment value);
		int DeleteBlogComment(int id);
	}
}

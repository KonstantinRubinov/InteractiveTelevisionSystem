using System.Collections.Generic;

namespace IntTVapi
{
	public interface IBlogRepository
	{
		List<Blog> GetAllBlogs();
		Blog GetBlogById(int blogId);
		Blog AddBlog(Blog blog);
		Blog UpdateBlog(Blog blog);
		int DeleteBlog(int blogId);
	}
}

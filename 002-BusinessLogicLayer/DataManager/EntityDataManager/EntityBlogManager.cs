using IntTVapi.EntityDataBase;
using System.Collections.Generic;
using System.Linq;

namespace IntTVapi
{
	public class EntityBlogManager : EntityBaseManager, IBlogRepository
	{
		public List<Blog> GetAllBlogs()
		{
			var resultQuary = DB.BLOGs.Select(b => new Blog
			{
				blogId = b.blogId,
				blogCategory = b.blogCategory,
				blogName = b.blogName,
				blogPublisher = b.blogPublisher,
				blogContent = b.blogContent,
				blogDate = b.blogDate,
				blogMainPictureLink = b.blogMainPictureLink
			});

			var resultSP = DB.GetAllBlog().Select(b => new Blog
			{
				blogId = b.blogId,
				blogCategory = b.blogCategory,
				blogName = b.blogName,
				blogPublisher = b.blogPublisher,
				blogContent = b.blogContent,
				blogDate = b.blogDate,
				blogMainPictureLink = b.blogMainPictureLink
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public Blog GetBlogById(int blogId)
		{
			var resultQuary = DB.BLOGs.Where(b => b.blogId == blogId).Select(b => new Blog
			{
				blogId = b.blogId,
				blogCategory = b.blogCategory,
				blogName = b.blogName,
				blogPublisher = b.blogPublisher,
				blogContent = b.blogContent,
				blogDate = b.blogDate,
				blogMainPictureLink = b.blogMainPictureLink
			});

			var resultSP = DB.GetBlogById(blogId).Select(b => new Blog
			{
				blogId = b.blogId,
				blogCategory = b.blogCategory,
				blogName = b.blogName,
				blogPublisher = b.blogPublisher,
				blogContent = b.blogContent,
				blogDate = b.blogDate,
				blogMainPictureLink = b.blogMainPictureLink
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public Blog AddBlog(Blog blog)
		{
			var resultSP = DB.PostBlog(blog.blogCategory, blog.blogName, blog.blogPublisher, blog.blogContent, blog.blogDate, blog.blogMainPictureLink).Select(b => new Blog
			{
				blogId = b.blogId,
				blogCategory = b.blogCategory,
				blogName = b.blogName,
				blogPublisher = b.blogPublisher,
				blogContent = b.blogContent,
				blogDate = b.blogDate,
				blogMainPictureLink = b.blogMainPictureLink
			});

			if (GlobalVariable.queryType == 0)
			{
				BLOG blo = new BLOG
				{
					blogCategory = blog.blogCategory,
					blogName = blog.blogName,
					blogPublisher = blog.blogPublisher,
					blogContent = blog.blogContent,
					blogDate = blog.blogDate,
					blogMainPictureLink = blog.blogMainPictureLink
				};

				DB.BLOGs.Add(blo);
				DB.SaveChanges();
				return GetBlogById(blo.blogId);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public Blog UpdateBlog(Blog blog)
		{
			var resultSP = DB.UpdateBlog(blog.blogId, blog.blogCategory, blog.blogName, blog.blogPublisher, blog.blogContent, blog.blogDate, blog.blogMainPictureLink).Select(b => new Blog
			{
				blogId = b.blogId,
				blogCategory = b.blogCategory,
				blogName = b.blogName,
				blogPublisher = b.blogPublisher,
				blogContent = b.blogContent,
				blogDate = b.blogDate,
				blogMainPictureLink = b.blogMainPictureLink
			});

			if (GlobalVariable.queryType == 0)
			{
				BLOG blo = DB.BLOGs.Where(b => b.blogId == blog.blogId).SingleOrDefault();
				if (blo == null)
					return null;
				blo.blogId = blog.blogId;
				blo.blogCategory = blog.blogCategory;
				blo.blogName = blog.blogName;
				blo.blogPublisher = blog.blogPublisher;
				blo.blogContent = blog.blogContent;
				blo.blogDate = blog.blogDate;
				blo.blogMainPictureLink = blog.blogMainPictureLink;
				DB.SaveChanges();
				return GetBlogById(blog.blogId);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public int DeleteBlog(int blogId)
		{
			var resultSP = DB.DeleteBlog(blogId);

			if (GlobalVariable.queryType == 0)
			{
				BLOG blo = DB.BLOGs.Where(b => b.blogId == blogId).SingleOrDefault();
				DB.BLOGs.Attach(blo);
				if (blo == null)
					return 0;
				DB.BLOGs.Remove(blo);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}
	}
}

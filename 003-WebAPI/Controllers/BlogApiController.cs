using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IntTVapi
{
	[EnableCors("*", "*", "*")]
	[RoutePrefix("api")]
	public class BlogApiController : ApiController
    {
		private IBlogRepository blogRepository;
		public BlogApiController()
		{
			if (GlobalVariable.logicType == 0)
				blogRepository = new EntityBlogManager();
			else if (GlobalVariable.logicType == 1)
				blogRepository = new SqlBlogManager();
			else
				blogRepository = new MySqlBlogManager();
		}

		[HttpGet]
		[Route("blogs")]
		public HttpResponseMessage GetAllBlogs()
		{
			try
			{
				List<Blog> allblogs = blogRepository.GetAllBlogs();
				//if (allblogs == null || allblogs.Count < 1)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The blogs record couldn't be found.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, allblogs);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("blogs/{id}")]
		public HttpResponseMessage GetBlogById(int id)
		{
			try
			{
				Blog oneBlog = blogRepository.GetBlogById(id);
				//if (oneBlog == null)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The blog record couldn't be found.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, oneBlog);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("blogs")]
		public HttpResponseMessage AddBlog(Blog blog)
		{
			try
			{
				if (blog == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				Blog addedBlog = blogRepository.AddBlog(blog);
				//if (addedBlog == null)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The blog record couldn't be added.");
				//}
				return Request.CreateResponse(HttpStatusCode.Created, addedBlog);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPut]
		[Route("blogs/{id}")]
		public HttpResponseMessage UpdateBlog(int id, Blog blog)
		{
			try
			{
				if (blog == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				blog.blogId = id;
				Blog updatedBlog = blogRepository.UpdateBlog(blog);
				//if (updatedBlog == null)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The blog record couldn't be updated.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, updatedBlog);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("blogs/{id}")]
		public HttpResponseMessage DeleteBlog(int id)
		{
			try
			{
				int i = blogRepository.DeleteBlog(id);
				if (i > 0)
				{
					return Request.CreateResponse(HttpStatusCode.NoContent);
				}
				return Request.CreateResponse(HttpStatusCode.InternalServerError);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}
	}
}

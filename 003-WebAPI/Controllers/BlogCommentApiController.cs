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
	public class BlogCommentApiController : ApiController
    {
		private IBlogCommentRepository blogCommentRepository;
		public BlogCommentApiController()
		{
			if (GlobalVariable.logicType == 0)
				blogCommentRepository = new EntityBlogCommentManager();
			else if (GlobalVariable.logicType == 1)
				blogCommentRepository = new SqlBlogCommentManager();
			else
				blogCommentRepository = new MySqlBlogCommentManager();
		}

		[HttpGet]
		[Route("blogComments")]
		public HttpResponseMessage GetAllBlogComments()
		{
			try
			{
				List<BlogComment> allBlogComments = blogCommentRepository.GetAllBlogComments();
				//if (allBlogComments == null || allBlogComments.Count < 1)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The BlogComments record couldn't be found.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, allBlogComments);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("blogComments/{id}")]
		public HttpResponseMessage GetBlogCommentById(int id)
		{
			try
			{
				BlogComment oneBlogComment = blogCommentRepository.GetBlogCommentById(id);
				//if (oneBlogComment == null)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The BlogComment record couldn't be found.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, oneBlogComment);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("blogComments/forBlog/{id}")]
		public HttpResponseMessage GetBlogCommentsByBlogId(int id)
		{
			try
			{
				List<BlogComment> blogComments = blogCommentRepository.GetBlogCommentsByBlogId(id);
				//if (blogComments == null || blogComments.Count < 1)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The BlogComments record couldn't be found.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, blogComments);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("blogComments")]
		public HttpResponseMessage AddBlogComment(BlogComment blogComment)
		{
			try
			{
				if (blogComment == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				BlogComment addedBlogComment = blogCommentRepository.AddBlogComment(blogComment);
				//if (addedBlogComment == null)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The blogComment record couldn't be added.");
				//}
				return Request.CreateResponse(HttpStatusCode.Created, addedBlogComment);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPut]
		[Route("blogComments/{id}")]
		public HttpResponseMessage UpdateBlogComment(int id, BlogComment blogComment)
		{
			try
			{
				if (blogComment == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				blogComment.commentId = id;
				BlogComment updatedBlogComment = blogCommentRepository.UpdateBlogComment(blogComment);
				//if (updatedBlogComment == null)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The blogComment record couldn't be updated.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, updatedBlogComment);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("blogComments/{id}")]
		public HttpResponseMessage DeleteBlogComment(int id)
		{
			try
			{
				int i = blogCommentRepository.DeleteBlogComment(id);
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

using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace IntTVapi
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BlogCommentService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select BlogCommentService.svc or BlogCommentService.svc.cs at the Solution Explorer and start debugging.
	public class BlogCommentService : IBlogCommentService
	{
		private IBlogCommentRepository blogCommentRepository;
		public BlogCommentService()
		{
			if (GlobalVariable.logicType == 0)
				blogCommentRepository = new EntityBlogCommentManager();
			else if (GlobalVariable.logicType == 1)
				blogCommentRepository = new SqlBlogCommentManager();
			else
				blogCommentRepository = new MySqlBlogCommentManager();
		}

		public HttpResponseMessage GetAllBlogComments()
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(blogCommentRepository.GetAllBlogComments()))
				};
				return hrm;
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(errors.ToString())
				};
				return hr;
			}
		}

		public HttpResponseMessage GetBlogCommentById(int commentId)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(blogCommentRepository.GetBlogCommentById(commentId)))
				};
				return hrm;
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(errors.ToString())
				};
				return hr;
			}
		}

		public HttpResponseMessage GetBlogCommentsByBlogId(int blogId)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(blogCommentRepository.GetBlogCommentsByBlogId(blogId)))
				};
				return hrm;
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(errors.ToString())
				};
				return hr;
			}
		}

		public HttpResponseMessage AddBlogComment(BlogComment blogComment)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.Created)
				{
					Content = new StringContent(JsonConvert.SerializeObject(blogCommentRepository.AddBlogComment(blogComment)))
				};
				return hrm;
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(errors.ToString())
				};
				return hr;
			}
		}

		public HttpResponseMessage UpdateBlogComment(int updateById, BlogComment blogComment)
		{
			try
			{
				blogComment.commentId = updateById;
				BlogComment updatedComment = blogCommentRepository.UpdateBlogComment(blogComment);
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(updatedComment))
				};
				return hrm;
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(errors.ToString())
				};
				return hr;
			}
		}

		public HttpResponseMessage DeleteBlogComment(int deleteById)
		{
			try
			{
				int i = blogCommentRepository.DeleteBlogComment(deleteById);

				if (i > 0)
				{
					HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.NoContent)
					{
					};
					return hrm;
				}
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
				};
				return hr;
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(errors.ToString())
				};
				return hr;
			}
		}
	}
}

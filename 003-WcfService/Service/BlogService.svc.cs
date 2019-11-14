using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace IntTVapi
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BlogService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select BlogService.svc or BlogService.svc.cs at the Solution Explorer and start debugging.
	public class BlogService : IBlogService
	{
		private IBlogRepository blogRepository;
		public BlogService()
		{
			if (GlobalVariable.logicType == 0)
				blogRepository = new EntityBlogManager();
			else if (GlobalVariable.logicType == 1)
				blogRepository = new SqlBlogManager();
			else
				blogRepository = new MySqlBlogManager();
		}

		public HttpResponseMessage GetAllBlogs()
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(blogRepository.GetAllBlogs()))
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

		public HttpResponseMessage GetBlogById(int blogId)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(blogRepository.GetBlogById(blogId)))
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

		public HttpResponseMessage AddBlog(Blog blog)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.Created)
				{
					Content = new StringContent(JsonConvert.SerializeObject(blogRepository.AddBlog(blog)))
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

		public HttpResponseMessage UpdateBlog(int updateById, Blog blog)
		{
			try
			{
				blog.blogId = updateById;
				Blog updatedBlog = blogRepository.UpdateBlog(blog);
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(updatedBlog))
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

		public HttpResponseMessage DeleteBlog(int deleteById)
		{
			try
			{
				int i = blogRepository.DeleteBlog(deleteById);

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

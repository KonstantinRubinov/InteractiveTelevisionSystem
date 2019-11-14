using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IntTVapi.Controllers
{
	[EnableCors("*", "*", "*")]
	[RoutePrefix("api")]
	public class NewsApiController : ApiController
    {
		private INewsRepository newsRepository;
		public NewsApiController()
		{
			if (GlobalVariable.logicType == 0)
				newsRepository = new EntityNewsManager();
			else if (GlobalVariable.logicType == 1)
				newsRepository = new SqlNewsManager();
			else
				newsRepository = new MySqlNewsManager();
		}

		[HttpGet]
		[Route("news")]
		public HttpResponseMessage GetAllNews()
		{
			try
			{
				List<News> allNews = newsRepository.GetAllNews();
				//if (allNews == null || allNews.Count < 1)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The news record couldn't be found.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, allNews);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("news/{id}")]
		public HttpResponseMessage GetNewsById(int id)
		{
			try
			{
				News oneNews = newsRepository.GetNewsById(id);
				//if (oneNews == null)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The news record couldn't be found.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, oneNews);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("news")]
		public HttpResponseMessage AddNews(News news)
		{
			try
			{
				if (news == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				News addedNews = newsRepository.AddNews(news);
				//if (addedNews == null)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The news record couldn't be added.");
				//}
				return Request.CreateResponse(HttpStatusCode.Created, addedNews);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPut]
		[Route("news/{id}")]
		public HttpResponseMessage UpdateProduct(int id, News news)
		{
			try
			{
				if (news == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				news.newsID = id;
				News updatedNews = newsRepository.UpdateNews(news);
				//if (updatedNews == null)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The news record couldn't be updated.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, updatedNews);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("news/{id}")]
		public HttpResponseMessage DeleteNews(int id)
		{
			try
			{
				int i = newsRepository.DeleteNews(id);
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

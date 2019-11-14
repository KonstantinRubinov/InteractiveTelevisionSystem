using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace IntTVapi
{
	public class NewsService : INewsService
	{
		private INewsRepository newsRepository;
		public NewsService()
		{
			if (GlobalVariable.logicType == 0)
				newsRepository = new EntityNewsManager();
			else if (GlobalVariable.logicType == 1)
				newsRepository = new SqlNewsManager();
			else
				newsRepository = new MySqlNewsManager();
		}

		public HttpResponseMessage GetAllNews()
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(newsRepository.GetAllNews()))
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

		public HttpResponseMessage GetNewsById(int newsID)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(newsRepository.GetNewsById(newsID)))
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

		public HttpResponseMessage AddNews(News news)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.Created)
				{
					Content = new StringContent(JsonConvert.SerializeObject(newsRepository.AddNews(news)))
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

		public HttpResponseMessage UpdateNews(int updateById, News news)
		{
			try
			{
				news.newsID = updateById;
				News updatedNews = newsRepository.UpdateNews(news);

				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(updatedNews))
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

		public HttpResponseMessage DeleteNews(int deleteById)
		{
			try
			{
				int i = newsRepository.DeleteNews(deleteById);

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

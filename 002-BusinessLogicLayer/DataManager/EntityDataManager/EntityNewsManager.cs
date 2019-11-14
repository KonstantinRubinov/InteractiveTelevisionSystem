using IntTVapi.EntityDataBase;
using System.Collections.Generic;
using System.Linq;

namespace IntTVapi
{
	public class EntityNewsManager : EntityBaseManager, INewsRepository
	{
		public List<News> GetAllNews()
		{
			var resultQuary = DB.NEWS.Select(n => new News
			{
				newsID = n.newsID,
				newsCategory = n.newsCategory,
				newsGenre = n.newsGenre,
				newsName = n.newsName,
				newsDescription = n.newsDescription,
				newsDateTime = n.newsDateTime,
				newsMainPictureLink = n.newsMainPictureLink,
				newsVideoLink = n.newsVideoLink,
				newsPrefered = n.newsPrefered
			});

			var resultSP = DB.GetAllNews().Select(n => new News
			{
				newsID = n.newsID,
				newsCategory = n.newsCategory,
				newsGenre = n.newsGenre,
				newsName = n.newsName,
				newsDescription = n.newsDescription,
				newsDateTime = n.newsDateTime,
				newsMainPictureLink = n.newsMainPictureLink,
				newsVideoLink = n.newsVideoLink,
				newsPrefered = n.newsPrefered
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public News GetNewsById(int newsID)
		{
			var resultQuary = DB.NEWS.Where(n => n.newsID == newsID).Select(n => new News
			{
				newsID = n.newsID,
				newsCategory = n.newsCategory,
				newsGenre = n.newsGenre,
				newsName = n.newsName,
				newsDescription = n.newsDescription,
				newsDateTime = n.newsDateTime,
				newsMainPictureLink = n.newsMainPictureLink,
				newsVideoLink = n.newsVideoLink,
				newsPrefered = n.newsPrefered
			});

			var resultSP = DB.GetNewsById(newsID).Select(n => new News
			{
				newsID = n.newsID,
				newsCategory = n.newsCategory,
				newsGenre = n.newsGenre,
				newsName = n.newsName,
				newsDescription = n.newsDescription,
				newsDateTime = n.newsDateTime,
				newsMainPictureLink = n.newsMainPictureLink,
				newsVideoLink = n.newsVideoLink,
				newsPrefered = n.newsPrefered
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public News AddNews(News value)
		{
			var resultSP = DB.PostNews(value.newsCategory, value.newsGenre, value.newsName, value.newsDescription, value.newsDateTime, value.newsMainPictureLink, value.newsVideoLink, value.newsPrefered).Select(n => new News
			{
				newsID = n.newsID,
				newsCategory = n.newsCategory,
				newsGenre = n.newsGenre,
				newsName = n.newsName,
				newsDescription = n.newsDescription,
				newsDateTime = n.newsDateTime,
				newsMainPictureLink = n.newsMainPictureLink,
				newsVideoLink = n.newsVideoLink,
				newsPrefered = n.newsPrefered
			});

			if (GlobalVariable.queryType == 0)
			{
				NEWS news = new NEWS
				{
					newsCategory = value.newsCategory,
					newsGenre = value.newsGenre,
					newsName = value.newsName,
					newsDescription = value.newsDescription,
					newsDateTime = value.newsDateTime,
					newsMainPictureLink = value.newsMainPictureLink,
					newsVideoLink = value.newsVideoLink,
					newsPrefered = value.newsPrefered
				};
				DB.NEWS.Add(news);
				DB.SaveChanges();
				return GetNewsById(news.newsID);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public News UpdateNews(News value)
		{
			var resultSP = DB.UpdateNews(value.newsID, value.newsCategory, value.newsGenre, value.newsName, value.newsDescription, value.newsDateTime, value.newsMainPictureLink, value.newsVideoLink, value.newsPrefered).Select(n => new News
			{
				newsID = n.newsID,
				newsCategory = n.newsCategory,
				newsGenre = n.newsGenre,
				newsName = n.newsName,
				newsDescription = n.newsDescription,
				newsDateTime = n.newsDateTime,
				newsMainPictureLink = n.newsMainPictureLink,
				newsVideoLink = n.newsVideoLink,
				newsPrefered = n.newsPrefered
			});

			if (GlobalVariable.queryType == 0)
			{
				NEWS news = DB.NEWS.Where(ne => ne.newsID == value.newsID).SingleOrDefault();
				if (news == null)
					return null;
				news.newsID = value.newsID;
				news.newsCategory = value.newsCategory;
				news.newsGenre = value.newsGenre;
				news.newsName = value.newsName;
				news.newsDescription = value.newsDescription;
				news.newsDateTime = value.newsDateTime;
				news.newsMainPictureLink = value.newsMainPictureLink;
				news.newsVideoLink = value.newsVideoLink;
				news.newsPrefered = value.newsPrefered;
				DB.SaveChanges();
				return GetNewsById(news.newsID);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public int DeleteNews(int id)
		{
			var resultSP = DB.DeleteNews(id);

			if (GlobalVariable.queryType == 0)
			{
				NEWS news = DB.NEWS.Where(ne => ne.newsID == id).SingleOrDefault();
				DB.NEWS.Attach(news);
				if (news == null)
					return 0;
				DB.NEWS.Remove(news);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}
	}
}

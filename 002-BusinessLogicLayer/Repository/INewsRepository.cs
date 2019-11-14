using System.Collections.Generic;

namespace IntTVapi
{
	public interface INewsRepository
	{
		List<News> GetAllNews();
		News GetNewsById(int id);
		News AddNews(News value);
		News UpdateNews(News value);
		int DeleteNews(int id);
	}
}

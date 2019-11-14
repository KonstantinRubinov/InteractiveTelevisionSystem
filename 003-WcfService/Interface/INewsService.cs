using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace IntTVapi
{
	[ServiceContract]
	public interface INewsService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "News/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllNews();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "News/?newsID={newsID}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetNewsById(int newsID);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "News/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage AddNews(News news);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "News/?updateById={updateById}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage UpdateNews(int updateById, News news);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "News/?deleteById={deleteById}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeleteNews(int deleteById);
	}
}

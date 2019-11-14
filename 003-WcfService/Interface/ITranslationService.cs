using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace IntTVapi
{
	[ServiceContract]
	public interface ITranslationService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Translations/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllTranslations();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Translations/?translationKey={translationKey}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetTranslationByKey(string translationKey);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Translations/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage AddTranslation(Translation translation);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "Translations/?updateByKey={updateByKey}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage UpdateTranslation(string updateByKey, Translation translation);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "Translations/?deleteByKey={deleteByKey}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeleteTranslation(string deleteByKey);
	}
}

using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace IntTVapi
{
	[ServiceContract]
	public interface IProgramService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Programs/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllPrograms();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Programs/?programID={programID}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetProgramById(int programID);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Programs/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage AddProgram(Program program);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "Programs/?updateById={updateById}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage UpdateProgram(int updateById, Program program);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "Programs/?deleteById={deleteById}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeleteProgram(int deleteById);
	}
}

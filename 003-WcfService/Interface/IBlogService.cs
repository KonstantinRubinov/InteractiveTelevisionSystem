using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace IntTVapi
{
	[ServiceContract]
	public interface IBlogService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Blogs/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllBlogs();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "Blogs/?blogId={blogId}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetBlogById(int blogId);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Blogs/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage AddBlog(Blog blog);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "Blogs/?updateById={updateById}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage UpdateBlog(int updateById, Blog blog);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "Blogs/?deleteById={deleteById}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeleteBlog(int deleteById);
	}
}

using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace IntTVapi
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBlogCommentService" in both code and config file together.
	[ServiceContract]
	public interface IBlogCommentService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "BlogComments/all/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetAllBlogComments();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "BlogComments/?commentId={commentId}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetBlogCommentById(int commentId);

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "BlogComments/?blogId={blogId}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage GetBlogCommentsByBlogId(int blogId);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Blogs/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage AddBlogComment(BlogComment blogComment);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "Blogs/?updateById={updateById}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage UpdateBlogComment(int updateById, BlogComment blogComment);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "Blogs/?deleteById={deleteById}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		HttpResponseMessage DeleteBlogComment(int deleteById);
	}
}

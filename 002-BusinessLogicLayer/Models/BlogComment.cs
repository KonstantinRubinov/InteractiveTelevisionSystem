using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace IntTVapi
{
	[DataContract]
	public class BlogComment/* : IEnumerable*/
	{
		private int _commentId;
		private int _blogId;
		private string _commentContent;

		[DataMember]
		public int commentId {
			get { return _commentId; }
			set { _commentId = value; }
		}

		[DataMember]
		[Required]
		public int blogId {
			get { return _blogId; }
			set { _blogId = value; }
		}

		[DataMember]
		[Required]
		public string commentContent {
			get { return _commentContent; }
			set { _commentContent = value; }
		}

		public override string ToString()
		{
			return
				commentId + " " +
				blogId + " " +
				commentContent;
		}

		public static BlogComment ToObject(DataRow reader)
		{
			BlogComment blogComment = new BlogComment();
			blogComment.commentId = int.Parse(reader[0].ToString());
			blogComment.blogId = int.Parse(reader[1].ToString());
			blogComment.commentContent = reader[2].ToString();

			Debug.WriteLine("BlogComment:" + blogComment.ToString());
			return blogComment;
		}

		//public IEnumerator GetEnumerator()
		//{
		//	return new BlogCommentEnumerator(this);
		//}
	}



	class BlogCommentEnumerator : IEnumerator
	{
		private BlogComment blogComment;
		private int index = 0;

		public BlogCommentEnumerator(BlogComment blogComment)
		{
			this.blogComment = blogComment;
		}

		public object Current // החזרת הפריט הנוכחי מהאוסף
		{
			get
			{
				switch (index)
				{
					case 1: return blogComment.commentId;
					case 2: return blogComment.blogId;
					case 3: return blogComment.commentContent;
					default: return blogComment.commentId;
				}
			}
		}

		public bool MoveNext() // הזזה לפריט הבא באוסף
		{
			index++;
			return index <= 3;
		}

		public void Reset() // איפוס הריצה על האוסף
		{
			index = 0;
		}
	}


}

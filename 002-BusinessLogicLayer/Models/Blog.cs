using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace IntTVapi
{
	[DataContract]
	public class Blog/* : IEnumerable*/
	{
		private int _blogId;
		private string _blogCategory;
		private string _blogName;
		private string _blogPublisher;
		private string _blogContent;
		private DateTime _blogDate;
		private string _blogMainPictureLink;

		[DataMember]
		public int blogId {
			get { return _blogId; }
			set { _blogId = value; }
		}

		[DataMember]
		[Required]
		public string blogCategory {
			get { return _blogCategory; }
			set { _blogCategory = value; }
		}

		[DataMember]
		[Required]
		public string blogName {
			get { return _blogName; }
			set { _blogName = value; }
		}

		[DataMember]
		[Required]
		public string blogPublisher {
			get { return _blogPublisher; }
			set { _blogPublisher = value; }
		}

		[DataMember]
		[Required]
		public string blogContent {
			get { return _blogContent; }
			set { _blogContent = value; }
		}

		[DataMember]
		[Required]
		public DateTime blogDate {
			get { return _blogDate; }
			set { _blogDate = value; }
		}

		[DataMember]
		[Required]
		public string blogMainPictureLink {
			get { return _blogMainPictureLink; }
			set { _blogMainPictureLink = value; }
		}

		public override string ToString()
		{
			return
				blogId + " " +
				blogCategory + " " +
				blogName + " " +
				blogPublisher + " " +
				blogContent + " " +
				blogDate + " " +
				blogMainPictureLink;
		}

		public static Blog ToObject(DataRow reader)
		{
			Blog blog = new Blog();
			blog.blogId = int.Parse(reader[0].ToString());
			blog.blogCategory = reader[1].ToString();
			blog.blogName = reader[2].ToString();
			blog.blogPublisher = reader[3].ToString();
			blog.blogContent = reader[4].ToString();
			blog.blogDate = DateTime.Parse(reader[5].ToString());
			blog.blogMainPictureLink = reader[6].ToString();

			Debug.WriteLine("Blog:" + blog.ToString());
			return blog;
		}

		//public IEnumerator GetEnumerator()
		//{
		//	return new BlogEnumerator(this);
		//}

	}

	class BlogEnumerator : IEnumerator
	{
		private Blog blog;
		private int index = 0;

		public BlogEnumerator(Blog blog)
		{
			this.blog = blog;
		}

		public object Current // החזרת הפריט הנוכחי מהאוסף
		{
			get
			{
				switch (index)
				{
					case 1: return blog.blogId;
					case 2: return blog.blogCategory;
					case 3: return blog.blogName;
					case 4: return blog.blogPublisher;
					case 5: return blog.blogContent;
					case 6: return blog.blogDate;
					case 7: return blog.blogMainPictureLink;
					default: return blog.blogId;
				}
			}
		}

		public bool MoveNext() // הזזה לפריט הבא באוסף
		{
			index++;
			return index <= 7;
		}

		public void Reset() // איפוס הריצה על האוסף
		{
			index = 0;
		}
	}
}

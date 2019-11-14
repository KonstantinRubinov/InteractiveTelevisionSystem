using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace IntTVapi
{
	[DataContract]
	public class News/* : IEnumerable*/
	{
		private int _newsID;
		private string _newsCategory;
		private string _newsGenre;
		private string _newsName;
		private string _newsDescription;
		private DateTime _newsDateTime;
		private string _newsMainPictureLink;
		private string _newsVideoLink;
		private bool _newsPrefered;

		[DataMember]
		public int newsID {
			get { return _newsID; }
			set { _newsID = value; }
		}

		[DataMember]
		[Required]
		public string newsCategory {
			get { return _newsCategory; }
			set { _newsCategory = value; }
		}

		[DataMember]
		[Required]
		public string newsGenre {
			get { return _newsGenre; }
			set { _newsGenre = value; }
		}

		[DataMember]
		[Required]
		public string newsName {
			get { return _newsName; }
			set { _newsName = value; }
		}

		[DataMember]
		[Required]
		public string newsDescription {
			get { return _newsDescription; }
			set { _newsDescription = value; }
		}

		[DataMember]
		[Required]
		public DateTime newsDateTime {
			get { return _newsDateTime; }
			set { _newsDateTime = value; }
		}

		[DataMember]
		[Required]
		public string newsMainPictureLink {
			get { return _newsMainPictureLink; }
			set { _newsMainPictureLink = value; }
		}

		[DataMember]
		[Required]
		public string newsVideoLink {
			get { return _newsVideoLink; }
			set { _newsVideoLink = value; }
		}

		[DataMember]
		[Required]
		public bool newsPrefered {
			get { return _newsPrefered; }
			set { _newsPrefered = value; }
		}

		public override string ToString()
		{
			return
				newsID + " " +
				newsCategory + " " +
				newsGenre + " " +
				newsName + " " +
				newsDescription + " " +
				newsDateTime + " " +
				newsMainPictureLink + " " +
				newsVideoLink + " " +
				newsPrefered;
		}

		public static News ToObject(DataRow reader)
		{
			News news = new News();
			news.newsID = int.Parse(reader[0].ToString());
			news.newsCategory = reader[1].ToString();
			news.newsGenre = reader[2].ToString();
			news.newsName = reader[3].ToString();
			news.newsDescription = reader[4].ToString();
			news.newsDateTime = DateTime.Parse(reader[5].ToString());
			news.newsMainPictureLink = reader[6].ToString();
			news.newsVideoLink = reader[7].ToString();
			news.newsPrefered = bool.Parse(reader[8].ToString());

			Debug.WriteLine("News:" + news.ToString());
			return news;
		}

		//public IEnumerator GetEnumerator()
		//{
		//	return new NewsEnumerator(this);
		//}
	}


	class NewsEnumerator : IEnumerator
	{
		private News news;
		private int index = 0;

		public NewsEnumerator(News news)
		{
			this.news = news;
		}

		public object Current // החזרת הפריט הנוכחי מהאוסף
		{
			get
			{
				switch (index)
				{
					case 1: return news.newsID;
					case 2: return news.newsCategory;
					case 3: return news.newsGenre;
					case 4: return news.newsName;
					case 5: return news.newsDescription;
					case 6: return news.newsDateTime;
					case 7: return news.newsMainPictureLink;
					case 8: return news.newsVideoLink;
					case 9: return news.newsPrefered;
					default: return news.newsID;
				}
			}
		}

		public bool MoveNext() // הזזה לפריט הבא באוסף
		{
			index++;
			return index <= 9;
		}

		public void Reset() // איפוס הריצה על האוסף
		{
			index = 0;
		}
	}






}

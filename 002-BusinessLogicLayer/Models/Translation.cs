using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace IntTVapi
{
	[DataContract]
	public class Translation /*: IEnumerable*/
	{
		private string _translationKey;
		private string _translationEnglish;
		private string _translationHebrew;

		[DataMember]
		[Required]
		public string translationKey {
			get { return _translationKey; }
			set { _translationKey = value; }
		}

		[DataMember]
		[Required]
		public string translationEnglish {
			get { return _translationEnglish; }
			set { _translationEnglish = value; }
		}

		[DataMember]
		[Required]
		public string translationHebrew {
			get { return _translationHebrew; }
			set { _translationHebrew = value; }
		}

		public override string ToString()
		{
			return
				translationKey + " " +
				translationEnglish + " " +
				translationHebrew;
		}

		public static Translation ToObject(DataRow reader)
		{
			Translation translation = new Translation();
			translation.translationKey = reader[0].ToString();
			translation.translationEnglish = reader[1].ToString();
			translation.translationHebrew = reader[2].ToString();

			Debug.WriteLine("Translation:" + translation.ToString());
			return translation;
		}

		//public IEnumerator GetEnumerator()
		//{
		//	return new TranslationEnumerator(this);
		//}
	}


	class TranslationEnumerator : IEnumerator
	{
		private Translation translation;
		private int index = 0;

		public TranslationEnumerator(Translation translation)
		{
			this.translation = translation;
		}

		public object Current // החזרת הפריט הנוכחי מהאוסף
		{
			get
			{
				switch (index)
				{
					case 1: return translation.translationKey;
					case 2: return translation.translationEnglish;
					case 3: return translation.translationHebrew;
					default: return translation.translationKey;
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

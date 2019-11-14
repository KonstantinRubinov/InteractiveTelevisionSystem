using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace IntTVapi
{
	[DataContract]
	public class Program/* : IEnumerable*/
	{
		private int _programId;
		private string _programCategory;
		private string _programGenre;
		private string _programName;
		private string _programDescription;
		private DateTime _programDateTime;
		private string _programMainPictureLink;
		private string _programVideoLink;

		[DataMember]
		public int programId {
			get { return _programId; }
			set { _programId = value; }
		}

		[DataMember]
		[Required]
		public string programCategory {
			get { return _programCategory; }
			set { _programCategory = value; }
		}

		[DataMember]
		[Required]
		public string programGenre {
			get { return _programGenre; }
			set { _programGenre = value; }
		}

		[DataMember]
		[Required]
		public string programName {
			get { return _programName; }
			set { _programName = value; }
		}

		[DataMember]
		[Required]
		public string programDescription {
			get { return _programDescription; }
			set { _programDescription = value; }
		}

		[DataMember]
		[Required]
		public DateTime programDateTime {
			get { return _programDateTime; }
			set { _programDateTime = value; }
		}

		[DataMember]
		[Required]
		public string programMainPictureLink {
			get { return _programMainPictureLink; }
			set { _programMainPictureLink = value; }
		}

		[DataMember]
		[Required]
		public string programVideoLink {
			get { return _programVideoLink; }
			set { _programVideoLink = value; }
		}

		public override string ToString()
		{
			return
				programId + " " +
				programCategory + " " +
				programGenre + " " +
				programName + " " +
				programDescription + " " +
				programDateTime + " " +
				programMainPictureLink + " " +
				programVideoLink;
		}


		public static Program ToObject(DataRow reader)
		{
			Program program = new Program();
			program.programId = int.Parse(reader[0].ToString());
			program.programCategory = reader[1].ToString();
			program.programGenre = reader[2].ToString();
			program.programName = reader[3].ToString();
			program.programDescription = reader[4].ToString();
			program.programDateTime = DateTime.Parse(reader[5].ToString());
			program.programMainPictureLink = reader[6].ToString();
			program.programVideoLink = reader[7].ToString();

			Debug.WriteLine("Program:" + program.ToString());
			return program;
		}

		//public IEnumerator GetEnumerator()
		//{
		//	return new ProgramEnumerator(this);
		//}
	}




	class ProgramEnumerator : IEnumerator
	{
		private Program program;
		private int index = 0;

		public ProgramEnumerator(Program program)
		{
			this.program = program;
		}

		public object Current // החזרת הפריט הנוכחי מהאוסף
		{
			get
			{
				switch (index)
				{
					case 1: return program.programId;
					case 2: return program.programCategory;
					case 3: return program.programGenre;
					case 4: return program.programName;
					case 5: return program.programDescription;
					case 6: return program.programDateTime;
					case 7: return program.programMainPictureLink;
					case 8: return program.programVideoLink;
					default: return program.programId;
				}
			}
		}

		public bool MoveNext() // הזזה לפריט הבא באוסף
		{
			index++;
			return index <= 8;
		}

		public void Reset() // איפוס הריצה על האוסף
		{
			index = 0;
		}
	}
}

using IntTVapi.EntityDataBase;
using System.Collections.Generic;
using System.Linq;

namespace IntTVapi
{
	public class EntityTranslationManager : EntityBaseManager, ITranslationRepository
	{
		public List<Translation> GetAllTranslations()
		{
			var resultQuary = DB.TRANSLATIONs.Select(t => new Translation
			{
				translationKey = t.translationKey,
				translationEnglish = t.translationEnglish,
				translationHebrew = t.translationHebrew
			});

			var resultSP = DB.GetAllTranslation().Select(t => new Translation
			{
				translationKey = t.translationKey,
				translationEnglish = t.translationEnglish,
				translationHebrew = t.translationHebrew
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public Translation GetTranslationByKey(string translationKey)
		{
			var resultQuary = DB.TRANSLATIONs.Where(t => t.translationKey.Equals(translationKey)).Select(t => new Translation
			{
				translationKey = t.translationKey,
				translationEnglish = t.translationEnglish,
				translationHebrew = t.translationHebrew
			});

			var resultSP = DB.GetTranslationByKey(translationKey).Select(t => new Translation
			{
				translationKey = t.translationKey,
				translationEnglish = t.translationEnglish,
				translationHebrew = t.translationHebrew
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public Translation AddTranslation(Translation value)
		{
			var resultSP = DB.PostTranslation(value.translationKey, value.translationEnglish, value.translationHebrew).Select(t => new Translation
			{
				translationKey = t.translationKey,
				translationEnglish = t.translationEnglish,
				translationHebrew = t.translationHebrew
			});

			if (GlobalVariable.queryType == 0)
			{
				TRANSLATION translation = new TRANSLATION
				{
					translationKey = value.translationKey,
					translationEnglish = value.translationEnglish,
					translationHebrew = value.translationHebrew
				};

				DB.TRANSLATIONs.Add(translation);
				DB.SaveChanges();
				return GetTranslationByKey(translation.translationKey);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public Translation UpdateTranslation(Translation value)
		{
			var resultSP = DB.UpdateTranslation(value.translationKey, value.translationEnglish, value.translationHebrew).Select(t => new Translation
			{
				translationKey = t.translationKey,
				translationEnglish = t.translationEnglish,
				translationHebrew = t.translationHebrew
			});

			if (GlobalVariable.queryType == 0)
			{
				TRANSLATION translation = DB.TRANSLATIONs.Where(tr => tr.translationKey.Equals(value.translationKey)).SingleOrDefault();
				if (translation == null)
					return null;
				translation.translationKey = value.translationKey;
				translation.translationEnglish = value.translationEnglish;
				translation.translationHebrew = value.translationHebrew;
				DB.SaveChanges();
				return GetTranslationByKey(translation.translationKey);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public int DeleteTranslation(string translationKey)
		{
			var resultSP = DB.DeleteTranslation(translationKey);

			if (GlobalVariable.queryType == 0)
			{
				TRANSLATION translation = DB.TRANSLATIONs.Where(tr => tr.translationKey.Equals(translationKey)).SingleOrDefault();
				DB.TRANSLATIONs.Attach(translation);
				if (translation == null)
					return 0;
				DB.TRANSLATIONs.Remove(translation);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}
	}
}
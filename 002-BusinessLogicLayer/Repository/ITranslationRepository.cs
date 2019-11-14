using System.Collections.Generic;

namespace IntTVapi
{
	public interface ITranslationRepository
	{
		List<Translation> GetAllTranslations();
		Translation GetTranslationByKey(string key);
		Translation AddTranslation(Translation value);
		Translation UpdateTranslation(Translation value);
		int DeleteTranslation(string translationKey);
	}
}

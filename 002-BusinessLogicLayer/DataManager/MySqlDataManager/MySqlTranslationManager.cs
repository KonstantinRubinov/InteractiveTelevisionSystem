using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace IntTVapi
{
	public class MySqlTranslationManager : MySqlDataBase, ITranslationRepository
	{
		public List<Translation> GetAllTranslations()
		{
			DataTable dt = new DataTable();
			List<Translation> arrTranslation = new List<Translation>();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(TranslationStringsMySql.GetAllTranslation());
			}

			foreach (DataRow ms in dt.Rows)
			{
				arrTranslation.Add(Translation.ToObject(ms));
			}

			return arrTranslation;
		}

		public Translation GetTranslationByKey(string key)
		{
			DataTable dt = new DataTable();
			if (key == null || key.Equals(""))
				throw new ArgumentOutOfRangeException();
			Translation translation = new Translation();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(TranslationStringsMySql.GetTranslationByKey(key));
			}

			foreach (DataRow ms in dt.Rows)
			{
				translation = Translation.ToObject(ms);
			}

			return translation;
		}

		public Translation AddTranslation(Translation value)
		{
			DataTable dt = new DataTable();
			Translation translation = new Translation();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(TranslationStringsMySql.PostTranslation(value));
			}
			foreach (DataRow ms in dt.Rows)
			{
				translation = Translation.ToObject(ms);
			}

			return translation;
		}


		public Translation UpdateTranslation(Translation value)
		{
			DataTable dt = new DataTable();
			Translation translation = new Translation();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(TranslationStringsMySql.UpdateTranslation(value));
			}
			foreach (DataRow ms in dt.Rows)
			{
				translation = Translation.ToObject(ms);
			}

			return translation;
		}

		public int DeleteTranslation(string translationKey)
		{
			int i = 0;
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(TranslationStringsMySql.DeleteTranslation(translationKey));
			}
			
			return i;
		}
	}
}

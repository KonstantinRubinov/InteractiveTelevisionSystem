using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IntTVapi
{
	public class SqlTranslationManager: SqlDataBase, ITranslationRepository
	{
		public List<Translation> GetAllTranslations()
		{
			DataTable dt = new DataTable();
			List<Translation> arrTranslation = new List<Translation>();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(TranslationStringsSql.GetAllTranslation());
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
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(TranslationStringsSql.GetTranslationByKey(key));
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
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(TranslationStringsSql.PostTranslation(value));
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
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(TranslationStringsSql.UpdateTranslation(value));
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
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(TranslationStringsSql.DeleteTranslation(translationKey));
			}
			
			return i;
		}
	}
}

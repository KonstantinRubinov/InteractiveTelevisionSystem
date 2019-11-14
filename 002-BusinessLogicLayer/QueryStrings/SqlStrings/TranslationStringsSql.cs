using System.Data.SqlClient;

namespace IntTVapi
{
	static public class TranslationStringsSql
	{
		static private string queryTranslationString = "SELECT * from Translation";
		static private string queryTranslationByKeyString = "SELECT * from Translation where translationKey=@translationKey";
		static private string queryProgramPost = "INSERT INTO Translation (translationKey, translationEnglish, translationHebrew) VALUES (@translationKey, @translationEnglish, @translationHebrew); SELECT * FROM Translation WHERE translationKey = @translationKey;";
		static private string queryProgramUpdate = "UPDATE Translation SET translationEnglish = @translationEnglish, translationHebrew = @translationHebrew WHERE translationKey = @translationKey; SELECT * FROM Translation WHERE translationKey = @translationKey;";
		static private string queryTranslationDelete = "DELETE FROM Translation WHERE translationKey=@translationKey";

		static private string procedureTranslationString = "EXEC GetAllTranslation";
		static private string procedureTranslationByKeyString = "EXEC GetTranslationByKey @translationKey";
		static private string procedureProgramPost = "EXEC PostTranslation @translationKey, @translationEnglish, @translationHebrew;";
		static private string procedureProgramUpdate = "EXEC UpdateTranslation @translationKey, @translationEnglish, @translationHebrew;";
		static private string procedureTranslationDelete = "EXEC DeleteTranslation @translationKey";


		static public SqlCommand GetAllTranslation()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryTranslationString);
			else
				return CreateSqlCommand(procedureTranslationString);
		}

		static public SqlCommand GetTranslationByKey(string key)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(key, queryTranslationByKeyString);
			else
				return CreateSqlCommand(key, procedureTranslationByKeyString);
		}

		static public SqlCommand PostTranslation(Translation translation)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(translation, queryProgramPost);
			else
				return CreateSqlCommand(translation, procedureProgramPost);
		}

		static public SqlCommand UpdateTranslation(Translation translation)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(translation, queryProgramUpdate);
			else
				return CreateSqlCommand(translation, procedureProgramUpdate);
		}

		static public SqlCommand DeleteTranslation(string key)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(key, queryTranslationDelete);
			else
				return CreateSqlCommand(key, procedureTranslationDelete);
		}



		static private SqlCommand CreateSqlCommand(Translation translation, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@translationKey", translation.translationKey);
			command.Parameters.AddWithValue("@translationEnglish", translation.translationEnglish);
			command.Parameters.AddWithValue("@translationHebrew", translation.translationHebrew);

			return command;
		}

		static private SqlCommand CreateSqlCommand(string translationKey, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@translationKey", translationKey);

			return command;
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}
	}
}

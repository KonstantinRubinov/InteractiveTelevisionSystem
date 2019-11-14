using MySql.Data.MySqlClient;

namespace IntTVapi
{
	static public class TranslationStringsMySql
	{
		static private string queryTranslationString = "SELECT * from Translation";
		static private string queryTranslationByKeyString = "SELECT * from Translation where translationKey=@translationKey";
		static private string queryProgramPost = "INSERT INTO Translation (translationKey, translationEnglish, translationHebrew) VALUES (@translationKey, @translationEnglish, @translationHebrew); SELECT * FROM Translation WHERE translationKey = @translationKey;";
		static private string queryProgramUpdate = "UPDATE Translation SET translationEnglish = @translationEnglish, translationHebrew = @translationHebrew WHERE translationKey = @translationKey; SELECT * FROM Translation WHERE translationKey = @translationKey;";
		static private string queryTranslationDelete = "DELETE FROM Translation WHERE translationKey=@translationKey";

		static private string procedureTranslationString = "CALL `tvcoil`.`GetAllTranslation`();";
		static private string procedureTranslationByKeyString = "CALL `tvcoil`.`GetTranslationByKey`(@translationKey);";
		static private string procedureProgramPost = "CALL `tvcoil`.`PostTranslation`(@translationKey, @translationEnglish, @translationHebrew);";
		static private string procedureProgramUpdate = "CALL `tvcoil`.`UpdateTranslation`(@translationKey, @translationEnglish, @translationHebrew);";
		static private string procedureTranslationDelete = "CALL `tvcoil`.`DeleteTranslation`(@translationKey);";


		static public MySqlCommand GetAllTranslation()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryTranslationString);
			else
				return CreateSqlCommand(procedureTranslationString);
		}

		static public MySqlCommand GetTranslationByKey(string key)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(key, queryTranslationByKeyString);
			else
				return CreateSqlCommand(key, procedureTranslationByKeyString);
		}

		static public MySqlCommand PostTranslation(Translation translation)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(translation, queryProgramPost);
			else
				return CreateSqlCommand(translation, procedureProgramPost);
		}

		static public MySqlCommand UpdateTranslation(Translation translation)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(translation, queryProgramUpdate);
			else
				return CreateSqlCommand(translation, procedureProgramUpdate);
		}

		static public MySqlCommand DeleteTranslation(string key)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(key, queryTranslationDelete);
			else
				return CreateSqlCommand(key, procedureTranslationDelete);
		}



		static private MySqlCommand CreateSqlCommand(Translation translation, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@translationKey", translation.translationKey);
			command.Parameters.AddWithValue("@translationEnglish", translation.translationEnglish);
			command.Parameters.AddWithValue("@translationHebrew", translation.translationHebrew);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(string translationKey, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@translationKey", translationKey);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			return command;
		}
	}
}

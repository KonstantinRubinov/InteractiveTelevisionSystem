using MySql.Data.MySqlClient;

namespace IntTVapi
{
	static public class ProgramStringsMySql
	{
		static private string queryProgramsString = "SELECT * from Program;";
		static private string queryProgramByIdString = "SELECT * from Program where programId=@programId;";
		static private string queryProgramPost = "INSERT INTO Program (programCategory, programGenre, programName, programDescription, programDateTime, programMainPictureLink, programVideoLink) VALUES (@programCategory, @programGenre, @programName, @programDescription, @programDateTime, @programMainPictureLink, @programVideoLink); SELECT * FROM Program WHERE programId = SCOPE_IDENTITY();";
		static private string queryProgramUpdate = "UPDATE Program SET programCategory = @programCategory, programGenre = @programGenre, programName = @programName, programDescription = @programDescription, programDateTime = @programDateTime, programMainPictureLink = @programMainPictureLink, programVideoLink = @programVideoLink WHERE programId = @programId; SELECT * FROM Program WHERE programId = @programId;";
		static private string queryProgramDelete = "DELETE FROM Program WHERE programId=@programId;";
		static private string queryProgramsTopSix = "SELECT TOP (6) FROM Program;";

		static private string procedureProgramsString = "CALL `tvcoil`.`GetAllPrograms`();";
		static private string procedureProgramByIdString = "CALL `tvcoil`.`GetProgramById`(@programId);";
		static private string procedureProgramPost = "CALL `tvcoil`.`PostProgram`(@programCategory, @programGenre, @programName, @programDescription, @programDateTime, @programMainPictureLink, @programVideoLink);";
		static private string procedureProgramUpdate = "CALL `tvcoil`.`UpdateProgram`(@programId, @programCategory, @programGenre, @programName, @programDescription, @programDateTime, @programMainPictureLink, @programVideoLink);";
		static private string procedureProgramDelete = "CALL `tvcoil`.`DeleteProgram`(@programId);";
		static private string procedureProgramsTopSix = "CALL `tvcoil`.`TopSixPrograms`();";

		static public MySqlCommand GetAllPrograms()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryProgramsString);
			else
				return CreateSqlCommand(procedureProgramsString);
		}

		static public MySqlCommand GetProgramById(int programId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(programId, queryProgramByIdString);
			else
				return CreateSqlCommand(programId, procedureProgramByIdString);
		}

		static public MySqlCommand PostProgram(Program program)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(program, queryProgramPost);
			else
				return CreateSqlCommand(program, procedureProgramPost);
		}

		static public MySqlCommand UpdateProgram(Program program)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(program, queryProgramUpdate);
			else
				return CreateSqlCommand(program, procedureProgramUpdate);
		}

		static public MySqlCommand DeleteProgram(int programId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(programId, queryProgramDelete);
			else
				return CreateSqlCommand(programId, procedureProgramDelete);
		}

		static public MySqlCommand TopSixPrograms()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryProgramsTopSix);
			else
				return CreateSqlCommand(procedureProgramsTopSix);
		}






		static private MySqlCommand CreateSqlCommand(Program program, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@programId", program.programId);
			command.Parameters.AddWithValue("@programCategory", program.programCategory);
			command.Parameters.AddWithValue("@programGenre", program.programGenre);
			command.Parameters.AddWithValue("@programName", program.programName);
			command.Parameters.AddWithValue("@programDescription", program.programDescription);
			command.Parameters.AddWithValue("@programDateTime", program.programDateTime);
			command.Parameters.AddWithValue("@programMainPictureLink", program.programMainPictureLink);
			command.Parameters.AddWithValue("@programVideoLink", program.programVideoLink);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(int programId, string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			command.Parameters.AddWithValue("@programId", programId);

			return command;
		}

		static private MySqlCommand CreateSqlCommand(string commandText)
		{
			MySqlCommand command = new MySqlCommand(commandText);

			return command;
		}
	}
}

using System.Data.SqlClient;

namespace IntTVapi
{
	static public class ProgramStringsSql
	{
		static private string queryProgramsString = "SELECT * from Program;";
		static private string queryProgramByIdString = "SELECT * from Program where programId=@programId;";
		static private string queryProgramPost = "INSERT INTO Program (programCategory, programGenre, programName, programDescription, programDateTime, programMainPictureLink, programVideoLink) VALUES (@programCategory, @programGenre, @programName, @programDescription, @programDateTime, @programMainPictureLink, @programVideoLink); SELECT * FROM Program WHERE programId = SCOPE_IDENTITY();";
		static private string queryProgramUpdate = "UPDATE Program SET programCategory = @programCategory, programGenre = @programGenre, programName = @programName, programDescription = @programDescription, programDateTime = @programDateTime, programMainPictureLink = @programMainPictureLink, programVideoLink = @programVideoLink WHERE programId = @programId; SELECT * FROM Program WHERE programId = @programId;";
		static private string queryProgramDelete = "DELETE FROM Program WHERE programId=@programId;";
		static private string queryProgramsTopSix = "SELECT TOP (6) * FROM Program;";

		static private string procedureProgramsString = "EXEC GetAllPrograms;";
		static private string procedureProgramByIdString = "EXEC GetProgramById @programId;";
		static private string procedureProgramPost = "EXEC PostProgram @programCategory, @programGenre, @programName, @programDescription, @programDateTime, @programMainPictureLink, @programVideoLink;";
		static private string procedureProgramUpdate = "EXEC UpdateProgram @programId, @programCategory, @programGenre, @programName, @programDescription, @programDateTime, @programMainPictureLink, @programVideoLink;";
		static private string procedureProgramDelete = "EXEC DeleteProgram @programId;";
		static private string procedureProgramsTopSix = "EXEC TopSixPrograms;";

		static public SqlCommand GetAllPrograms()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryProgramsString);
			else
				return CreateSqlCommand(procedureProgramsString);
		}

		static public SqlCommand GetProgramById(int programId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(programId, queryProgramByIdString);
			else
				return CreateSqlCommand(programId, procedureProgramByIdString);
		}

		static public SqlCommand PostProgram(Program program)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(program, queryProgramPost);
			else
				return CreateSqlCommand(program, procedureProgramPost);
		}

		static public SqlCommand UpdateProgram(Program program)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(program, queryProgramUpdate);
			else
				return CreateSqlCommand(program, procedureProgramUpdate);
		}

		static public SqlCommand DeleteProgram(int programId)
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(programId, queryProgramDelete);
			else
				return CreateSqlCommand(programId, procedureProgramDelete);
		}

		static public SqlCommand TopSixPrograms()
		{
			if (GlobalVariable.queryType == 0)
				return CreateSqlCommand(queryProgramsTopSix);
			else
				return CreateSqlCommand(procedureProgramsTopSix);
		}






		static private SqlCommand CreateSqlCommand(Program program, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

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

		static private SqlCommand CreateSqlCommand(int programId, string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			command.Parameters.AddWithValue("@programId", programId);

			return command;
		}

		static private SqlCommand CreateSqlCommand(string commandText)
		{
			SqlCommand command = new SqlCommand(commandText);

			return command;
		}
	}
}

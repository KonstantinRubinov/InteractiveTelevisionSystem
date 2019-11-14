using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IntTVapi
{
	public class SqlProgramManager: SqlDataBase, IProgramRepository
	{
		public List<Program> GetAllPrograms()
		{
			DataTable dt = new DataTable();
			List<Program> arrPrograms = new List<Program>();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(ProgramStringsSql.GetAllPrograms());
			}

			foreach (DataRow ms in dt.Rows)
			{
				arrPrograms.Add(Program.ToObject(ms));
			}

			return arrPrograms;
		}


		public Program GetProgramById(int id)
		{
			DataTable dt = new DataTable();
			if (id < 0)
				throw new ArgumentOutOfRangeException();
			Program program = new Program();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(ProgramStringsSql.GetProgramById(id));
			}

			foreach (DataRow ms in dt.Rows)
			{
				program = Program.ToObject(ms);
			}

			return program;
		}

		public Program AddProgram(Program value)
		{
			DataTable dt = new DataTable();
			Program program = new Program();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(ProgramStringsSql.PostProgram(value));
			}

			foreach (DataRow ms in dt.Rows)
			{
				program = Program.ToObject(ms);
			}
			return program;
		}


		public Program UpdateProgram(Program value)
		{
			DataTable dt = new DataTable();
			Program program = new Program();
			using (SqlCommand command = new SqlCommand())
			{
				dt = GetMultipleQuery(ProgramStringsSql.UpdateProgram(value));
			}

			foreach (DataRow ms in dt.Rows)
			{
				program = Program.ToObject(ms);
			}
			return GetProgramById(value.programId);
		}

		public int DeleteProgram(int id)
		{
			int i = 0;
			using (SqlCommand command = new SqlCommand())
			{
				i = ExecuteNonQuery(ProgramStringsSql.DeleteProgram(id));
			}
			
			return i;
		}
	}
}

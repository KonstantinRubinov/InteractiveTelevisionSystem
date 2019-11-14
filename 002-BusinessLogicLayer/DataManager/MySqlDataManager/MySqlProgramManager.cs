using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace IntTVapi
{
	public class MySqlProgramManager : MySqlDataBase, IProgramRepository
	{
		public List<Program> GetAllPrograms()
		{
			DataTable dt = new DataTable();
			List<Program> arrPrograms = new List<Program>();
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(ProgramStringsMySql.GetAllPrograms());
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(ProgramStringsMySql.GetProgramById(id));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(ProgramStringsMySql.PostProgram(value));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				dt = GetMultipleQuery(ProgramStringsMySql.UpdateProgram(value));
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
			using (MySqlCommand command = new MySqlCommand())
			{
				i = ExecuteNonQuery(ProgramStringsMySql.DeleteProgram(id));
			}
			
			return i;
		}
	}
}

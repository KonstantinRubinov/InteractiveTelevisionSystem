using System.Collections.Generic;

namespace IntTVapi
{
	public interface IProgramRepository
	{
		List<Program> GetAllPrograms();
		Program GetProgramById(int id);
		Program AddProgram(Program value);
		Program UpdateProgram(Program value);
		int DeleteProgram(int id);
	}
}

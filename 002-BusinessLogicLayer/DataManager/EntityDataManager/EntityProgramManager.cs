using IntTVapi.EntityDataBase;
using System.Collections.Generic;
using System.Linq;

namespace IntTVapi
{
	public class EntityProgramManager : EntityBaseManager, IProgramRepository
	{
		public List<Program> GetAllPrograms()
		{
			var resultQuary = DB.PROGRAMs.Select(p => new Program
			{
				programId = p.programID,
				programCategory = p.programCategory,
				programGenre = p.programGenre,
				programName = p.programName,
				programDescription = p.programDescription,
				programDateTime = p.programDateTime,
				programMainPictureLink = p.programMainPictureLink,
				programVideoLink = p.programVideoLink
			});

			var resultSP = DB.GetAllPrograms().Select(p => new Program
			{
				programId = p.programID,
				programCategory = p.programCategory,
				programGenre = p.programGenre,
				programName = p.programName,
				programDescription = p.programDescription,
				programDateTime = p.programDateTime,
				programMainPictureLink = p.programMainPictureLink,
				programVideoLink = p.programVideoLink
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.ToList();
			else
				return resultSP.ToList();
		}


		public Program GetProgramById(int programId)
		{
			var resultQuary = DB.PROGRAMs.Where(p => p.programID == programId).Select(p => new Program
			{
				programId = p.programID,
				programCategory = p.programCategory,
				programGenre = p.programGenre,
				programName = p.programName,
				programDescription = p.programDescription,
				programDateTime = p.programDateTime,
				programMainPictureLink = p.programMainPictureLink,
				programVideoLink = p.programVideoLink
			});

			var resultSP = DB.GetProgramById(programId).Select(p => new Program
			{
				programId = p.programID,
				programCategory = p.programCategory,
				programGenre = p.programGenre,
				programName = p.programName,
				programDescription = p.programDescription,
				programDateTime = p.programDateTime,
				programMainPictureLink = p.programMainPictureLink,
				programVideoLink = p.programVideoLink
			});

			if (GlobalVariable.queryType == 0)
				return resultQuary.SingleOrDefault();
			else
				return resultSP.SingleOrDefault();
		}


		public Program AddProgram(Program value)
		{
			var resultSP = DB.PostProgram(value.programCategory, value.programGenre, value.programName, value.programDescription, value.programDateTime, value.programMainPictureLink, value.programVideoLink).Select(p => new Program
			{
				programId = p.programID,
				programCategory = p.programCategory,
				programGenre = p.programGenre,
				programName = p.programName,
				programDescription = p.programDescription,
				programDateTime = p.programDateTime,
				programMainPictureLink = p.programMainPictureLink,
				programVideoLink = p.programVideoLink
			});

			if (GlobalVariable.queryType == 0)
			{
				PROGRAM program = new PROGRAM
				{
					programCategory = value.programCategory,
					programGenre = value.programGenre,
					programName = value.programName,
					programDescription = value.programDescription,
					programDateTime = value.programDateTime,
					programMainPictureLink = value.programMainPictureLink,
					programVideoLink = value.programVideoLink
				};
				DB.PROGRAMs.Add(program);
				DB.SaveChanges();
				return GetProgramById(program.programID);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public Program UpdateProgram(Program value)
		{
			var resultSP = DB.UpdateProgram(value.programId, value.programCategory, value.programGenre, value.programName, value.programDescription, value.programDateTime, value.programMainPictureLink, value.programVideoLink).Select(p => new Program
			{
				programId = p.programID,
				programCategory = p.programCategory,
				programGenre = p.programGenre,
				programName = p.programName,
				programDescription = p.programDescription,
				programDateTime = p.programDateTime,
				programMainPictureLink = p.programMainPictureLink,
				programVideoLink = p.programVideoLink
			});

			if (GlobalVariable.queryType == 0)
			{
				PROGRAM program = DB.PROGRAMs.Where(pr => pr.programID == value.programId).SingleOrDefault();
				if (program == null)
					return null;
				program.programID = value.programId;
				program.programCategory = value.programCategory;
				program.programGenre = value.programGenre;
				program.programName = value.programName;
				program.programDescription = value.programDescription;
				program.programDateTime = value.programDateTime;
				program.programMainPictureLink = value.programMainPictureLink;
				program.programVideoLink = value.programVideoLink;
				DB.SaveChanges();
				return GetProgramById(program.programID);
			}
			else
				return resultSP.SingleOrDefault();
		}


		public int DeleteProgram(int id)
		{
			var resultSP = DB.DeleteProgram(id);

			if (GlobalVariable.queryType == 0)
			{
				PROGRAM program = DB.PROGRAMs.Where(p => p.programID == id).SingleOrDefault();
				DB.PROGRAMs.Attach(program);
				if (program == null)
					return 0;
				DB.PROGRAMs.Remove(program);
				DB.SaveChanges();
				return 1;
			}
			else
				return resultSP;
		}
	}
}

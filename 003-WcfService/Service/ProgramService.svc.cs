using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace IntTVapi
{
	public class ProgramService : IProgramService
	{
		private IProgramRepository programRepository;
		public ProgramService()
		{
			if (GlobalVariable.logicType == 0)
				programRepository = new EntityProgramManager();
			else if (GlobalVariable.logicType == 1)
				programRepository = new SqlProgramManager();
			else
				programRepository = new MySqlProgramManager();
		}

		public HttpResponseMessage GetAllPrograms()
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(programRepository.GetAllPrograms()))
				};
				return hrm;
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(errors.ToString())
				};
				return hr;
			}
		}

		public HttpResponseMessage GetProgramById(int programID)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(programRepository.GetProgramById(programID)))
				};
				return hrm;
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(errors.ToString())
				};
				return hr;
			}
		}

		public HttpResponseMessage AddProgram(Program program)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.Created)
				{
					Content = new StringContent(JsonConvert.SerializeObject(programRepository.AddProgram(program)))
				};
				return hrm;
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(errors.ToString())
				};
				return hr;
			}
		}

		public HttpResponseMessage UpdateProgram(int updateById, Program program)
		{
			try
			{
				program.programId = updateById;
				Program updatedProgram = programRepository.UpdateProgram(program);
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(updatedProgram))
				};
				return hrm;
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(errors.ToString())
				};
				return hr;
			}
		}

		public HttpResponseMessage DeleteProgram(int deleteById)
		{
			try
			{
				int i = programRepository.DeleteProgram(deleteById);

				if (i > 0)
				{
					HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.NoContent)
					{
					};
					return hrm;
				}
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
				};
				return hr;
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				HttpResponseMessage hr = new HttpResponseMessage(HttpStatusCode.InternalServerError)
				{
					Content = new StringContent(errors.ToString())
				};
				return hr;
			}
		}
	}
}

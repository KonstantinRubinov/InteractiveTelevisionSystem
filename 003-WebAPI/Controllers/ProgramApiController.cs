using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IntTVapi
{
	[EnableCors("*", "*", "*")]
	[RoutePrefix("api")]
	public class ProgramApiController : ApiController
    {
		private IProgramRepository programRepository;
		public ProgramApiController()
		{
			if (GlobalVariable.logicType == 0)
				programRepository = new EntityProgramManager();
			else if (GlobalVariable.logicType == 1)
				programRepository = new SqlProgramManager();
			else
				programRepository = new MySqlProgramManager();
		}

		[HttpGet]
		[Route("programs")]
		public HttpResponseMessage GetAllPrograms()
		{
			try
			{
				List<Program> allPrograms = programRepository.GetAllPrograms();
				//if (allPrograms == null || allPrograms.Count < 1)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The programs record couldn't be found.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, allPrograms);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("programs/{id}")]
		public HttpResponseMessage GetProgramById(int id)
		{
			try
			{
				Program oneProgram = programRepository.GetProgramById(id);
				//if (oneProgram == null)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The program record couldn't be found.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, oneProgram);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("programs")]
		public HttpResponseMessage AddProgram(Program program)
		{
			try
			{
				if (program == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				Program addedProgram = programRepository.AddProgram(program);
				//if (addedProgram == null)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The program record couldn't be added.");
				//}
				return Request.CreateResponse(HttpStatusCode.Created, addedProgram);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}


		[HttpPut]
		[Route("programs/{id}")]
		public HttpResponseMessage UpdateProgram(int id, Program program)
		{
			try
			{
				if (program == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				program.programId = id;
				Program updatedProgram = programRepository.UpdateProgram(program);
				//if (updatedProgram == null)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The program record couldn't be updated.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, updatedProgram);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}


		[HttpDelete]
		[Route("programs/{id}")]
		public HttpResponseMessage DeleteProgram(int id)
		{
			try
			{
				int i = programRepository.DeleteProgram(id);
				if (i > 0)
				{
					return Request.CreateResponse(HttpStatusCode.NoContent);
				}
				return Request.CreateResponse(HttpStatusCode.InternalServerError);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}
	}
}

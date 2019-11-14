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
	public class TranslationApiController : ApiController
    {
		private ITranslationRepository translationRepository;
		public TranslationApiController()
		{
			if (GlobalVariable.logicType == 0)
				translationRepository = new EntityTranslationManager();
			else if (GlobalVariable.logicType == 1)
				translationRepository = new SqlTranslationManager();
			else
				translationRepository = new MySqlTranslationManager();
		}

		[HttpGet]
		[Route("translations")]
		public HttpResponseMessage GetAllTranslations()
		{
			try
			{
				List<Translation> allTranslation = translationRepository.GetAllTranslations();
				//if (allTranslation == null || allTranslation.Count < 1)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The translations record couldn't be found.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, allTranslation);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("translations/{key}")]
		public HttpResponseMessage GetTranslationByKey(string key)
		{
			try
			{
				Translation oneTranslation = translationRepository.GetTranslationByKey(key);
				//if (oneTranslation == null)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The translation record couldn't be found.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, oneTranslation);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("translations")]
		public HttpResponseMessage AddTranslation(Translation translation)
		{
			try
			{
				if (translation == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				Translation addedTranslation = translationRepository.AddTranslation(translation);
				//if (addedTranslation == null)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The translation record couldn't be added.");
				//}
				return Request.CreateResponse(HttpStatusCode.Created, addedTranslation);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPut]
		[Route("translations/{key}")]
		public HttpResponseMessage UpdateTranslation(string key, Translation translation)
		{
			try
			{
				if (translation == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				translation.translationKey = key;
				Translation updatedTranslation = translationRepository.UpdateTranslation(translation);
				//if (updatedTranslation == null)
				//{
				//	return Request.CreateResponse(HttpStatusCode.NotFound, "The translation record couldn't be updated.");
				//}
				return Request.CreateResponse(HttpStatusCode.OK, updatedTranslation);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("translations/{key}")]
		public HttpResponseMessage DeleteTranslation(string key)
		{
			try
			{
				int i = translationRepository.DeleteTranslation(key);
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

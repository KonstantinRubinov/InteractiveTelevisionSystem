using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace IntTVapi
{
	public class TranslationService : ITranslationService
	{
		private ITranslationRepository translationRepositor;
		public TranslationService()
		{
			if (GlobalVariable.logicType == 0)
				translationRepositor = new EntityTranslationManager();
			else if (GlobalVariable.logicType == 1)
				translationRepositor = new SqlTranslationManager();
			else
				translationRepositor = new MySqlTranslationManager();
		}

		public HttpResponseMessage GetAllTranslations()
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(translationRepositor.GetAllTranslations()))
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

		public HttpResponseMessage GetTranslationByKey(string translationKey)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(translationRepositor.GetTranslationByKey(translationKey)))
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

		public HttpResponseMessage AddTranslation(Translation translation)
		{
			try
			{
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.Created)
				{
					Content = new StringContent(JsonConvert.SerializeObject(translationRepositor.AddTranslation(translation)))
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

		public HttpResponseMessage UpdateTranslation(string updateByKey, Translation translation)
		{
			try
			{
				translation.translationKey = updateByKey;
				Translation updatedTranslation = translationRepositor.UpdateTranslation(translation);
				HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new StringContent(JsonConvert.SerializeObject(updatedTranslation))
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

		public HttpResponseMessage DeleteTranslation(string deleteByKey)
		{
			try
			{
				int i = translationRepositor.DeleteTranslation(deleteByKey);

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

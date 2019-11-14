using IntTVapi.EntityDataBase;
using System;

namespace IntTVapi
{
	public class EntityBaseManager : IDisposable
	{
		protected tvcoilEntities DB = new tvcoilEntities();

		public void Dispose()
		{
			DB.Dispose();
		}
	}
}

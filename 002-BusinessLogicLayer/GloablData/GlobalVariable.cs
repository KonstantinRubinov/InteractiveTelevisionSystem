﻿namespace IntTVapi
{
	public static class GlobalVariable
	{
		// _queryType = 0 -> query
		// _queryType = 1 -> stored procedure

		private static int _queryType = 1;

		// _logicType = 0 -> entity
		// _logicType = 1 -> sql
		// _logicType = 2 -> mySql
		private static int _logicType = 2;

		public static int queryType
		{
			set
			{
				_queryType = value;
			}

			get
			{
				return _queryType;
			}
		}

		public static int logicType
		{
			set
			{
				_logicType = value;
			}

			get
			{
				return _logicType;
			}
		}
	}
}

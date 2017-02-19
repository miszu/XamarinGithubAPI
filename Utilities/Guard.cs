using System;
namespace AngryNerds.Utilities
{
	public static class Guard
	{
		public static void ThrowIfNull(object argumentValue, string argumentName)
		{
			if (argumentValue == null)
			{
				throw new ArgumentNullException();
			}
		}

		public static void ThrowForNullOrEmptyString(string argumentValue, string argumentName)
		{
			if (argumentValue == null || argumentValue.Trim().Length == 0)
			{
				throw new ArgumentNullException($"String argument {argumentName} is null or empty");
			}
		}
	}
}

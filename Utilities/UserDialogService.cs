using System;
using Acr.UserDialogs;

namespace AngryNerds.Utilities
{
	public interface IUserDialogService
	{
		void ShowError(string message);
		IDisposable ShowLoading(string message);
	}

	public class UserDialogService : IUserDialogService
	{
		public void ShowError(string message)
		{
			UserDialogs.Instance.Alert(message);
		}

		public IDisposable ShowLoading(string message)
		{
			return UserDialogs.Instance.Loading(message);
		}
	}
}

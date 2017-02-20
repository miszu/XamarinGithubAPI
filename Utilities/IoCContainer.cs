using System;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform;
using AngryNerds.GitHub;
using AngryNerds.ViewModel;
namespace AngryNerds.Utilities
{
	public static class IoCContainer
	{
		public static void Register()
		{
			MvxSimpleIoCContainer.Initialize();

			Mvx.ConstructAndRegisterSingleton<IUserDialogService, UserDialogService>();
			Mvx.ConstructAndRegisterSingleton<IGitHubDataProvider, GitHubDataProvider>();
			Mvx.ConstructAndRegisterSingleton<INavigationService, NavigationService>();

			Mvx.RegisterType<IRepositoriesViewModel, RepositoriesViewModel>();
			Mvx.RegisterType<IRepositoryDetailsViewModel, RepositoryDetailsViewModel>();
		}

	}
}

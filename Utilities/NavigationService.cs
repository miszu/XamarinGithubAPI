using System.Threading.Tasks;
using AngryNerds.Model;
using AngryNerds.View;
using MvvmCross.Platform;

namespace AngryNerds.Utilities
{
	public interface INavigationService
	{
		Task ShowRepositoryDetails(Repository repository);
	}

	public class NavigationService : INavigationService
	{
		public async Task ShowRepositoryDetails(Repository repository)
		{
			var detailsPage = Mvx.IocConstruct<RepositoryDetailsView>();
			detailsPage.SetUpRepository(repository);
			await App.Current.MainPage.Navigation.PushAsync(detailsPage);
		}
	}

}

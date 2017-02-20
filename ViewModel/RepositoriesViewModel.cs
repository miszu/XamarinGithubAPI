using System;
using AngryNerds.Model;
using System.Windows.Input;
using System.Collections.Generic;
using AngryNerds.Utilities;
using Xamarin.Forms;
using System.Threading.Tasks;
using AngryNerds.GitHub;

namespace AngryNerds.ViewModel
{
	public interface IRepositoriesViewModel
	{
		IEnumerable<Repository> Repositories { get; }
		bool IsBusy { get; }
		Repository SelectedRepository { get; set;}
		ICommand RefreshRepositoriesCommand { get; }
	}

	public class RepositoriesViewModel : ViewModelBase, IRepositoriesViewModel
	{
		private INavigationService navigationService;
		private IGitHubDataProvider gitHubDataProvider;
		private IUserDialogService userDialogService;

		private string userName = "xamarin";

		public RepositoriesViewModel(IGitHubDataProvider gitHubDataProvider, INavigationService navigationService, IUserDialogService userDialogService)
		{
			this.navigationService = navigationService;
			this.gitHubDataProvider = gitHubDataProvider;
			this.userDialogService = userDialogService;

			this.RefreshRepositoriesCommand = new Command(async () => await this.RefreshRepositories());
		}

		private bool isBusy;
		public bool IsBusy
		{
			get
			{
				return this.isBusy;
			}
			set
			{
				this.isBusy = value;
				base.OnPropertyChanged();
			}
		}

		public ICommand RefreshRepositoriesCommand { get; }

		private IEnumerable<Repository> repositories;
		public IEnumerable<Repository> Repositories
		{
			get
			{
				return this.repositories;
			}
			set
			{
				this.repositories = value;
				base.OnPropertyChanged();
			}
		}

		public Repository SelectedRepository
		{
			get
			{
				return null;
			}

			set
			{
				if (value != null)
				{
					Repository repository = value;
					this.navigationService.ShowRepositoryDetails(repository);
				}
			}
		}

		private async Task RefreshRepositories()
		{
			this.IsBusy = true;

			try
			{
				this.Repositories = await this.gitHubDataProvider.GetUserRepositories(this.userName);
			}
			catch(Exception ex)
			{
				this.userDialogService.ShowError("Błąd podczas pobierania danych");
			}
			finally
			{
				this.IsBusy = false;
			}
		}
	}
}

using Xamarin.Forms;
using AngryNerds.Model;
using AngryNerds.ViewModel;

namespace AngryNerds.View
{
	public partial class RepositoryDetailsView : ContentPage
	{
		private IRepositoryDetailsViewModel repositoryDetailsViewModel;

		public RepositoryDetailsView(IRepositoryDetailsViewModel repositoryDetailsViewModel)
		{
			InitializeComponent();
			this.repositoryDetailsViewModel = repositoryDetailsViewModel;
		}

		public void SetUpRepository(Repository repository)
		{
			this.repositoryDetailsViewModel.SetUpRepository(repository);
			this.BindingContext = this.repositoryDetailsViewModel;
		}
	}
}

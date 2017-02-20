using System;
using System.Collections.Generic;

using Xamarin.Forms;
using AngryNerds.ViewModel;

namespace AngryNerds.View
{
	public partial class RepositoriesView : ContentPage
	{
		private IRepositoriesViewModel viewModel;

		public RepositoriesView(IRepositoriesViewModel viewModel)
		{
			InitializeComponent();
			this.viewModel = viewModel;
			this.BindingContext = this.viewModel;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (this.viewModel.Repositories == null)
			{
				this.viewModel.RefreshRepositoriesCommand.Execute(null);
			}
		}
	}
}

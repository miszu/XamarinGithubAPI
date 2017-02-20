using AngryNerds.Utilities;
using Xamarin.Forms;
using MvvmCross.Platform;
using AngryNerds.View;

namespace AngryNerds
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			IoCContainer.Register();

			MainPage = new NavigationPage(Mvx.IocConstruct<RepositoriesView>())
			{
				BarTextColor = Color.White,
				BarBackgroundColor = Color.Teal
			};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

using System;
using System.Net.Http;
using AngryNerds.GitHub;
using NUnit.Framework;
using AngryNerds.Utilities;

namespace AngryNerds.Tests.GitHub
{
	public class GitHubDataProviderTests
	{
		private IGitHubDataProvider gitHubDataProvider;

		[SetUp]
		public void SetUp()
		{
			this.gitHubDataProvider = new GitHubDataProvider(new UserDialogService());
		}

		[Test]
		[Category("Unit")]
		[TestCase(null)]
		[TestCase("")]
		[TestCase("      ")]
		public void GetUserRepositories_NullOrEmptyUserName_ArgumentNullException(string userName)
		{
			// act, assert
			Assert.ThrowsAsync<ArgumentNullException>(() => this.gitHubDataProvider.GetUserRepositories(userName));
		}

		[Test]
		[Category("Integration")]
		public void GetUserRepositories_NotExistingUserName_ArgumentException()
		{
			// act, assert
			Assert.ThrowsAsync<HttpRequestException>(() => this.gitHubDataProvider.GetUserRepositories("NOTEXISTING1234asd"));
		}

		[Test]
		[Category("Integration")]
		public void GetUserRepositories_ForExistingUserName_RepositoriesReturned()
		{
			// act
			var repositories = this.gitHubDataProvider.GetUserRepositories("xamarin").Result;

			// assert
			Assert.IsNotEmpty(repositories);
		}
	}
}

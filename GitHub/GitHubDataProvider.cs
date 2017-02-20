using System.Collections.Generic;
using System.Threading.Tasks;
using AngryNerds.Model;
using AngryNerds.Utilities;
using Newtonsoft.Json;
using System.Net.Http;

namespace AngryNerds.GitHub
{
	public interface IGitHubDataProvider
	{
		Task<IEnumerable<Repository>> GetUserRepositories(string userName);
	}

	public class GitHubDataProvider : IGitHubDataProvider
	{
		private const string GitHubRepositoriesUrlTemplate = "https://api.github.com/users/{0}/repos"; 
		private HttpClient httpClient;
		private IUserDialogService userDialogService;

		public GitHubDataProvider(IUserDialogService userDialogService)
		{
			this.userDialogService = userDialogService;
			this.httpClient = new HttpClient();

   		    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "json");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
		}

		public async Task<IEnumerable<Repository>> GetUserRepositories(string userName)
		{
			Guard.ThrowForNullOrEmptyString(userName, nameof(userName));

			using (this.userDialogService.ShowLoading("Rozmawiam z serwerem..."))
			{
				var repositoriesHttpResponse = await this.httpClient.GetAsync(string.Format(GitHubRepositoriesUrlTemplate, userName));

				if (repositoriesHttpResponse.IsSuccessStatusCode == false)
				{
					throw new HttpRequestException($"Repositories API endpoint reported {repositoriesHttpResponse.StatusCode} http error");
				}

				var response = await repositoriesHttpResponse.Content.ReadAsStringAsync();

				return JsonConvert.DeserializeObject<IEnumerable<Repository>>(response);
			}
		}
	}
}
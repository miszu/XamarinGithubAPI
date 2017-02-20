using System;
using AngryNerds.Model;
namespace AngryNerds.ViewModel
{
	public interface IRepositoryDetailsViewModel
	{
		string Name { get; }
		string Avatar { get; }
		string Description { get; }
		string CreationDate { get; }
		string OpenIssues { get; }
		void SetUpRepository(Repository repository);
	}

	public class RepositoryDetailsViewModel : IRepositoryDetailsViewModel
	{
		private Repository repository;

		public string Avatar
		{
			get
			{
				return this.repository.Owner.AvatarUrl;
			}
		}

		public string CreationDate
		{
			get
			{
				var daysSinceCreation = (DateTime.Now - this.repository.CreatedAt).Days;
				return $"Powstało {daysSinceCreation} dni temu";
			}
		}

		public string Description
		{
			get
			{
				return repository.Description ?? "Brak opisu";
			}
		}

		public string Name
		{
			get
			{
				return repository.Name;
			}
		}

		public string OpenIssues
		{
			get
			{
				return this.repository.OpenIssues == 0 ? "Brak problemów" : "Otwartych problemów: " + this.repository.OpenIssues;
			}
		}

		public void SetUpRepository(Repository repository)
		{
			this.repository = repository;
		}
	}
}

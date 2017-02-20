using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AngryNerds.Model
{
	public class Repository
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
		[JsonProperty(PropertyName = "owner")]
		public RepositoryOwner Owner { get; set; }
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "created_at")]
		public DateTime CreatedAt { get; set; }
		[JsonProperty(PropertyName = "open_issues")]
		public int OpenIssues { get; set; }
	}
}
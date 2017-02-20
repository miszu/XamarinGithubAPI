using Newtonsoft.Json;

namespace AngryNerds.Model
{
	public class RepositoryOwner
	{
		[JsonProperty(PropertyName = "avatar_url")]
		public string AvatarUrl { get; set; }
	}
}

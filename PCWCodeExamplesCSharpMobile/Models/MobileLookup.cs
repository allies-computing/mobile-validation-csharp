using Newtonsoft.Json;

namespace PCWCodeExamplesCSharpMobile.Models
{
	/// <summary>
	/// For storing the results of a mobile lookup
	/// </summary>
	[JsonObject]
	public class MobileLookup
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? stateid { get; set; }
		
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string state { get; set; }

		[JsonProperty]
		public bool on { get; set; }

		[JsonProperty]
		public bool valid { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string number { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string type { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string networkname { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? networkcode { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? countrycode { get; set; }
		
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string countryname { get; set; }
	}

	/// <summary>
	/// A wrapper class for returning the results of a mobile lookup
	/// </summary>
	[JsonObject]
	public class MobileReturn
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string error_message { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public MobileLookup mobile { get; set; }
	}
}
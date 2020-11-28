using Newtonsoft.Json;
using System.Collections.Generic;
using FrontSharp.Models;

namespace FrontSharp.Requests
{
    public class CreateContactRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

		[JsonProperty("is_spammer")]
		public bool IsSpammer { get; set; }

		[JsonProperty("links")]
		public List<string> Links { get; set; }

		[JsonProperty("group_names")]
		public List<string> GroupNames { get; set; }

		[JsonProperty("handles")]
		public List<Handle> Handles { get; set; }

		[JsonProperty("custom_fields")]
		public CustomFieldsObject CustomFields { get; set; }
	}
	public class CustomFieldsObject {
		//public string jobtitle { get; set; }
		//public string customfieldname { get; set; }
	}
	public class UpdateContactRequest {
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("is_spammer")]
		public bool IsSpammer { get; set; }

		[JsonProperty("links")]
		public List<string> Links { get; set; }

		[JsonProperty("group_names")]
		public List<string> GroupNames { get; set; }

		[JsonProperty("custom_fields")]
		public CustomFieldsObject CustomFields { get; set; }
	}
	public class DeleteContactHandleRequest {

		[JsonProperty("handle")]
		public string Handle { get; set; }

		[JsonProperty("source")]
		public string Source { get; set; }

		[JsonProperty("force")]
		public bool Force { get; set; }
	}
	public class AddContactHandleRequest {

		[JsonProperty("handle")]
		public string Handle { get; set; }

		[JsonProperty("source")]
		public string Source { get; set; }

	}
}
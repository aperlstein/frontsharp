using FrontSharp.Interfaces;
using FrontSharp.Models;
using FrontSharp.Requests;

using RestSharp;

namespace FrontSharp.Logic
{
    public class ContactLogic : BaseLogic, IContactLogic
    {
        public ContactLogic(FrontSharpClient client) : base(client)
        {
            _baseRoute = "contacts";
        }

        /// <summary>
        /// Retrieve contact details for a given contact id
        /// </summary>
        /// <param name="contactId">The id reference for the contact</param>
        /// <returns>Contact metadata</returns>
        public Contact Get(string contactId)
        {
            var request = base.BuildRequest();
            request.Resource += "/{contactId}";
            request.AddParameter("contactId", contactId, ParameterType.UrlSegment);

            return _client.Execute<Contact>(request);
        }
		/// <summary>
		/// Retrieve contact details for a given contact id
		/// </summary>
		/// <param name="contactId">The id reference for the contact</param>
		/// <returns>Contact metadata</returns>
		public Contact GetByEmail(string email) { //, string teamId = null
			var request = base.BuildRequest();
			//if (teamId != null) {
			//	request.Resource += "/teams/{teammate_id}/alt:email:{email}";
			//	request.AddParameter("teammate_id", teamId, ParameterType.UrlSegment);
			//} else {
				request.Resource += "/alt:email:{email}";
			//}
			request.AddParameter("email", email, ParameterType.UrlSegment);
			return _client.Execute<Contact>(request);
		}

		/// <summary>
		/// Create a contact 
		/// </summary>
		/// <param name="contact">Contact Details</param>
		/// <param name="teamId">Team ID</param>
		/// <returns>Contact metadata</returns>
		public Contact Create(CreateContactRequest contact, string teamId = null) {
			var request = base.BuildRequest();
			if (teamId != null) {
				request.Resource = "teams/{teammate_id}/contacts/";
				request.AddParameter("teammate_id", teamId, ParameterType.UrlSegment);
			} else {
				request.Resource += "/";
			}
			request.Method = Method.POST;
			return _client.Execute<Contact>(request, contact);
		}

		/// <summary>
		/// Update a contact 
		/// </summary>
		/// <param name="contact">Contact Details</param>
		/// <param name="teamId">Team ID</param>
		/// <returns>Contact metadata</returns>
		public Contact Update(UpdateContactRequest contact, string contactId) {
			var request = base.BuildRequest();
			request.Resource += "/{contact_id}";
			request.AddParameter("contact_id", contactId, ParameterType.UrlSegment);
			request.Method = Method.PATCH;
			return _client.Execute<Contact>(request, contact);
		}

		public void AddHandle(string contactId, AddContactHandleRequest handle) {
			var request = base.BuildRequest();
			request.Resource += "/{contact_id}/handles";
			request.AddParameter("contact_id", contactId, ParameterType.UrlSegment);
			request.Method = Method.POST;
			_client.Execute(request, handle);
		}

		public void DeleteHandle(string contactId, DeleteContactHandleRequest handle) {
			var request = base.BuildRequest();
			request.Resource += "/{contact_id}/handles";
			request.AddParameter("contact_id", contactId, ParameterType.UrlSegment);
			request.Method = Method.DELETE;
			_client.Execute(request, handle);
		}
	}
}
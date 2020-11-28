using FrontSharp.Models;
using FrontSharp.Requests;

namespace FrontSharp.Interfaces
{
    public interface IContactLogic
    {
        Contact Get(string contactId);
		Contact GetByEmail(string email); //, string teamId = null
		Contact Create(CreateContactRequest contact, string teamId);
		Contact Update(UpdateContactRequest contact, string contactId);
		void AddHandle(string contactId, AddContactHandleRequest handle);
		void DeleteHandle(string contactId, DeleteContactHandleRequest handle);

	}
}
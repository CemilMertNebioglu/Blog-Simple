
using BloggerSample.Core.Services;
using BloggerSample.DTO;
using System.Collections.Generic;

namespace BloggerSample.BLL.Abstract
{
    public interface IContactService : IServiceBase
    {
        List<ContactDTO> getAll();
        ContactDTO getContact(int Id);
        List<ContactDTO> getContactName(string ContactName);
        ContactDTO newContact(ContactDTO contact);
        ContactDTO updateContact(ContactDTO contact);
        bool deleteContact(int contactId);
    }
}

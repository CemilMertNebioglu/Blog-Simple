using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggerSample.BLL.Abstract;
using BloggerSample.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggerSample.WebAPI.Controllers
{

    [Route("api/Contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactsController(IContactService _contactService)
        {
            contactService = _contactService;
        }

        [HttpGet]
        public List<ContactDTO> GetAll()
        {
            return contactService.getAll();
        }
        [HttpGet("{id}")]
        public ContactDTO Get(int ıd)
        {
            return contactService.getContact(ıd);
        }

        [HttpPost]
        public ContactDTO Post(ContactDTO dto)
        {
            return contactService.newContact(dto);
        }
        [HttpPut]
        public ContactDTO Put(ContactDTO dto)
        {
            return contactService.updateContact(dto);
        }
        [HttpDelete]
        public bool Delete(int Id)
        {
            return contactService.deleteContact(Id);
        }
    }
}
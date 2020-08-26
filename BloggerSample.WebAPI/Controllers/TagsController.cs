using System.Collections.Generic;
using BloggerSample.BLL.Abstract;
using BloggerSample.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BloggerSample.WebAPI.Controllers
{
    [Route("api/Tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService tagService;
        public TagsController(ITagService _tagService)
        {
            tagService = _tagService;
        }
        [HttpGet]
        public List<TagDTO> Get()
        {
            return tagService.getAll();
        }
        [HttpGet("{id}")]
        public TagDTO Get(int id)
        {
            return tagService.getTag(id);
        }
        [HttpPost]
        public TagDTO Post(TagDTO dto)
        {
            return tagService.newTag(dto);
        }
        [HttpPut]
        public TagDTO Put(TagDTO dto)
        {
            return tagService.updateTag(dto);
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            return tagService.deleteTag(id);
        }
    }
}
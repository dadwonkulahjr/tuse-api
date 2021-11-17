using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuseAwesomeApiWeb.Dtos;
using TuseAwesomeApiWeb.Extentions;
using TuseAwesomeApiWeb.Models;
using TuseAwesomeApiWeb.Repo.IRepo;

namespace TuseAwesomeApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetAll()
        {
            return _unitOfWork.ITemRepository.GetAllItems()
                                    .Select(x => x.AsDto()).ToList();
        }

        [HttpPost]
        public ActionResult<ItemDto> Create([FromBody] CreateItemDto createItemDto)
        {

            if (!ModelState.IsValid) { return BadRequest(); }


            var item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = createItemDto.Name,
                Price = createItemDto.Price,
                DateCreated = createItemDto.DateCreated
            };

            var result = _unitOfWork.ITemRepository.AddAnItem(item);

            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetItemById), new { id = result.Id }, result.AsDto());

        }
        [HttpGet("{id}")]
        public IActionResult GetItemById(Guid id)
        {
            var result = _unitOfWork.ITemRepository.GetSingleOrDefaultItem(id);

            if (result is null)
            {
                return NotFound();
            }


            return Ok(result.AsDto());

        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto updateItemDto)
        {
            var itemFound = _unitOfWork.ITemRepository.GetSingleOrDefaultItem(id);

            if(itemFound is null)
            {
                return NotFound();
            }

            Item item = itemFound with
            {
                Id = id,
                Name = updateItemDto.Name,
                Price = updateItemDto.Price,
                DateCreated = updateItemDto.DateCreated
            };

            _unitOfWork.ITemRepository.UpdateItem(item);

            return NoContent();
        }
    }
}

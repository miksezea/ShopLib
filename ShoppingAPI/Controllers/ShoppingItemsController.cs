using Microsoft.AspNetCore.Mvc;
using ShopLib.Models;
using ShoppingAPI.Repositories;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    //URI: api/ShoppingItems
    [ApiController]
    public class ShoppingItemsController : ControllerBase
    {
        private ShoppingItemsRepository _repository;
        public ShoppingItemsController(ShoppingItemsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<ShoppingItemsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<ShoppingItem>> Get()
        {
            List<ShoppingItem> list = _repository.GetAll();
            if (list == null || list.Count < 1)
            {
                return NoContent();
            }
            return Ok(list);
        }

        // POST api/<ShoppingItemsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<ShoppingItem> Post([FromBody] ShoppingItem newItem)
        {
            try
            {
                ShoppingItem createdItem = _repository.Add(newItem);
                return Created($"api/shoppingitems/{createdItem.Id}", createdItem);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ShoppingItemsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{Id}")]
        public ActionResult<ShoppingItem> Delete(int id)
        {
            try
            {
                ShoppingItem deletedItem = _repository.Delete(id);
                return Ok(deletedItem);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/<ShoppingItemsController>/Sum
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("Sum")]
        public ActionResult<double> TotalPrice()
        {
            double totalPrice = _repository.TotalPrice();
            if (totalPrice < 0)
            {
                return NoContent();
            }
            return Ok(totalPrice);
        }
    }
}

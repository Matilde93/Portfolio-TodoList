using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private ItemsRepository _repository;

        public ItemsController(ItemsRepository repository)
        {
            _repository = repository;
        }


        // GET: api/<ItemsController>
        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult <IEnumerable<Item>> Get()
        {
            List<Item> items = _repository.GetAll();
            if(items.Count < 1 )
            {
                return NoContent();
            }
            return Ok( items );
        }

        // GET api/<ItemsController>/5
        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult <Item> Get(int id)
        {
            Item? foundItem = _repository.GetById(id);
            if(foundItem == null)
            {
                return NotFound();
            }
            return Ok( foundItem );
        }

        // POST api/<ItemsController>
        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Item> Post([FromBody] Item newItem)
        {
            try
            {
                Item createdItem = _repository.Add(newItem);
                return Created($"api/items/{createdItem.Id}", newItem);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // PUT api/<ItemsController>/5
        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Item> Put(int id, [FromBody] Item itemUpdates)
        {
            try
            {
                Item? updatedItem = _repository.Update(id, itemUpdates);
                if(updatedItem == null)
                {
                    return NotFound();
                }
                return Ok(updatedItem);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<ItemsController>/5
        [EnableCors("AllowAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Item> Delete(int id)
        {
            Item? deletedItem = _repository.Delete(id);
            if(deletedItem == null)
            {
                return NotFound();
            }
            return Ok(deletedItem);
        }
    }
}

namespace CustomModelBinder.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("{product}")]
        public ActionResult<string> Get(Product product)
        {
            if (product == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(product);
        }
    }
}

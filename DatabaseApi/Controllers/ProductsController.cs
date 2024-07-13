using DatabaseApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DatabaseApi.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly AppDbContext _context;

        public ProductsController()
        {
            _context = new AppDbContext();
        }

        // GET: api/products
        [HttpGet]
        [Route("")]
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        // GET: api/products/5
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}

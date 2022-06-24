using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using odatasample.Model;

namespace odatasample.Controllers
{
    // OData attribute routing is enabled by default if call AddOData()
    // this attribute is not required because inherited from ODataController
    // [ODataAttributeRouting]
    // [Route("[controller]")]
    [Produces("application/json")]
    public class BooksController : ODataController
    {
        private readonly CustomerContext _context;

        public BooksController(CustomerContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (context.Books.Any()) return;
            foreach (var b in DataSource.GetBooks())
            {
                context.Books.Add(b);
                context.Presses.Add(b.Press);
            }
            context.SaveChanges();
        }

        // GET: api/Books
        [EnableQuery]
        [ActionName("GetBooks")]
        [HttpGet("v1/Books")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/5
        [ActionName("GetBookById")]
        [HttpGet("v1/Books/{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }
    }
}

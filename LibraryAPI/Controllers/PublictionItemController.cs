using DAL.Db.Interfaces;
using DAL.Entities.EntitiesPublicationItem;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublictionItemController : Controller
    {
        private readonly IService<Book> _bookService;
        private readonly IService<Journal> _journalService;
        private readonly IService<Publication> _publicationService;
        private readonly IService<EBook> _eBookService;

        public PublictionItemController(IService<Book> bookService, IService<Journal> journalService,
            IService<Publication> publicationService, IService<EBook> eBookService)
        {
            _bookService = bookService;
            _journalService = journalService;
            _publicationService = publicationService;
            _eBookService = eBookService;
        }

        [HttpGet]
        public ActionResult<List<PublicationItem>> Get()
        {
            List<Book> books = _bookService.Get();
            List<Publication> publications = _publicationService.Get();
            List<Journal> journals = _journalService.Get();
            List<EBook> eBooks = _eBookService.Get();
            var items = new
            {
                books,
                publications,
                journals,
                eBooks

            };

            return Ok(items);
        }

        [HttpGet("namePublication")]
        public ActionResult<List<PublicationItem>> GetFoundPublicationItem(string name)
        {
            List<Book> books = _bookService.Get().FindAll(b => b.Title == name);
            List<Publication> publications = _publicationService.Get().FindAll(p => p.Title == name);
            List<Journal> journals = _journalService.Get().FindAll(j => j.Title == name);
            List<EBook> eBooks = _eBookService.Get().FindAll(eb => eb.Title == name);
            var items = new
            {
                books,
                publications,
                journals,
                eBooks
            };
            return Ok(items);
        }

        [HttpGet("sort")]
        public ActionResult<List<PublicationItem>> GetSortedPublicationItem(string sortBy)
        {
            sortBy = sortBy.ToLower().Trim();
            List<Book> books = _bookService.Get();
            List<Publication> publications = _publicationService.Get();
            List<Journal> journals = _journalService.Get();
            List<EBook> eBooks = _eBookService.Get();

            switch (sortBy)
            {
                case "title":
                    books = books.OrderBy(b => b.Title).ToList();
                    publications = publications.OrderBy(p => p.Title).ToList();
                    journals = journals.OrderBy(j => j.Title).ToList();
                    eBooks = eBooks.OrderBy(eb => eb.Title).ToList();
                    break;
                case "price":
                    books = books.OrderBy(b => b.Price).ToList();
                    publications = publications.OrderBy(p => p.Price).ToList();
                    journals = journals.OrderBy(j => j.Price).ToList();
                    eBooks = eBooks.OrderBy(eb => eb.Price).ToList();
                    break;
                case "rating":
                    books = books.OrderBy(b => b.Rating).ToList();
                    publications = publications.OrderBy(p => p.Rating).ToList();
                    journals = journals.OrderBy(j => j.Rating).ToList();
                    eBooks = eBooks.OrderBy(eb => eb.Rating).ToList();
                    break;
                default:
                    return BadRequest();
            }

            var items = new
            {
                books,
                publications,
                journals,
                eBooks
            };

            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(Guid id, string type)
        {
            PublicationItem publicationItem;
            type = type.ToLower().Trim();
            switch (type)
            {
                case "book":
                    publicationItem = _bookService.GetById(id);
                    break;
                case "publication":
                    publicationItem = _publicationService.GetById(id);
                    break;
                case "ebook":
                    publicationItem = _eBookService.GetById(id);
                    break;
                case "journal":
                    publicationItem = _journalService.GetById(id);
                    break;
                default:
                    return NotFound();
            }

            if (publicationItem == null)
                return NotFound();

            return Ok(publicationItem);
        }

        [HttpPost("save")]
        public ActionResult Insert(object book)
        {
            bool result = false;
            Type type = GetType(book);

            if (typeof(Book).IsAssignableFrom(type))
                result = _bookService.Insert(JsonConvert.DeserializeObject<Book>(book.ToString()));
            else if (typeof(EBook).IsAssignableFrom(type))
                result = _eBookService.Insert(JsonConvert.DeserializeObject<EBook>(book.ToString()));
            else if (typeof(Journal).IsAssignableFrom(type))
                result = _journalService.Insert(JsonConvert.DeserializeObject<Journal>(book.ToString()));
            else if (typeof(Publication).IsAssignableFrom(type))
                result = _publicationService.Insert(JsonConvert.DeserializeObject<Publication>(book.ToString()));
            else
                result = false;

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPut("update")]
        public ActionResult Update(object book)
        {
            bool result = false;
            Type type = GetType(book);

            if (typeof(Book).IsAssignableFrom(type))
                result = _bookService.Update(JsonConvert.DeserializeObject<Book>(book.ToString()));
            else if (typeof(EBook).IsAssignableFrom(type))
                result = _eBookService.Update(JsonConvert.DeserializeObject<EBook>(book.ToString()));
            else if (typeof(Journal).IsAssignableFrom(type))
                result = _journalService.Update(JsonConvert.DeserializeObject<Journal>(book.ToString()));
            else if (typeof(Publication).IsAssignableFrom(type))
                result = _publicationService.Update(JsonConvert.DeserializeObject<Publication>(book.ToString()));
            else
                result = false;

            if (result)
                return Ok();

            return BadRequest();
        }

        private Type GetType(object book)
        {
            JObject jObject = JObject.Parse(book.ToString());

            if (jObject.ContainsKey("authors") && jObject.ContainsKey("imagePath") && jObject.ContainsKey("genre"))
            {
                if (jObject.ContainsKey("format"))
                    return typeof(EBook);
                else
                    return typeof(Book);
            }
            else if (jObject.ContainsKey("imagePath"))
                return typeof(Journal);
            else //Add specific prop 
                return typeof(Publication);

            return null;
        }
    }
}

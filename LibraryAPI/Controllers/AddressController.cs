using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IService<Address> _adrressService;

        public AddressController(IService<Address> adrressService)
        {
            _adrressService = adrressService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get()
        {
            List<Address> addresses = _adrressService.Get();

            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public ActionResult<Visitor> Get(Guid id)
        {
            var address = _adrressService.GetById(id);

            if (address == null)
                return NotFound();

            return Ok(address);
        }

        [HttpPost("save")]
        public ActionResult Insert(Address address)
        {
            bool result = _adrressService.Insert(address);
            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPut("update")]
        public ActionResult Update(Address address)
        {
            bool result = _adrressService.Update(address);
            if (result)
                return Ok();

            return BadRequest();
        }
    }
}

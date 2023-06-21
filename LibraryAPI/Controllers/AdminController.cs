using BLL.Helpers.PasswordHasher;
using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IService<Admin> _adminService;
        private readonly IPasswordHash hasher;

        public AdminController(IService<Admin> adminService, IPasswordHash hasher)
        {
            _adminService = adminService;
            this.hasher = hasher;
        }

        [HttpGet]
        public ActionResult<List<Admin>> Get()
        {
            List<Admin> admins = _adminService.Get();

            return Ok(admins);
        }

        [HttpGet("{id}")]
        public ActionResult<Admin> Get(Guid id)
        {
            var admin = _adminService.GetById(id);

            if (admin == null)
                return NotFound();

            return Ok(admin);
        }

        [HttpPost("save")]
        public ActionResult Insert(Admin address)
        {
            address.Password = hasher.EncryptPassword(address.Password, address.ID.ToByteArray());
            bool result = _adminService.Insert(address);
            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPut("update")]
        public ActionResult Update(Admin admin)
        {
            bool result = _adminService.Update(admin);
            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
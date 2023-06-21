using BLL.Helpers.PasswordHasher;
using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : Controller
    {
        private readonly IService<Manager> _managerService;
        private readonly IPasswordHash hasher;
        public ManagerController(IService<Manager> managerService, IPasswordHash hasher)
        {
            this._managerService = managerService;
            this.hasher = hasher;
        }

        [HttpGet]
        public ActionResult<List<Manager>> GetManagers()
        {
            List<Manager> managers = _managerService.Get();

            return Ok(managers);
        }

        [HttpGet("{id}")]
        public ActionResult<Manager> GetManager(Guid id)
        {
            var manager = _managerService.GetById(id);

            if (manager == null)
                return NotFound();

            return Ok(manager);
        }

        [HttpPost("save")]
        public ActionResult InsertManager(Manager manager)
        {
            manager.Password = hasher.EncryptPassword(manager.Password, manager.ID.ToByteArray());
            bool result = _managerService.Insert(manager);
            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
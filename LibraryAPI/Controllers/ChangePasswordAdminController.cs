using BLL.Helpers.PasswordHasher;
using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChangePasswordAdminController : ControllerBase
{
    private readonly IService<Admin> _adminService;
    private readonly IPasswordHash _passwordHash;

    public ChangePasswordAdminController(IService<Admin> adminService, IPasswordHash passwordHash)
    {
        _adminService = adminService;
        _passwordHash = passwordHash;
    }

    [HttpPost]
    public IActionResult ChangePasswordAdmin(Guid id, string oldPassword, string newPassword)
    {
        var user = _adminService.GetById(id);
        if (user == null)
        {
            return NotFound();
        }

        // Decrypt and compare old password
        var encryptedNewPassword = _passwordHash.EncryptPassword(newPassword, user.ID.ToByteArray());
        var encryptedOldPassword = _passwordHash.EncryptPassword(oldPassword, user.ID.ToByteArray());

        if (encryptedOldPassword != user.Password)
        {
            return BadRequest("The old password was entered incorrectly.");
        }

        // Change password
        user.Password = encryptedNewPassword;

        if (!_adminService.Update(user))
        {
            return StatusCode(500, "Error updating user.");
        }

        return Ok();
    }
}

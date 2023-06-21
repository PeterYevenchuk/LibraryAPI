using Microsoft.AspNetCore.Mvc;
using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using BLL.Helpers.PasswordHasher;
using DAL.Extentions;

namespace LibraryAPI.controllers;

[ApiController]
[Route("api/[controller]")]
public class ChangePasswordManagerController : ControllerBase
{
    private readonly IService<Manager> _managerService;
    private readonly IPasswordHash _passwordHash;

    public ChangePasswordManagerController(IService<Manager> managerService, IPasswordHash passwordHash)
    {
        _managerService = managerService;
        _passwordHash = passwordHash;
    }

    [HttpPost]
    public IActionResult ChangePasswordManager(Guid id, string oldPassword, string newPassword)
    {
        var user = _managerService.GetById(id);
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

        if (!_managerService.Update(user))
        {
            return StatusCode(500, "Error updating user.");
        }

        return Ok();
    }
}

using Microsoft.AspNetCore.Mvc;
using DAL.Db.Interfaces;
using DAL.Entities.EntitiesLibrary;
using BLL.Helpers.PasswordHasher;

namespace LibraryAPI.controllers;

[ApiController]
[Route("api/[controller]")]
public class ChangePasswordVisitorController : ControllerBase
{
    private readonly IService<Visitor> _visitorService;
    private readonly IPasswordHash _passwordHash;

    public ChangePasswordVisitorController(IService<Visitor> visitorService, IPasswordHash passwordHash)
    {
        _visitorService = visitorService;
        _passwordHash = passwordHash;
    }

    [HttpPost]
    public IActionResult ChangePasswordVisitor(Guid id, string oldPassword, string newPassword)
    {
        var user = _visitorService.GetById(id);
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

        if (!_visitorService.Update(user))
        {
            return StatusCode(500, "Error updating user.");
        }

        return Ok();
    }
}
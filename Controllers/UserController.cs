using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using validation.Entities;
using validation.Validator;

namespace validation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IValidator<User> _validator;

        public UserController(IValidator<User> validator)
        {
            _validator = validator;
        }


        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            new User { Name = user.Name,
            Surname = user.Surname};

            UserValidators validator = new();
            var validationResult = await _validator.ValidateAsync(user);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            return Ok();
        }
    }
}


using Giftlare.Core.Domain.Extensions;
using Giftlare.Core.Enums;
using Giftlare.Infra.DbEntities;
using Giftlare.Security.Application.Services.Interfaces;
using Giftlare.Security.Contracts;
using Giftlare.Security.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Giftlare.WebApi.Controllers.V1
{
    [AllowAnonymous]
    public class AccountsController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AccountsController(SignInManager<ApplicationUser> signInManager,
                                 UserManager<ApplicationUser> userManager,
                                 ITokenService tokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var user = new ApplicationUser
            {
                Name = signUpDto.Name,
                UserName = signUpDto.Email,
                Email = signUpDto.Email,
                Language = EnumExtensions.GetEnumFromDescription<Languages>(signUpDto.Language)
            };

            var result = await _userManager.CreateAsync(user, signUpDto.Password);
            if (!result.Succeeded)
                return BadRequest(result);

            await _signInManager.SignInAsync(user, false);
            return TokenResult(user);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            var result = await _signInManager.PasswordSignInAsync(signInDto.Email, signInDto.Password, false, false);
            var user = await _userManager.FindByNameAsync(signInDto.Email);

            if (!result.Succeeded || user == null)
                throw new SignInFailedException();
            return TokenResult(user);
        }

        private IActionResult TokenResult(ApplicationUser user)
        {
            var token = _tokenService.GenerateToken(user);
            return Ok(new SignInResultDto()
            {
                Token = token,
                User = new UserDto()
                {
                    Id = user.Id,
                    Name = user.Name ?? string.Empty,
                    Email = user.Email ?? string.Empty,
                    Language = user.Language.GetEnumDisplayDescription()
                }
            });
        }
    }
}

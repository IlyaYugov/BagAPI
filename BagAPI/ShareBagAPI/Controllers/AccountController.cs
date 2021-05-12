using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using DTO;
using Microsoft.AspNetCore.Authorization;

namespace ShareBagAPI.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserDomain _userDomain;
        public AccountController(UserDomain userDomain)
        {
            _userDomain = userDomain;
        }

        [HttpPost("Token")]
        public ActionResult<string> Token(string email, string password)
        {         
            return GetToken(email, password);
        }
       
        [HttpPost("CreateUser")]
        public ActionResult<string> CreateUser(UserDto user)
        {
            var createdUser = _userDomain.CreateUser(user);

            if (createdUser.ExceptionNessage != null)
                return BadRequest(createdUser.ExceptionNessage);

            return Token(createdUser.User.Email, createdUser.User.Password);
        }

        [HttpGet]
        [Authorize]
        public ActionResult<UserResult> GetUser()
        {
            var email = User.Identity.Name;

            var userResult = _userDomain.GetUser(email);
            userResult.User.Password = null;

            if (userResult.ExceptionNessage == null)
                return BadRequest(userResult);

            return Ok(userResult);
        }

        //[HttpPut]
        //public ActionResult<UserResult> UpdateUser(UserDto user)
        //{
        //    var userResult = _userDomain.UpdateUser(user);
        //    userResult.User.Password = null;

        //    if (userResult.ExceptionNessage == null)
        //        return BadRequest(userResult);

        //    return Ok(userResult);
        //}

       /* [HttpDelete]
        public ActionResult DeleteUser(string email)
        {
            var isDeleteSuccessful = _userDomain.DeleteUser(email);

            if (!isDeleteSuccessful)
                return BadRequest("User not found");

            return Ok(new { });
        }*/

        private ActionResult<string> GetToken(string mail, string password)
        {
            var identity = GetIdentity(mail, password);
            if (identity == null)
            {
                Response.StatusCode = 400;
                return BadRequest("Invalid email or password");
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(encodedJwt);
        }

        private ClaimsIdentity GetIdentity(string mail, string password)
        {
            var user = _userDomain.GetUser(mail, password);
            if (user.User != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.User.Email),
                    new Claim(AuthOptions.Password, user.User.Password),
                    new Claim(AuthOptions.Id, user.User.Id.ToString()),
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            //// если пользователя не найдено
            return null;
        }
    }
}

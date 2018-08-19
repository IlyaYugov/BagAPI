using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Implementations;
using Domain;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace BagAPI.Controllers
{
    [Route("api/Account")]
    public class AccountController : BaseController
    {
        private BagDbContext _bagDbContext;
        private UserDomain _userDomain;
        public AccountController(BagDbContext context)
        {
            _bagDbContext = context;
            _userDomain = new UserDomain(new UserRepository(context));
        }
        //[HttpPost("/api/Account/token")]
        //public async Task Token(string mail, string password)
        //{
        //    var identity = GetIdentity(mail, password);
        //    if (identity == null)
        //    {
        //        Response.StatusCode = 400;
        //        await Response.WriteAsync("Invalid mail or password.");
        //        return;
        //    }

        //    var now = DateTime.UtcNow;
        //    // создаем JWT-токен
        //    var jwt = new JwtSecurityToken(
        //            issuer: AuthOptions.Issuer,
        //            audience: AuthOptions.Audience,
        //            notBefore: now,
        //            claims: identity.Claims,
        //            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
        //            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        //    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        //    var response = new
        //    {
        //        access_token = encodedJwt,
        //        username = identity.Name
        //    };

        //    // сериализация ответа
        //    Response.ContentType = "application/json";
        //    await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        //}

        private ClaimsIdentity GetIdentity(string mail, string password)
        {
            //Person person = people.FirstOrDefault(x => x.Login == mail && x.Password == password);
            //if (person != null)
            //{
            //    var claims = new List<Claim>
            //    {
            //        new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
            //        new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
            //    };
            //    ClaimsIdentity claimsIdentity =
            //    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
            //        ClaimsIdentity.DefaultRoleClaimType);
            //    return claimsIdentity;
            //}

            //// если пользователя не найдено
            return null;
        }


        [HttpGet("/api/Account/GetUser")]
        public UserDto GetUser(int Id)
        {

            return new UserDto();
        }

        [HttpPost("/api/Account/CreateUser")]
        public UserDto CreateUser(UserDto user)
        {
            return _userDomain.CreateUser(user);
        }

        [HttpPut("/api/Account/UpdateUser")]
        public UserDto UpdateUser(UserDto user)
        {
            return _userDomain.UpdateUser(user);
        }

        [HttpDelete("/api/Account/DeleteUser")]
        public bool DeleteUser(int id)
        {
            return _userDomain.DeleteUser(id);
        }
    }
}
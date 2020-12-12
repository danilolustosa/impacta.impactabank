using ImpactaBank.API.Domain;
using ImpactaBank.API.Interface;
using ImpactaBank.API.Model.Response;
using ImpactaBank.API.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace ImpactaBank.API.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository) => _repository = repository;

        public BaseResponse Login(string email, string password)
        {
            if (email == String.Empty || email == null)
                return new BaseResponse() { StatusCode = StatusCodes.Status400BadRequest, Message = "Email is empty" };

            if (password == String.Empty || password == null)
                return new BaseResponse() { StatusCode = StatusCodes.Status400BadRequest, Message = "Password is empty" };

            User user = new User()
            {
                Email = email,
                Password = password
            };

            var result = _repository.Get(user);

            if (result == null)
                return new BaseResponse() { StatusCode = StatusCodes.Status400BadRequest, Message = "User/Password incorrect" };

            return new UserResponse()
            {
                Token = this.GenerateToken(result),
                StatusCode = StatusCodes.Status200OK,
                Message = "Logged"
            };
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString().Trim())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

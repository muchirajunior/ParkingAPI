using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ParkingAPI.Models;

namespace ParkingAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        public UserController(DatabaseContext context, IConfiguration configuration)
        {
            _context=context;
            _configuration=configuration;
        }

        [HttpGet("")]
        public IActionResult LoginUser([FromBody]User usr)
        {
            var user= _context.users.Where(user=>user.username==usr.username).FirstOrDefault();
            
            if (user != null){
                var passCheck = new PasswordHasher<object>().VerifyHashedPassword(null, user.password, usr.password);
                if (passCheck == PasswordVerificationResult.Success)
                    return Ok(new { Message = "successful login",Data=user,Token= GenerateJwt(user) });
                else
                    return Ok(new { Message="invalid password"});
            }else{
                return NotFound(new {Message="no such user in the records !"});
            }
        }

        [HttpPost("")]
        public IActionResult RegisterUser([FromBody]User user)
        {
            try {
                user.password=new PasswordHasher<Object>().HashPassword(null,user.password);
                _context.users.Add(user);
                _context.SaveChanges();
                return Created("",new {Message="user created successfully"});
                 
            } catch (System.Exception){
                return Ok(new {Message="failed to create user!"});
            }
        }

        private string GenerateJwt(User user){
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration ["JwtSettings:SignKey"]));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    

            var AuthClaims= new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("name", user.name),
                new Claim("username", user.username),
                new Claim("Roles","user")
            };
            var Token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                claims: AuthClaims,
                expires: DateTime.Now.AddHours(4),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }


        
    }
}
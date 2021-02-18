using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyAngular.Helpers;
using MyAngular.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using UserService.ContextModel;
using UserService.Helpers;

namespace MyAngular.Services
{

    public interface IUserService
    {
        Task<Users> Authenticate(string username, string password);
        Task<bool> CreateUser(CreateUserEntity obj);
    }

    public class UserService : IUserService
    {
        public IConfiguration Configuration { get; }
        private readonly DBContext _context;

        public UserService(IConfiguration configuration, DBContext context)
        {
            Configuration = configuration;
            _context = context;
        }

        public async Task<Users> Authenticate(string username, string password)
        {
            try
            {
                var user = _context.Users.Where(x => x.UserName == username.Trim())
               .Select(m => new Users
               {
                   Id = m.Id,
                   Name = string.Concat(m.FirstName, " ", m.MiddleName, " ", m.LastName),
                   Username = m.UserName,
                   Password=m.PasswordHash,
                   Token=m.Salt
               }).FirstOrDefault();


                // return null if user not found
                if (user == null)
                    return null;
                else
                {
                    //Check Password
                    if(!HashGenerator.ValidatePassword(password, user.Token, user.Password))
                    {
                        return null;
                    }
                }

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings")["Secret"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return user;
            }
            catch(Exception ex)
            {
                return new Users();
            }
           
        }


        public async Task<bool> CreateUser(CreateUserEntity obj)
        {
            try
            {
                var salt = HashGenerator.CreateSalt();
                var newUser = new User()
                {
                    UserName = obj.UserName,
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                    MiddleName = obj.MiddleName,
                    Email = obj.Email,
                    Mobile = obj.Mobile,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    PasswordHash = HashGenerator.CreateHashPassword(obj.Password, salt),
                    Salt = salt
                };

                _context.Users.Add(newUser);
                var res = _context.SaveChanges();
                if (res > 0) return true;
                else return false;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}

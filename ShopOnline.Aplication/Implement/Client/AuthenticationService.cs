using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ShopOnline.Aplication.Automapper;
using ShopOnline.Aplication.Interface.Client;
using ShopOnline.Aplication.ViewModel.Client;
using ShopOnline.Data.Entities;
using ShopOnline.DataEF;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utils.Dtos;

namespace ShopOnline.Aplication.Implement.Client
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private IMapper _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
        public AuthenticationService(AppDbContext contex, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this._context = contex;
            this._userManager = userManager;
            this._signInManager = signInManager;

        }
        private string secreatKey = "SECRETSIGN";
        public string GenerateJwtToken(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secreatKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("userId", userId.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public UserModel GetUser(string token)
        {
            var userid = ValidateJwtToken(token);
            if (userid.HasValue)
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == userid.Value);
                if (user != null)
                {
                    return _mapper.Map<UserModel>(user);
                }
                return null;
            }
            else
                return null;
        }

        public async Task<RepontResult> Login(LoginModelClient model)
        {
            var result = new RepontResult();
            var users = _context.Users.AsEnumerable();
            var checkUser = users.Any(x => x.UserName == model.Email && x.Status == Utils.Enum.Status.Active);
            if (!checkUser) 
            {
                result.Error = false;
                result.Message = "Login false !!";
                return result;
            }

            var resultLogin = await _signInManager.PasswordSignInAsync(model.Email, model.Password,true, lockoutOnFailure: true);
            // Khóa tài khoản
            if (resultLogin.IsLockedOut)
            {
                result.Error = false;
                result.Message = "Accout is locked....";
                return result;
            }

            if (resultLogin.Succeeded)
            {
                var userid = users.FirstOrDefault(x => x.UserName == model.Email && x.Status == Utils.Enum.Status.Active);
                result.Success = true;
                result.Message = "Login sucess";
                result.Data = GenerateJwtToken(userid.Id);
                return result;
            }
            result.Error = false;
            result.Message = "Excation ";
            return result;
        }

        public Guid? ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secreatKey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "userId").Value);

                // return account id from JWT token if validation successful
                return accountId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}

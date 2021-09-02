using AutoMapper;
using BarberShop.BL.DTOs.Global;
using BarberShop.Domain.Contexts;
using BarberShop.Domain.Entities.DataPerson;
using BarberShop.Domain.Entities.Users;
using BarberShop.Domain.UnitOfWork;
using BarberShop.Services.Base;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Services.Auth
{
  
public interface IAuthenticationManager : IBaseEntityService<UserIdentity, UserCredentialsDto>
    {
        Task<string> Authenticate(string username, string password);
        IDictionary<string, UserCredentialsDto> Tokens { get; }
        bool Validate(string token);
        Task<string> register(UserCredentialsDto user);
         

    }

    public class AuthenticationManager : BaseEntityService<UserIdentity, UserCredentialsDto>, IAuthenticationManager
    {
        private readonly IDictionary<string, UserCredentialsDto> tokens = new Dictionary<string, UserCredentialsDto>();

        public IDictionary<string, UserCredentialsDto> Tokens => tokens;



        public AuthenticationManager(IUnitOfWork<BaseDBContext> uow, IMapper mapper)
           : base(uow, mapper)
        {
            LoadTokens();
        }
        public async void LoadTokens() {
            var ident = (await _uow.GetRepository<UserIdentity>().Get(null, null, null, null, false,x=>x.persona)).ToList();
            
            foreach (var tokens in ident) {
                if (tokens.authkey != null) {
                    var data = _mapper.Map<UserCredentialsDto>(tokens);
                    Tokens.Add(tokens.authkey, data);
                    
                }
                   
            }
            
        }

        public  async Task<string> Authenticate(string username, string password)
        { 
             var info = (await _uow.GetRepository<UserIdentity>().
                Get(x => x.username.Equals(username) && x.Password.Equals(password),null, null, null,false, x => x.persona)).SingleOrDefault();
           

            if (info== null)
            {
                return null;
            }
             
            var token = generateToken(info.username);
              
            info.authkey = token; //save  token
            _uow.GetRepository<UserIdentity>().Update(info);
            await _uow.Commit();

            var datauser = _mapper.Map<UserCredentialsDto>(info);

            tokens.Add(token, datauser);

            return token;
        }
        public string generateToken(string username) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Tokendfsda dsad sa asdfdfd ");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var rt = tokenHandler.WriteToken(token);
            return rt;
        }

        public async Task<string> register(UserCredentialsDto user)
        {
            var personDto = user.persona;

            var info = (await _uow.GetRepository<PersonData>().Get(x=>x.Email.Equals(personDto.Email))).SingleOrDefault();

            if (info != null)
            {
                return null;
            }

            var ident = (await _uow.GetRepository<UserIdentity>().Get(x => x.username.Equals(user.username))).SingleOrDefault();

            if (ident != null)
            {
                return null;
            }

            var person = _mapper.Map<PersonData>(personDto);
            _uow.GetRepository<PersonData>().Add(person);
            await _uow.Commit();
             
            var datauser = _mapper.Map<UserIdentity>(user);
            var token = generateToken(datauser.username);

            datauser.authkey = token; //save  token
            _uow.GetRepository<UserIdentity>().Add(datauser);
            await _uow.Commit();

             
            tokens.Add(token, user);

            return token;
        }

        public  bool Validate(string token)
        {
            var data = Tokens.FirstOrDefault(t => t.Key == token).Value;
            return  data != null?true:false;
        }
         
    }
}

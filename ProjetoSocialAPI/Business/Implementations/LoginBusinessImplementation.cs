using ProjetoSocialAPI.Configurations;
using ProjetoSocialAPI.Data.ValueObject;
using ProjetoSocialAPI.Models;
using ProjetoSocialAPI.Repository;
using ProjetoSocialAPI.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProjetoSocialAPI.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _tokenConfiguration;
        private IPersonRepository _personRepository;
        private readonly ITokenService _tokenService;

        public LoginBusinessImplementation(TokenConfiguration tokenConfiguration, IPersonRepository personRepository, ITokenService tokenService)
        {
            _tokenConfiguration = tokenConfiguration;
            _personRepository = personRepository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(PersonVO person)
        {
            var validatedPerson = _personRepository.ValidateCredentials(person);
            if (validatedPerson is null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, validatedPerson.Login)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            validatedPerson.Token = new Token();
            validatedPerson.Token.RefreshToken = refreshToken;
            validatedPerson.Token.TokenRefreshTime = DateTime.Now.AddDays(_tokenConfiguration.DaysToExpire);

            DateTime createDate = DateTime.Now;
            DateTime extirationDate = createDate.AddMinutes(_tokenConfiguration.Minutes);

            _personRepository.RefreshUserInfo(validatedPerson);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                extirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }
    }
}

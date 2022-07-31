using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;

namespace BuberDinner.Api.Common.Mapper
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
        }
    }
}
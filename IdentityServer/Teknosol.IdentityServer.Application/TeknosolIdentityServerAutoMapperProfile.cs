using AutoMapper;

namespace Teknosol.IdentityServer.Application
{
    public class TeknosolIdentityServerAutoMapperProfile:Profile
    {
        public TeknosolIdentityServerAutoMapperProfile()
        {
            CreateMap<Sign>()
        }
    }
}
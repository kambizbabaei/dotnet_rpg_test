using AutoMapper;
using pr.dto.Character;
using pr.models;

namespace pr
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
        }
    }
}
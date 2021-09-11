using AutoMapper;
using pr.dto.Character;
using pr.dto.Weapon;
using pr.models;
using pr.Models;

namespace pr
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, getWeaponDto>();
            CreateMap<addWeaponDto, Weapon>();
        }
    }
}
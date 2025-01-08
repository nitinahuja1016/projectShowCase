using web_rpg.Dtos.Fight;
using web_rpg.Dtos.Skill;
using web_rpg.Dtos.Weapon;

namespace web_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto,Character>();
            CreateMap<Weapon,GetWeaponDto>();
            CreateMap<Skill,GetSkillDto>();
            CreateMap<Character,HighScoreDto>();
        }
    }
}

using pr.models;

namespace pr.dto.Character
{
    public class UpdateCharacterDto
    {

        public int id { get; set; }
        public string name { get; set; } = "frodo";
        public int hitPoints { get; set; } = 100;
        public int power { get; set; } = 100;
        public int defense { get; set; } = 100;
        public int intelligence { get; set; } = 100;
        public RpgClass characterClass { get; set; } = RpgClass.knight;

    }
}
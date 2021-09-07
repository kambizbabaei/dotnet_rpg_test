using pr.models;
using pr.Models.baseClass;

namespace pr.Models
{
    public class OwnedWeapon : entity
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public int Health { get; set; } = 100;
        public Weapon weapon { get; set; }
        public User user { get; set; }
        public Character character { get; set; } = null;
    }
}
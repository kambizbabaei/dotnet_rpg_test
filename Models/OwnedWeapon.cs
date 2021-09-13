using cls.majvacore.infra.Domain.Entities;
using pr.models;
using pr.Models.baseClass;

namespace pr.Models
{
    public class OwnedWeapon : IEntity<int>
    {
        public int Id { get; set; }
        public int Health { get; set; } = 100;
        public Weapon weapon { get; set; }
        public User user { get; set; }
        public Character character { get; set; } = null;

        public bool IsTransient()
        {
            throw new System.NotImplementedException();
        }
    }
}

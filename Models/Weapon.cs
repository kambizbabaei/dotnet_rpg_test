using System.Collections.Generic;
using cls.majvacore.infra.Domain.Entities;
using pr.models;
using pr.Models.baseClass;
namespace pr.Models
{
    public class Weapon : IEntity<int>
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public int power { get; set; }

        public bool IsTransient()
        {
            throw new System.NotImplementedException();
        }
    }

}
using System.Collections.Generic;
using pr.models;
using pr.Models.baseClass;
namespace pr.Models
{
    public class Weapon : entity
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public int power { get; set; }



    }

}
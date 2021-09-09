using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using cls.majvacore.infra.Domain.Entities;
using pr.Models;

namespace pr.models
{
    public class Character : Entity<int>
    {
        public Character() : base()
        {
            Time = DateTime.UtcNow.ToString();
        }

        public override int Id { get; set; }
        public string name { get; set; } = "frodo";
        public int hitPoints { get; set; } = 100;
        public int power { get; set; } = 100;
        public int defense { get; set; } = 100;
        public int intelligence { get; set; } = 100;
        public RpgClass characterClass { get; set; } = RpgClass.knight;
        public string Time { get; }

        public User owner { get; set; }


    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using pr.Models;

namespace pr.models
{
    public class Character
    {
        public Character()
        {
            Time = DateTime.UtcNow.ToString();
        }

        public int id { get; set; }
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
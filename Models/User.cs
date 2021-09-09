using System.Collections.Generic;
using cls.majvacore.infra.Domain.Entities;
using pr.models;

namespace pr.Models
{
    public class User : Entity<int>
    {

        public string username { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public List<Character> characters { get; set; }
        public List<Token> Tokens { get; set; }
        public override int Id { get; set; }
    }
}
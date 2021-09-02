using System.Collections.Generic;
using pr.models;
using pr.Models.baseClass;

namespace pr.Models
{
    public class User : entity
    {

        public string username { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public List<Character> characters { get; set; }
        public List<Token> Tokens { get; set; }
        public override int Id { get; set; }
    }
}
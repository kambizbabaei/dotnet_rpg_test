using System.Collections.Generic;
using pr.models;

namespace pr.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
        public List<Character> characters { get; set; }
        public List<Token> Tokens { get; set; }

    }
}
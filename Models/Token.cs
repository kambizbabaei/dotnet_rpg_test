using System;

namespace pr.Models
{
    public class Token
    {
        public Token()
        {
            time = DateTime.UtcNow;

        }
        public byte[] token { get; set; }
        public DateTime time { get; set; }
        public int id { get; set; }
    }
}
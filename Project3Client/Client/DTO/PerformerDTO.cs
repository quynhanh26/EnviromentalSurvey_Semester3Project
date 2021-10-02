using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.DTO
{
    public class PerformerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime Dob { get; set; }
        public string Img { get; set; }
        public bool Status { get; set; }
    }
}

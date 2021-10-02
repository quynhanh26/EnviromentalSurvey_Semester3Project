using System;
using System.Collections.Generic;

#nullable disable

namespace Client.Models
{
    public partial class Img
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int? IdSeminar { get; set; }

        public virtual Seminar IdSeminarNavigation { get; set; }
    }
}

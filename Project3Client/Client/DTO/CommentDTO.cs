﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Massage { get; set; }
        public int? IdAcc { get; set; }
        public string Img { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}

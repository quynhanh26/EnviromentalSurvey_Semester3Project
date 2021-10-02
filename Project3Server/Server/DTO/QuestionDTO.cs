using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Question1 { get; set; }
        public DateTime? Updated { get; set; }
        public bool Status { get; set; }
        public List<AnswerDTO> Answers { get; set; }
    }
}

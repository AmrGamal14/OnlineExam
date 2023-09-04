using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class AnswerList
    {
        public Guid AnswerId { get; set; }
        public bool IsCorrect { get; set; }
    }
}

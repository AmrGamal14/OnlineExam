using Core.Features.Answer.Command.Models;
using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Answer
{
    public partial class AnswerProfile
    {
        public void EditAnswer()
        {
            CreateMap<EditAnswerCommand, Answers>();
        }
    }
}

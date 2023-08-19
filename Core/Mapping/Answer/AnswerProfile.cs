using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Answer
{
    public partial class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            AddAnswer();
            AddAnswerCommand();
            EditAnswer();
            GetAnswerListQuery();
        }
    }
}

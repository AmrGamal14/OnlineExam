using Core.Features.Answer.Queries.Result;
using Core.Features.Subjects.Queries.Result;
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
        public void GetAnswerListQuery()
        {
            CreateMap<Answers, GetAnswerListResponse>();
        }
    }
}

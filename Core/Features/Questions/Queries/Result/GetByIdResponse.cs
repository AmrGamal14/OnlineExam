using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Questions.Queries.Result
{
    public class GetByIdResponse
    {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string SkillLevel { get; set; }
            public string Questions { get; set; }
            public List<answerslist> Answer { get; set; }
    }
    public class answerslist
    {
        public Guid Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }
}

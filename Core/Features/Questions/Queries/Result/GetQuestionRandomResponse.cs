using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Questions.Queries.Result
{
    public class GetQuestionRandomResponse
    {
        public string TitleExam { get; set; }
        public int Duration { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Questions { get; set; }
        public List<answerlist> answerlist { get; set; }
    }
    public class answerlist
    {
        public Guid Id { get; set; }
        public string Answer { get; set; }
    }
}

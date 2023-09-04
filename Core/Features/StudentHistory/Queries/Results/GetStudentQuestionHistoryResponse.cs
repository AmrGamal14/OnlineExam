using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentHistory.Queries.Results
{
    public class GetStudentQuestionHistoryResponse
    {

        public List<HistoryList> historyLists { get; set; }

    }
    public class HistoryList
    {
        public QuestionHistory Questions { get; set; }
        public AnswersHistory Answer { get; set; }
    
    }
}

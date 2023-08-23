using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstracts
{
    public interface IUnitOfWorkService :IDisposable
    {
        IAnswerService answerService { get; }
        IExamQuestionService examQuestionService { get; }
        IExamService examService { get; }
        ILevelService levelService { get; }
        IQuestionService questionService { get; }
        ISkillService skillService { get; }
        IStudentExamSrevice studentExamSrevice { get; }
        ISubjectLevelService subjectLevelService { get; }
        ISubjectService subjectService { get; }
        IStudentResultService studentResultService { get; }
    }
}

using Data.Entities.Models;
using Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstracts
{
    public interface IUnitOfWork: IDisposable

    {
        ILevelRepository level { get; }
        IAnswerRepository answer { get; }
        IExamQuestionRepository examQuestion { get; }
        IExamRepository exam { get; }
        IQuestionRepository question { get; }
        ISkillRepository skill { get; }
        IStudentExamRepository studentExam { get; }
        ISubjectLevelRepository subjectLevel { get; }
        ISubjectRepository subject { get; }
        IStudentResultRepository studentResult { get; }


    }
}

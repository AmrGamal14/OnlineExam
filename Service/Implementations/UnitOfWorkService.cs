using Infrastructure.Abstracts;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IAnswerService answerService { get; private set; }

        public IExamQuestionService examQuestionService { get; private set; }

        public IExamService examService { get; private set; }

        public ILevelService levelService { get; private set; }

        public IQuestionService questionService { get; private set; }

        public ISkillService skillService { get; private set; }

        public IStudentExamSrevice studentExamSrevice { get; private set; }

        public ISubjectLevelService subjectLevelService { get; private set; }

        public ISubjectService subjectService { get; private set; }
        public UnitOfWorkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            answerService=new AnswerService(_unitOfWork);
            examQuestionService=new ExamQuestionService(_unitOfWork);
            examService=new ExamService(_unitOfWork);
            levelService=new LevelService(_unitOfWork);
            questionService=new QuestionService(_unitOfWork);
            skillService=new SkillService(_unitOfWork);
            studentExamSrevice=new StudentExamSrevice(_unitOfWork);
            subjectLevelService=new SubjectLevelService(_unitOfWork);
            subjectService =new SubjectService(_unitOfWork);

        }

        public void Dispose()
        {
           _unitOfWork.Dispose();
        }
    }
}

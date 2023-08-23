using Data.Entities.Models;
using Infrastructure.Abstracts;
using Infrastructure.Context;
using Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _Context;
        public ILevelRepository level { get; private set; }
        public IAnswerRepository answer { get; private set; }
        public IExamQuestionRepository examQuestion { get; private set; }
        public IExamRepository exam { get; private set; }
        public IQuestionRepository question { get; private set; }
        public ISkillRepository skill { get; private set; }
        public IStudentExamRepository studentExam { get; private set; }
        public ISubjectLevelRepository subjectLevel { get; private set; }
        public ISubjectRepository subject { get; private set; }
        public IStudentResultRepository studentResult { get; private set; }

        public UnitOfWork(ApplicationDBContext context)
        {
            _Context=context;

            level =new LevelRepository(_Context);
            answer =new AnswerRepository(_Context);
            examQuestion = new ExamQuestionRepository(_Context);
            exam = new ExamRepository(_Context);
            question = new QuestionRepository(_Context);
            skill = new SkillRepository(_Context);
            studentExam = new StudentExamRepository(_Context);
            subjectLevel = new SubjectLevelRepository(_Context);
            subject = new SubjectRepository(_Context);
            studentResult=new StudentResultRepository(_Context);
        }

        public void Dispose()
        {
           _Context.Dispose();
        }
    }
}

using Data.Entities.Identity;
using Data.Entities.Models;
using Data.DTO;
using Infrastructure.Abstracts;
using Infrastructure.Context;
using Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class QuestionRepository : GenericRepositoryAsync<Question>, IQuestionRepository
    {
        #region Fields
        private readonly DbSet<Question> _questions;
        private readonly DbSet<Exam> _exams;
        private readonly DbSet<Answers> _answers;
        #endregion
        #region Constructors
        public QuestionRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _questions=dBContext.Set<Question>();
            _exams=dBContext.Set<Exam>();
            _answers=dBContext.Set<Answers>();

        }

        public async  Task<List<Question>> GetQuestionListAscync(string userId, Guid id)
        {
            var QuestionList= await _questions.Where(cb => cb.CreatedBy == userId&&cb.SubjectLevelId==id).Include(a => a.Answers).ToListAsync();
               return QuestionList;
        }

        public async Task<List<Question>> GetRandomQuestions(Guid id)
        {
            var exam =  _exams.FirstOrDefault(e => e.Id == id);
            var Questions =  RandomQuestion(exam);
            return Questions;
        }
        private List<Question> RandomQuestion(Exam exam)
        {
            // Filter questions
            var availableQuestions = _questions.Where(sb => sb.SubjectLevelId == exam.SubjectLevelId).Include(a=>a.Answers).ToList();

            if (availableQuestions.Count < exam.QuestionCount)
            {
                // Handle case where there aren't enough questions available
                return availableQuestions.ToList();
            }
            Random rand = new Random();
            int maxIndex = availableQuestions.Count - exam.QuestionCount;
            int skipper = rand.Next(0, maxIndex + 1);

            return availableQuestions
                .Skip(skipper)
                .Take(exam.QuestionCount)
                .ToList();
        }

        #endregion

    }
}

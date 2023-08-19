using Data.Entities.Models;
using Data.Utils;
using Infrastructure.Abstracts;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
          
            _questionRepository = questionRepository;

        }

        public async Task<Question> AddAsync(Question question)
        {
           await _questionRepository.AddAsync(question);
            return question;
        }

        public async Task<string> DeleteAsync(Question question)
        {
           await _questionRepository.DeleteAsync(question);
            return "Success";
        }

        public async Task<string> EditAsync(Question question)
        {
            await _questionRepository.UpdateAsync(question);
            return "Success";
        }

        public Task<List<Question>> GetQuestionListAsync(string userId, Guid id)
        {
            var questions= _questionRepository.GetQuestionListAscync(userId, id);
            return questions;
        }

        public async Task<List<Question>> GetQuestionRandomAsync(Guid id)
        {
           var Question =await _questionRepository.GetRandomQuestions(id);
            //var s = new List<Answers>();
            //s.ForEach(qId => qId.QuestionId = Question.Id);
            return Question;
        }

        public async Task<Question> GetQuesyionByIdasync(Guid id)
        {
            var question = _questionRepository.GetTableNoTracking().Where(x => x.Id == id).FirstOrDefault();
            return question;
        }
    }
}

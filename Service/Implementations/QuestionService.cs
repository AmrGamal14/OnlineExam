using Data.Entities.Models;
using Data.DTO;
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
        private readonly IUnitOfWork _unitOfWork;
        public QuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Question> AddAsync(Question question)
        {
           await _unitOfWork.question.AddAsync(question);
            _unitOfWork.Complete();
            return question;
        }

        public async Task<string> DeleteAsync(Question question)
        {
           await _unitOfWork.question.DeleteAsync(question);
            _unitOfWork.Complete();
            return "Success";
        }

        public async Task<string> EditAsync(Question question)
        {
            await _unitOfWork.question.UpdateAsync(question);
            _unitOfWork.Complete();
            return "Success";
        }

        public Task<List<Question>> GetQuestionListAsync(string userId, Guid id)
        {
            var questions= _unitOfWork.question.GetQuestionListAscync(userId, id);
            return questions;
        }

        public async Task<List<Question>> GetQuestionRandomAsync(Guid id)
        {
           var Question =await _unitOfWork.question.GetRandomQuestions(id);
            //var s = new List<Answers>();
            //s.ForEach(qId => qId.QuestionId = Question.Id);
            return Question;
        }

        public async Task<Question> GetQuesyionByIdasync(Guid id)
        {
            var question = _unitOfWork.question.GetTableNoTracking().Where(x => x.Id == id).FirstOrDefault();
            return question;
        }
    }
}

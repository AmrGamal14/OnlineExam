using Data.Entities.Models;
using Data.DTO;
using Infrastructure.Abstracts;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

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
            return question;
        }

        public async Task<string> DeleteAsync(Question question)
        {
           await _unitOfWork.question.DeleteAsync(question);
            return "Success";
        }

        public async Task<string> EditAsync(Question question)
        {
            await _unitOfWork.question.UpdateAsync(question);
            return "Success";
        }

        public async Task<List<Question>> GetByMultipleIdsAsync(List<Guid> Ids, List<Guid> id, params Expression<Func<Question, object>>[] includeProperties)
        {
            var Questions = await _unitOfWork.question.GetByMultipleIdsAsync(Ids,id);
            return Questions;
        }

        public async Task<Question> GetQuestionandAnswerById(Guid id)
        {
            var Questions = await _unitOfWork.question.GetQuestionAndAnswerById(id);
            return Questions;
        }

        public Task<List<Question>> GetQuestionListAsync(string userId, Guid id)
        {
            var questions= _unitOfWork.question.GetQuestionListAscync(userId, id);
            return questions;
        }

        public async Task<List<Question>> GetQuestionRandomAsync(Guid id)
        {
           var Question =await _unitOfWork.question.GetRandomQuestions(id);
            return Question;
        }

        public async Task<Question> GetQuesyionByIdasync(Guid id)
        {
            var question = _unitOfWork.question.GetTableNoTracking().Where(x => x.Id == id).FirstOrDefault();
            return question;
        }
    }
}

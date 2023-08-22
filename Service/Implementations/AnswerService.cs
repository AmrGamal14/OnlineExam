using Data.Entities.Models;
using Infrastructure.Abstracts;
using Infrastructure.Repositories;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AnswerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;

        }

        public async Task<string> AddListAsync(List<Answers> answers)
        {
           await _unitOfWork.answer.AddListAsync(answers);
            _unitOfWork.Complete();
            return "Success";
        }
        public async Task<string> AddAsync(Answers answers)
        {
            await _unitOfWork.answer.AddAsync(answers);
            _unitOfWork.Complete();
            return "Success";
        }

        public async Task<string> DeleteAsync(Answers answers)
        {
            await _unitOfWork.answer.DeleteAsync(answers);
            _unitOfWork.Complete();
            return "Success";
        }

        public async Task<string> EditAsync(Answers answers)
        {
            await _unitOfWork.answer.UpdateAsync(answers);
            _unitOfWork.Complete();
            return "Success";
        }

        public async Task<Answers> GetAnswerByIdasync(Guid id)
        {
            var answer = _unitOfWork.answer.GetTableNoTracking().Where(x => x.Id == id).FirstOrDefault();
            return answer;
        }

        public Task<List<Answers>> GetAnswerByQuestionIdasync(Guid id)
        {
            var answer = _unitOfWork.answer.GetAnswerListByQuestionId(id);
            return answer;
        }
    }
}

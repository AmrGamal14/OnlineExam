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
        private readonly IAnswerRepository _answerRepository;
        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
          
        }

        public async Task<string> AddListAsync(List<Answers> answers)
        {
           await _answerRepository.AddListAsync(answers);
            return "Success";
        }
        public async Task<string> AddAsync(Answers answers)
        {
            await _answerRepository.AddAsync(answers);
            return "Success";
        }

        public async Task<string> DeleteAsync(Answers answers)
        {
            await _answerRepository.DeleteAsync(answers);
            return "Success";
        }

        public async Task<string> EditAsync(Answers answers)
        {
            await _answerRepository.UpdateAsync(answers);
            return "Success";
        }

        public async Task<Answers> GetAnswerByIdasync(Guid id)
        {
            var answer =  _answerRepository.GetTableNoTracking().Where(x => x.Id == id).FirstOrDefault();
            return answer;
        }

        public Task<List<Answers>> GetAnswerByQuestionIdasync(Guid id)
        {
            var answer = _answerRepository.GetAnswerListByQuestionId(id);
            return answer;
        }
    }
}

using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstracts
{
    public interface IAnswerService
    {
        public Task<Answers> GetAnswerByIdasync(Guid id);
        public Task<List<Answers>> GetAnswerByQuestionIdasync(Guid id);
        public Task<string> AddListAsync(List<Answers> answers);
        public Task<string> AddAsync(Answers answers);
        public Task<string> EditAsync(Answers answers);
        public Task<string> DeleteAsync(Answers answers);
    }
}

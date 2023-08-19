using Data.Entities.Models;
using Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstracts
{
    public interface IQuestionService
    {
        public Task<Question> GetQuesyionByIdasync(Guid id);
        public Task<List<Question>> GetQuestionListAsync(string userId, Guid id);
        public Task<List<Question>> GetQuestionRandomAsync( Guid id);
        public Task<Question> AddAsync(Question question);
        public Task<string> EditAsync(Question question);
        public Task<string> DeleteAsync(Question question);
    }
}

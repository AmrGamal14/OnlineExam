using Data.Entities.Models;
using Data.DTO;
using Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstracts
{
    public interface IQuestionRepository  :IGenericeRepositoryAsync<Question>
    {
        public Task<List<Question>> GetQuestionListAscync(string userId, Guid id);
        public Task<List<Question>> GetRandomQuestions( Guid id);
    }
}

using Data.Entities.Models;
using Infrastructure.Abstracts;
using Infrastructure.InfrastructureBases;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class SubjectService : ISubjectService
    {
        public readonly ISubjectRepository _subjectRepository;

        public SubjectService (ISubjectRepository subjectRepository)
        {
            _subjectRepository=subjectRepository;   
        }

        public async Task<string> AddAsync(Subject subject)
        {
           await _subjectRepository.AddAsync(subject);
             return "Success";
        }

        public async Task<string> DeleteAsync(Subject subject)
        {
            await _subjectRepository.DeleteAsync(subject);
            return "Success";
        }

        public async Task<string> EditAsync(Subject subject)
        {
           await _subjectRepository.UpdateAsync(subject);
            return "Success";
        }

        public async Task<Subject> GetSubjectByIdasync(Guid id)
        {
            var subject = _subjectRepository.GetTableNoTracking().Where(x => x.Id == id).FirstOrDefault();
            return subject;
        }


        public async Task<List<Subject>> GetSubjectsListAsync(string userId)
        {
            return await _subjectRepository.GetSubjectListAscync(userId);
        }
    }
}

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
        public readonly IUnitOfWork _unitOfWork;

        public SubjectService (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> AddAsync(Subject subject)
        {
           await _unitOfWork.subject.AddAsync(subject);
            _unitOfWork.Complete();
             return "Success";
        }

        public async Task<string> DeleteAsync(Subject subject)
        {
            await _unitOfWork.subject.DeleteAsync(subject);
            _unitOfWork.Complete();
            return "Success";
        }

        public async Task<string> EditAsync(Subject subject)
        {
           await _unitOfWork.subject.UpdateAsync(subject);
            _unitOfWork.Complete();
            return "Success";
        }

        public async Task<Subject> GetSubjectByIdasync(Guid id)
        {
            var subject = _unitOfWork.subject.GetTableNoTracking().Where(x => x.Id == id).FirstOrDefault();
            return subject;
        }


        public async Task<List<Subject>> GetSubjectsListAsync(string userId)
        {
            return await _unitOfWork.subject.GetSubjectListAscync(userId);
        }
    }
}

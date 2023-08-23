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
             return "Success";
        }

        public async Task<string> DeleteAsync(Subject subject)
        {
            await _unitOfWork.subject.DeleteAsync(subject);
            return "Success";
        }

        public async Task<string> EditAsync(Subject subject)
        {
           await _unitOfWork.subject.UpdateAsync(subject);
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
        public async Task<Subject> GetSubjectByNameasync(string name ,string id)
        {
            var subject = _unitOfWork.subject.GetTableNoTracking().Where(x => x.Name==name&&x.CreatedBy==id).FirstOrDefault();
            return subject;

        }
    }
}

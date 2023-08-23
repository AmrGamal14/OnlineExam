using Data.Entities.Models;
using Infrastructure.Abstracts;
using Infrastructure.Repositories;
using Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service.Implementations
{
    public class SubjectLevelService : ISubjectLevelService
    {
        public readonly IUnitOfWork _unitOfWork;

        public SubjectLevelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> AddAsync(SubjectLevel subjectLevel)
        {
            await _unitOfWork.subjectLevel.AddAsync(subjectLevel);
            return "Success";
        }
        public async Task<SubjectLevel> GetSubjectLevelByLevelIdasync(Guid id)
        {
            var subjectLevel =await  _unitOfWork.subjectLevel.GetSubjectLevelByLevelIdAscync(id);
            return subjectLevel;

        }
    }
}

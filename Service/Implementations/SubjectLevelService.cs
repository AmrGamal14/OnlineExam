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
        public readonly ISubjectLevelRepository _subjectLevelRepository;

        public SubjectLevelService(ISubjectLevelRepository subjectLevelRepository)
        {
            _subjectLevelRepository=subjectLevelRepository;
        }
        public async Task<string> AddAsync(SubjectLevel subjectLevel)
        {
            await _subjectLevelRepository.AddAsync(subjectLevel);
            return "Success";
        }
    }
}

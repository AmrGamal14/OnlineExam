using Core.Features.Subjects.Queries.Result;
using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Subjects
{
    public partial class SubjectProfile
    {
        public void GetSubjectListQuery()
        {
            CreateMap<Subject, GetSubjectListResponse>();
        }
    }
}

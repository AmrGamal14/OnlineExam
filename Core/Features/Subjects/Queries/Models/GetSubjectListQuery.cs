using Application.Bases;
using Application.Features.Subjects.Queries.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Subjects.Queries.Models
{
    public class GetSubjectListQuery : IRequest<Response<List<GetSubjectListResponse>>>
    {
    }
}

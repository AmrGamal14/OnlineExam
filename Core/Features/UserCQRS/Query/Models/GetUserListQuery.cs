using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserCQRS.Query.Result;
using Application.Wrappers;

namespace Application.Features.UserCQRS.Query.Models
{
    public class GetUserListQuery : IRequest<PaginatedResult<GetUserListResult>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } 
    }
}

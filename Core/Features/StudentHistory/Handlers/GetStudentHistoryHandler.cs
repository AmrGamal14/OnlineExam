using Application.Bases;
using Application.Features.StudentHistory.Queries.Models;
using Application.Features.StudentHistory.Queries.Results;
using Application.Wrappers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Entities.Models;
using Infrastructure.Abstracts;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentHistory.Handlers
{
    public class GetStudentHistoryHandler : ResponseHandler, IRequestHandler<GetStudentHistory, PaginatedResult<GetStudentHistoryResponse>>
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public GetStudentHistoryHandler(IUnitOfWork unitOfWork, IAuditService auditService, IMapper mapper)

        {
            _auditService = auditService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion
        public async Task<PaginatedResult<GetStudentHistoryResponse>> Handle(GetStudentHistory request, CancellationToken cancellationToken)
        {
            var StudentExamLs =  _unitOfWork.studentExam.GetStudentExambyUserId(Guid.Parse(_auditService.UserId));
            
            var StudentExamMapper = await _mapper.ProjectTo<GetStudentHistoryResponse>(StudentExamLs).ToPaginatedListAsynnc(request.PageNumber, request.PageSize);
           
            return StudentExamMapper;

            //var StudentExam = await _unitOfWork.studentExam.GetStudentExambyUserId(Guid.Parse(_auditService.UserId));
            //var StudentExamMapper = _mapper.Map<List<GetStudentHistoryResponse>>(StudentExam);
            //return success(StudentExamMapper);
            //Expression<Func<Product, GetProductPaginatedListResponse>> expression = e => new GetProductPaginatedListResponse(e.Id, e.Name, e.Price, e.Quantitylimit, e.Availablequantity, e.briefdescription, e.ImageUrl);
            //var querable = _productService.GetProductQuerable();
            //var paginatedList = await querable.Select(expression).ToPaginatedListAsynnc(request.PageNumber, request.PageSize);
            //return paginatedList;
        }
    }
}

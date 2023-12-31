﻿using AutoMapper;
using Application.Bases;
using Application.Extensions;
using Application.Features.Exams.Commands.Models;
using Application.Features.Levels.Commands.Models;
using Data.Entities.Models;
using Infrastructure.Interfaces;
using MediatR;
//using Microsoft.AspNetCore.Http;
//using Service.Abstracts;
//using Service.Implementations;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Infrastructure.Abstracts;

//namespace Application.Features.Exams.Commands.Handlers
//{
//    //public class ExamCommandHandler : ResponseHandler/*, IRequestHandler<AddExamCommand, Response<string>>*/
//    //                                                 //, IRequestHandler<EditExamCommand, Response<string>>
//    //                                                 , IRequestHandler<DeleteExamCommand, Response<string>>
//    {
//        private readonly IMapper _mapper;
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        private readonly IAuditService _auditService;
//        public ExamCommandHandler (IMapper mapper,IAuditService auditService,IUnitOfWork unitOfWork, IExamService examService, IHttpContextAccessor httpContextAccessor)
//        {

//            _mapper = mapper;
//            _auditService = auditService;
//            _unitOfWork= unitOfWork;  
//            _httpContextAccessor=httpContextAccessor;
//        }

//        //public async Task<Response<string>> Handle(AddExamCommand request, CancellationToken cancellationToken)
//        //{
//        //    var subjectlevel=await _unitOfWork.subjectLevel.GetSubjectLevelByLevelIdAscync(request.LevelId);
//        //    var questionlist = await _unitOfWork.question.GetQuestionListAscync(_auditService.UserId, subjectlevel.Id);
//        //    int countt = questionlist.Count();
//        //    if (request.QuestionCount > countt)
//        //        return BadRequest<string>("Question Count more then your question");
//        //    if (subjectlevel == null)
//        //        return NotFound<string>("NotFouund");
//        //    var ExamMapper = _mapper.Map<Exam>(request);
//        //    ExamMapper.SubjectLevelId=subjectlevel.Id;
//        //    ExamMapper.AddEntityAudit();
//        //    var result = await _unitOfWork.exam.AddAsync(ExamMapper);
//        //    var ExamUrl = GenerateUrl(_httpContextAccessor, result.Id);
//        //    ExamMapper.url=ExamUrl;
//        //     await _unitOfWork.exam.UpdateAsync(ExamMapper);
//        //    return success($"{ExamUrl}");
//        //}
//        //public static Uri GenerateUrl(IHttpContextAccessor accessor,  Guid ExamId)
//        //{
//        //    if (ExamId.ToString() != null)
//        //    {
//        //        //Uri uri = new Uri($"{accessor.HttpContext.Request.Scheme}://{accessor.HttpContext.Request.Host}/ExamQuestion?ExamId={ExamId}");
//        //        Uri uri = new Uri($"http://localhost:4200/student/startExam/{ExamId}");
//        //        return uri;
//        //    }
//        //    return null;
//        //}

//        //public async Task<Response<string>> Handle(EditExamCommand request, CancellationToken cancellationToken)
//        //{
//        //    var OldExam =  _unitOfWork.exam.GetTableNoTracking().Where(x => x.Id==request.Id).FirstOrDefault();
//        //    if (OldExam == null)
//        //        return NotFound<string>("NotFouund");
//        //    var Exammapper = _mapper.Map<Exam>(request);
//        //    Exammapper.AddEntityAudit();
//        //    Exammapper.SubjectLevelId=OldExam.SubjectLevelId;
//        //    Exammapper.url=OldExam.url;
//        //     await _unitOfWork.exam.UpdateAsync(Exammapper);
//        //    return success("Edit Successfully");
            
//        //}

//        //public async Task<Response<string>> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
//        //{
//        //    var exam =  _unitOfWork.exam.GetTableNoTracking().Where(x => x.Id==request.Id).FirstOrDefault();
//        //    if (exam==null) return NotFound<string>("Notfouund");
//        //    await _unitOfWork.exam.DeleteAsync(exam);
//        //    return success("Delete Successfully");
//        //}
//    }
//}

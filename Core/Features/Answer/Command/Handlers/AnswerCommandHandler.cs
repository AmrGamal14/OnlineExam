using AutoMapper;
using Core.Bases;
using Core.Features.Answer.Command.Models;
using Core.Features.Questions.Commands.Models;
using Data.Entities.Models;
using MediatR;
using Service.Abstracts;
using Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Answer.Command.Handlers
{
    public class AnswerCommandHandler : ResponseHandler, IRequestHandler<EditAnswerCommand, Response<string>>
                                                         , IRequestHandler<DeleteAnswerCommand, Response<string>>
                                                         , IRequestHandler<AddAnswerCommand, Response<string>>

    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;
        public AnswerCommandHandler(IAnswerService answerService,IMapper mapper)
        {
            _answerService=answerService;
            _mapper=mapper;

        }

        public async Task<Response<string>> Handle(EditAnswerCommand request, CancellationToken cancellationToken)
        {
            var OldAnswer = await _answerService.GetAnswerByIdasync(request.Id);
            if (OldAnswer == null)
                return NotFound<string>("NotFouund");
            var Answermapper = _mapper.Map<Answers>(request);
            var result = await _answerService.EditAsync(Answermapper);
            if (result=="Success") return success("Edit Successfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await _answerService.GetAnswerByIdasync(request.Id);
            if (answer==null)
                return NotFound<string>("Notfouund");
            var result = await _answerService.DeleteAsync(answer);
            return success("");
        }

        public async Task<Response<string>> Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            var AnswerMapper = _mapper.Map<Answers>(request);
            var result = await _answerService.AddAsync(AnswerMapper);
            return success("k");

        }
    }
}

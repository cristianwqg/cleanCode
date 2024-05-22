using AutoMapper;
using FluentValidation;
using MediatR;
using Pronabec.Domain.Entities;
using Pronabec.Domain.Events;
using Pronabec.Dto;
using Pronabec.Interface.Infrastructure;
using Pronabec.Interface.Persistence;
using Pronabec.UseCases.Common.Bases;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pronabec.UseCases.Instituciones.Commands.CreateInstitucionCommand
{
    public class CreateInstitucionHandler : IRequestHandler<CreateInstitucionCommand, BaseResponse<InstitucionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;

        public CreateInstitucionHandler(IUnitOfWork unitOfWork, IMapper mapper, IEventBus eventBus)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _eventBus = eventBus;
        }

        public async Task<BaseResponse<InstitucionDto>> Handle(CreateInstitucionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<InstitucionDto>();
            try
            {
                var institucion = _mapper.Map<Institucion>(request);
                _unitOfWork.Instituciones.Create(institucion);

                institucion = await _unitOfWork.Instituciones.Get(institucion.Id);


                var institucionDto = _mapper.Map<InstitucionDto>(institucion);

                if (institucionDto is not null)
                {
                    response.Success = true;
                    response.Data = institucionDto;
                    response.Message = "Registro Exitoso!";

                    /* Publicamos el evento */
                    var institucionCreatedEvent = _mapper.Map<InstitucionCreatedEvent>(institucion);
                    _eventBus.Publish(institucionCreatedEvent);
                }                
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}

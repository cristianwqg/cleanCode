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

namespace Pronabec.UseCases.Compromiso.Commands.CreateCompromisoCommand
{
    public class CreateCompromisoHandler : IRequestHandler<CreateCompromisoCommand, BaseResponse<CompromisoDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;

        public CreateCompromisoHandler(IUnitOfWork unitOfWork, IMapper mapper, IEventBus eventBus)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _eventBus = eventBus;
        }

        public async Task<BaseResponse<CompromisoDto>> Handle(CreateCompromisoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CompromisoDto>();
            try
            {
                var compromiso = _mapper.Map<Domain.Entities.Compromiso>(request);
                _unitOfWork.Compromiso.Create(compromiso);

                compromiso = await _unitOfWork.Compromiso.Get(compromiso.Id);

                var compromisoDto = _mapper.Map<CompromisoDto>(compromiso);

                if (compromisoDto is not null)
                {
                    response.Success = true;
                    response.Data = compromisoDto;
                    response.Message = "Registro Exitoso!";

                    /* Publicamos el evento */
                    var compromisoCreatedEvent = _mapper.Map<CompromisoCreatedEvent>(compromiso);
                    _eventBus.Publish(compromisoCreatedEvent);
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

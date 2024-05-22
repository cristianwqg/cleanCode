using AutoMapper;
using MediatR;
using Pronabec.Domain.Entities;
using Pronabec.Dto;
using Pronabec.Interface.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pronabec.UseCases.Compromiso.Commands.UpdateCompromisoCommand
{
    public class UpdateCompromisoHandler : IRequestHandler<UpdateCompromisoCommand, CompromisoDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCompromisoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CompromisoDto> Handle(UpdateCompromisoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var compromiso = _mapper.Map<Domain.Entities.Compromiso>(request);
                _unitOfWork.Compromiso.Update(compromiso);

                compromiso = await _unitOfWork.Compromiso.Get(request.Id);
                var response = _mapper.Map<CompromisoDto>(compromiso);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

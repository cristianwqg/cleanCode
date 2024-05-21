using AutoMapper;
using MediatR;
using Pronabec.Domain.Entities;
using Pronabec.Dto;
using Pronabec.Interface.Persistence;

namespace Pronabec.UseCases.Instituciones.Commands.UpdateInstitucionCommand
{
    public class UpdateInstitucionHandler : IRequestHandler<UpdateInstitucionCommand, InstitucionDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateInstitucionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<InstitucionDto> Handle(UpdateInstitucionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var institucion = _mapper.Map<Institucion>(request);
                _unitOfWork.Instituciones.Update(institucion);

                institucion = await _unitOfWork.Instituciones.Get(request.Id);
                var response = _mapper.Map<InstitucionDto>(institucion);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

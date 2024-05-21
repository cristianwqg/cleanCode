using MediatR;
using Pronabec.Interface.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pronabec.UseCases.Personas.Commands.DeletePersonaCommand
{
    public class DeletePersonaHandler : IRequestHandler<DeletePersonaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonaHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
        {            
            _unitOfWork.Personas.Delete(request.Id);
            return true;
        }
    }
}

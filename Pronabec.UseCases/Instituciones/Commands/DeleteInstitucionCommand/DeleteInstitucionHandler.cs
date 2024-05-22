using MediatR;
using Pronabec.Interface.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Pronabec.UseCases.Instituciones.Commands.DeleteInstitucionCommand
{
    public class DeleteInstitucionHandler : IRequestHandler<DeleteInstitucionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteInstitucionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteInstitucionCommand request, CancellationToken cancellationToken)
        {            
            _unitOfWork.Instituciones.Delete(request.Id);
            return true;
        }
    }
}

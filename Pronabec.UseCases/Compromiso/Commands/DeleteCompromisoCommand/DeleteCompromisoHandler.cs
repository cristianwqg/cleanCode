using MediatR;
using Pronabec.Interface.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pronabec.UseCases.Compromiso.Commands.DeleteCompromisoCommand
{
    public class DeleteCompromisoHandler : IRequestHandler<DeleteCompromisoCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompromisoHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCompromisoCommand request, CancellationToken cancellationToken)
        {            
            _unitOfWork.Compromiso.Delete(request.Id);
            return true;
        }
    }
}

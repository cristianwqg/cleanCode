using MediatR;

namespace Pronabec.UseCases.Instituciones.Commands.DeleteInstitucionCommand
{
    public sealed record DeleteInstitucionCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

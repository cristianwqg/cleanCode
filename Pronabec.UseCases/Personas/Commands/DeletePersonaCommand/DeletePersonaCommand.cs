using MediatR;

namespace Pronabec.UseCases.Personas.Commands.DeletePersonaCommand
{
    public sealed record DeletePersonaCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

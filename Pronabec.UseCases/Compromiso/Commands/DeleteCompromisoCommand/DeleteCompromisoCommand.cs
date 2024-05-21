using MediatR;

namespace Pronabec.UseCases.Compromiso.Commands.DeleteCompromisoCommand
{
    public sealed record DeleteCompromisoCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

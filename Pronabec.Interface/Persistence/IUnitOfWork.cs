using System;

namespace Pronabec.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonaRepository Personas { get; }
        IInstitucionRepository Instituciones { get; }
        ICompromisoRepository Compromiso { get; }
    }
}

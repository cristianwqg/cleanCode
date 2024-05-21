using Pronabec.Interface.Persistence;

namespace Pronabec.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPersonaRepository Personas { get; }
        public IInstitucionRepository Instituciones { get; }
        public ICompromisoRepository Compromiso { get; }

        public UnitOfWork(IPersonaRepository personas, IInstitucionRepository instituciones, ICompromisoRepository compromiso)
        {
            Personas = personas;
            Instituciones = instituciones;
            Compromiso = compromiso;

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

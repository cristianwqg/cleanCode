using Dapper;
using Microsoft.Extensions.Caching.Distributed;
using Pronabec.Domain.Entities;
using Pronabec.Interface.Persistence;
using Pronabec.Persistence.Context;
using System.Text;
using System.Text.Json;

namespace Pronabec.Persistence.Repositories
{
    public class InstitucionRepository : IInstitucionRepository
    {       
        private readonly DapperContext _applicationContext;
        private readonly IDistributedCache _distributedCache;

        public InstitucionRepository(DapperContext applicationContext, IDistributedCache distributedCache)
        {
            _applicationContext = applicationContext;
            _distributedCache = distributedCache;
        }

        public async void Create(Institucion entity)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "sp_ins_institucion";
            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id);
            parameters.Add("Nombre", entity.Nombre);
            parameters.Add("Dni", entity.Ruc);
            parameters.Add("Direccion", entity.Direccion);
            parameters.Add("Estado", entity.Estado);

            await connection.ExecuteAsync(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async void Update(Institucion entity)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "sp_upd_institucion";
            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id);            
            parameters.Add("Direccion", entity.Direccion);
            parameters.Add("Estado", entity.Estado);

            await connection.ExecuteAsync(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async void Delete(int id)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "sp_del_institucion";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);            

            await connection.ExecuteAsync(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<Institucion> Get(int id)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "sp_sel_institucion_id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            var institucion = await connection.QuerySingleOrDefaultAsync<Institucion>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            return institucion;
        }

        public async Task<IEnumerable<Institucion>> GetAll()
        {
            var cacheKey = "institucionesCache";

            var redisInstituciones = await _distributedCache.GetAsync(cacheKey);
            if (redisInstituciones != null)
            {
                return JsonSerializer.Deserialize<IEnumerable<Institucion?>>(redisInstituciones);
            }

            using var connection = _applicationContext.CreateConnection();
            var query = "sp_sel_institucion_all";  

            var instituciones = await connection.QueryAsync<Institucion>(query, commandType: System.Data.CommandType.StoredProcedure);

            var serializedInstituciones = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(instituciones));
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddHours(8))
                .SetSlidingExpiration(TimeSpan.FromMinutes(60));

            await _distributedCache.SetAsync(cacheKey, serializedInstituciones, options);

            return instituciones;
        }
    }
}
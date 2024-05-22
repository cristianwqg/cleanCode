using Dapper;
using Microsoft.Extensions.Caching.Distributed;
using Pronabec.Domain.Entities;
using Pronabec.Interface.Persistence;
using Pronabec.Persistence.Context;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using System;

namespace Pronabec.Persistence.Repositories
{
    public class CompromisoRepository : ICompromisoRepository
    {       
        private readonly DapperContext _applicationContext;
        private readonly IDistributedCache _distributedCache;

        public CompromisoRepository(DapperContext applicationContext, IDistributedCache distributedCache)
        {
            _applicationContext = applicationContext;
            _distributedCache = distributedCache;
        }

        public async void Create(Compromiso entity)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "sp_ins_compromiso";
            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id);
            parameters.Add("Nombre", entity.Nombre);
            parameters.Add("Inicio", entity.Inicio);
            parameters.Add("Fin", entity.Fin);
            parameters.Add("Descripcion", entity.Descripcion);
            parameters.Add("Estado", entity.Estado);

            await connection.ExecuteAsync(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async void Update(Compromiso entity)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "sp_upd_compromiso";
            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id);
            parameters.Add("Inicio", entity.Inicio);
            parameters.Add("Fin", entity.Fin);
            parameters.Add("Descripcion", entity.Descripcion);
            parameters.Add("Estado", entity.Estado);

            await connection.ExecuteAsync(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async void Delete(int id)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "sp_del_compromiso";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);            

            await connection.ExecuteAsync(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<Compromiso> Get(int id)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "sp_sel_compromiso_id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            var compromiso = await connection.QuerySingleOrDefaultAsync<Compromiso>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            return compromiso;
        }

        public async Task<IEnumerable<Compromiso>> GetAll()
        {
            var cacheKey = "CompromisoCache";

            var redisCompromiso = await _distributedCache.GetAsync(cacheKey);
            if (redisCompromiso != null)
            {
                return JsonSerializer.Deserialize<IEnumerable<Compromiso?>>(redisCompromiso);
            }

            using var connection = _applicationContext.CreateConnection();
            var query = "sp_sel_compromiso_all";  

            var compromisos = await connection.QueryAsync<Compromiso>(query, commandType: System.Data.CommandType.StoredProcedure);

            var serializedCompromisos = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(compromisos));
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddHours(8))
                .SetSlidingExpiration(TimeSpan.FromMinutes(60));

            await _distributedCache.SetAsync(cacheKey, serializedCompromisos, options);

            return compromisos;
        }
    }
}
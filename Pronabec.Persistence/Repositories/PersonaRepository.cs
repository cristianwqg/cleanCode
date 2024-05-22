using Dapper;
using Microsoft.Extensions.Caching.Distributed;
using Pronabec.Domain.Entities;
using Pronabec.Interface.Persistence;
using Pronabec.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pronabec.Persistence.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {       

        private readonly DapperContext _applicationContext;
        private readonly IDistributedCache _distributedCache;

        public PersonaRepository(DapperContext applicationContext, IDistributedCache distributedCache)
        {
            _applicationContext = applicationContext;
            _distributedCache = distributedCache;
        }

        public async void Create(Persona entity)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "sp_ins_persona";
            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id);
            parameters.Add("Nombre", entity.Nombre);
            parameters.Add("Dni", entity.Dni);
            parameters.Add("FechaNac", entity.FechaNac);
            parameters.Add("Edad", entity.Edad);
            parameters.Add("Estado", entity.Estado);

            await connection.ExecuteAsync(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async void Update(Persona entity)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "sp_upd_persona";
            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id);            
            parameters.Add("FechaNac", entity.FechaNac);
            parameters.Add("Edad", entity.Edad);
            parameters.Add("Estado", entity.Estado);

            await connection.ExecuteAsync(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async void Delete(int id)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "sp_del_persona";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);            

            await connection.ExecuteAsync(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<Persona> Get(int id)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "sp_sel_persona_id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            var persona = await connection.QuerySingleOrDefaultAsync<Persona>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            return persona;
        }


        public async Task<Persona> GenerarPDF(int id)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "VAL_ACTA_GRUPAL_2024_BEAHD_INS";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            var persona = await connection.QuerySingleOrDefaultAsync<Persona>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            return persona;
        }



        public async Task<IEnumerable<Persona>> GetAll()
        {
            var cacheKey = "personasCache";

            var redisPersonas = await _distributedCache.GetAsync(cacheKey);
            if (redisPersonas != null)
            {
                return JsonSerializer.Deserialize<IEnumerable<Persona?>>(redisPersonas);
            }

            using var connection = _applicationContext.CreateConnection();
            var query = "sp_sel_persona_all";  

            var personas = await connection.QueryAsync<Persona>(query, commandType: System.Data.CommandType.StoredProcedure);

            var serializedPersonas = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(personas));
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddHours(8))
                .SetSlidingExpiration(TimeSpan.FromMinutes(60));

            await _distributedCache.SetAsync(cacheKey, serializedPersonas, options);

            return personas;
        }              
    }
}
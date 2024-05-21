using AutoMapper;
using Pronabec.Domain.Entities;
using Pronabec.Domain.Events;
using Pronabec.Dto;
using Pronabec.UseCases.Compromiso.Commands.CreateCompromisoCommand;
using Pronabec.UseCases.Compromiso.Commands.UpdateCompromisoCommand;
using Pronabec.UseCases.Instituciones.Commands.CreateInstitucionCommand;
using Pronabec.UseCases.Instituciones.Commands.UpdateInstitucionCommand;
using Pronabec.UseCases.Personas.Commands.CreatePersonaCommand;
using Pronabec.UseCases.Personas.Commands.UpdatePersonaCommand;

namespace Pronabec.UseCases.Common.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Persona, PersonaDto>().ReverseMap();
            CreateMap<Persona, CreatePersonaCommand>().ReverseMap();
            CreateMap<Persona, UpdatePersonaCommand>().ReverseMap();
            CreateMap<Persona, PersonaCreatedEvent>().ReverseMap();

            CreateMap<Institucion, InstitucionDto>().ReverseMap();
            CreateMap<Institucion, CreateInstitucionCommand>().ReverseMap();
            CreateMap<Institucion, UpdateInstitucionCommand>().ReverseMap();
            CreateMap<Institucion, InstitucionCreatedEvent>().ReverseMap();

            CreateMap<Compromiso, CompromisoDto>().ReverseMap();
            CreateMap<Compromiso, CreateCompromisoCommand>().ReverseMap();
            CreateMap<Compromiso, UpdateCompromisoCommand>().ReverseMap();
            CreateMap<Compromiso, CompromisoCreatedEvent>().ReverseMap();
        }
    }
}
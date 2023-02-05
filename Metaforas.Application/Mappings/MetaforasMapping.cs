using AutoMapper;
using Metaforas.Application.Models;
using Metaforas.Domain.Entities;

namespace Metaforas.Application.Mappings
{
    public class MetaforasMapping : Profile
    {
        public MetaforasMapping()
        {
            CreateMap<Pensador, PensadorGetModel>().ReverseMap();
            CreateMap<Pensador, PensadorPutModel>().ReverseMap();
            CreateMap<Pensador, PensadorPostModel>().ReverseMap();
            
            CreateMap<Time, TimeGetModel>().ReverseMap();
            CreateMap<Time, TimePutModel>().ReverseMap();
            CreateMap<Time, TimePostModel>().ReverseMap();
            
            CreateMap<Frase, FraseGetModel>().ReverseMap();
            CreateMap<Frase, FrasePutModel>().ReverseMap();
            CreateMap<Frase, FrasePostModel>().ReverseMap();
            
            CreateMap<PensadorTime, PensadorTimeGetModel>().ReverseMap();
            CreateMap<PensadorTime, PensadorTimePutModel>().ReverseMap();
            CreateMap<PensadorTime, PensadorTimePostModel>().ReverseMap();

        }
    }
}

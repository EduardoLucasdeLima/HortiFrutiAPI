using AutoMapper;
using HortiFrutiAPI.Models;

namespace HortiFrutiAPI.DTOs.Mappings;

public class FrutaDTOMappingProfile : Profile
{
    public FrutaDTOMappingProfile()
    {
        CreateMap<Fruta, FrutaDTO>().ReverseMap();
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        CreateMap<Fruta, FrutaDTOUpdateRequest>().ReverseMap();
        CreateMap<Fruta, FrutaDTOUpdateResponse>().ReverseMap();
    }
}
